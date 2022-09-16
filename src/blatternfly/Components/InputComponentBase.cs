// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
using System.Linq.Expressions;

namespace Blatternfly.Components;

/// <summary>
/// Input component base
/// </summary>
/// <remarks>
/// Partially based on Blazor source code.
/// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputBase.cs
///
/// See too:
/// https://chrissainty.com/creating-bespoke-input-components-for-blazor-from-scratch/
/// </remarks>
public abstract class InputComponentBase<TValue> : ComponentBase, IDisposable
{
    private bool                   _hasInitializedParameters;
    private bool                   _previousParsingAttemptFailed;
    private ValidationMessageStore _parsingValidationMessages;
    private Type                   _nullableUnderlyingType;

    [CascadingParameter] private EditContext CascadedEditContext { get; set; }
    [CascadingParameter] private FormGroup CascadedFormGroup { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Value to indicate if the input is modified to show that validation state.
    /// If set to success, input will be modified to indicate valid state.
    /// If set to error,  input will be modified to indicate error state.
    /// </summary>
    [Parameter] public ValidatedOptions? Validated { get; set; }

    /// <summary>Form control value.</summary>
    [Parameter] public TValue Value  { get; set; }

    /// <summary>Form control value changed event callback.</summary>
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>Form control value expression.</summary>
    [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }

    /// <summary>Display name.</summary>
    [Parameter] public string DisplayName { get; set; }

    /// <summary>
    /// Gets the associated <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/>.
    /// This property is uninitialized if the input does not have a parent <see cref="Microsoft.AspNetCore.Components.Forms.EditForm"/>.
    /// </summary>
    protected EditContext EditContext { get; set; }

    /// <summary>
    /// For integration with <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/>
    /// https://chrissainty.com/creating-bespoke-input-components-for-blazor-from-scratch/
    /// </summary>
    protected internal FieldIdentifier FieldIdentifier
    {
        get;
        set;
    }

    /// <summary>Gets or sets the current value of the input.</summary>
    protected internal TValue CurrentValue
    {
        get => Value;
        set
        {
            Value = value;
            _ = ValueChanged.InvokeAsync(Value);
            EditContext?.NotifyFieldChanged(FieldIdentifier);
        }
    }

    /// <summary>Gets or sets the current value of the input, represented as a string.</summary>
    protected internal string CurrentValueAsString
    {
        get => FormatValueAsString(Value);
        set
        {
            _parsingValidationMessages?.Clear();

            bool parsingFailed;

            if (_nullableUnderlyingType is not null && string.IsNullOrEmpty(value))
            {
                // Assume if it's a nullable type, null/empty inputs should correspond to default(T)
                // Then all subclasses get nullable support almost automatically (they just have to
                // not reject Nullable<T> based on the type itself).
                parsingFailed = false;
                Validated     = null;
                CurrentValue  = default;
            }
            else if (TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage))
            {
                parsingFailed = false;
                Validated     = null;
                CurrentValue  = parsedValue;
            }
            else
            {
                parsingFailed = true;
                Validated     = ValidatedOptions.Error;

                // EditContext may be null if the input is not a child component of EditForm.
                if (EditContext is not null)
                {
                    _parsingValidationMessages ??= new ValidationMessageStore(EditContext);
                    _parsingValidationMessages.Add(FieldIdentifier, validationErrorMessage);

                    // Update the parent form group validation state
                    CascadedFormGroup?.UpdateValidationState(Validated, Validated.HasValue ? validationErrorMessage : null);

                    // Since we're not writing to CurrentValue, we'll need to notify about modification from here
                    EditContext.NotifyFieldChanged(FieldIdentifier);
                }
            }

            // We can skip the validation notification if we were previously valid and still are
            if (parsingFailed || _previousParsingAttemptFailed)
            {
                EditContext?.NotifyValidationStateChanged();
                _previousParsingAttemptFailed = parsingFailed;

                if (EditContext is null)
                {
                    StateHasChanged();
                }
            }
        }
    }

    protected string AriaInvalid
    {
        get
        {
            var ariaInvalid = AdditionalAttributes.GetPropertyValue("aria-invalid");
            if (!string.IsNullOrEmpty(ariaInvalid))
            {
                return ariaInvalid;
            }
            return Validated == ValidatedOptions.Error ? "true" : "false";
        }
    }

    protected string ValidationClass
    {
        get => Validated switch
        {
            ValidatedOptions.Success => "pf-m-success",
            ValidatedOptions.Warning => "pf-m-warning",
            _                        => null
        };
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    void IDisposable.Dispose()
    {
        // When initialization in the SetParametersAsync method fails, the EditContext property can remain equal to null
        if (EditContext is not null)
        {
            EditContext.OnValidationStateChanged -= EditContextOnOnValidationStateChanged;
        }

        Dispose(disposing: true);
    }

    protected virtual string FormatValueAsString(TValue value) => value?.ToString();

    protected abstract bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage);

    protected virtual void EditContextOnOnValidationStateChanged(object sender, ValidationStateChangedEventArgs e)
    {
        StateHasChanged();
    }

    /// <inheritdoc />
    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (!_hasInitializedParameters)
        {
            // This is the first run

            if (CascadedEditContext is not null && ValueExpression is null)
            {
                throw new InvalidOperationException(
                    $"{GetType()} requires a value for the 'ValueExpression' parameter. Normally this is provided automatically when using 'bind-Value'.");
            }

            if (CascadedEditContext is not null)
            {
                EditContext     = CascadedEditContext;
                FieldIdentifier = FieldIdentifier.Create(ValueExpression);

                EditContext.OnValidationStateChanged += EditContextOnOnValidationStateChanged;
            }

            _nullableUnderlyingType   = Nullable.GetUnderlyingType(typeof(TValue));
            _hasInitializedParameters = true;
        }
        else if (CascadedEditContext != EditContext)
        {
            // Not the first run

            // Changing EditContext is not supported, because it's messy to be clearing up state and event
            // handlers for the previous one, and there's no strong use case. If a strong use case
            // emerges, we can consider changing this.
            throw new InvalidOperationException($"{GetType()} does not support changing the {nameof(EditContext)} dynamically.");
        }

        // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
        return base.SetParametersAsync(ParameterView.Empty);
    }
}
