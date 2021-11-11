// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blatternfly.Components;

/// <summary>
/// Some parts has been copied from Blazor source code.
///
/// https://chrissainty.com/creating-bespoke-input-components-for-blazor-from-scratch/
/// </summary>
public abstract class InputComponentBase<TValue> : BaseComponent, IDisposable
{
    [CascadingParameter] public EditContext CascadedEditContext { get; set; }
    [CascadingParameter] public FormGroup CascadedFormGroup { get; set; }

    /// Flag indicating whether the Form Control is disabled.
    [Parameter] public bool IsDisabled { get; set; }

    /// Flag indicating whether the form control is required.
    [Parameter] public bool IsRequired { get; set; }

    /// Value to indicate if the input is modified to show that validation state.
    /// If set to success, input will be modified to indicate valid state.
    /// If set to error,  input will be modified to indicate error state.
    [Parameter] public ValidatedOptions? Validated { get; set; }

    /// Form control value.
    [Parameter] public TValue Value  { get; set; }

    /// Form control value changed event callback.
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    /// Form control value expression.
    [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }

    /// Display name.
    [Parameter] public string DisplayName { get; set; }

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

    /// <inheritdoc />
    /// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputBase.cs
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (CascadedEditContext is not null) // If the control is inside a Form ...
        {
            if (EditContext is null)
            {
                if (ValueExpression is null)
                {
                    throw new InvalidOperationException($"{GetType()} requires a value for the 'ValueExpression' parameter. Normally this is provided automatically when using 'bind-Value'.");
                }

                EditContext     = CascadedEditContext;
                FieldIdentifier = FieldIdentifier.Create(ValueExpression);

                // Validation handler
                EditContext.OnValidationStateChanged += EditContextOnOnValidationStateChanged;
            }
            else if (CascadedEditContext != EditContext)
            {
                // Disallow changing EditContext
                throw new InvalidOperationException($"{GetType()} does not support changing the {nameof(EditContext)} dynamically.");
            }
        }

        await base.SetParametersAsync(ParameterView.Empty);
    }

    protected string AriaInvalid
    {
        get
        {
            var ariaInvalid = GetPropertyValue("aria-invalid");
            if (!string.IsNullOrEmpty(ariaInvalid))
            {
                return ariaInvalid;
            }
            return Validated == ValidatedOptions.Error ? "true" : "false";
        }
    }

    protected string DisabledClass
    {
        get => IsDisabled ? "pf-m-disabled" : null;
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

    protected TValue CurrentValue
    {
        get => Value;
        set
        {
            if (!EqualityComparer<TValue>.Default.Equals(value, Value))
            {
                Value = value;
                _ = ValueChanged.InvokeAsync(Value);
                EditContext?.NotifyFieldChanged(FieldIdentifier);
                StateHasChanged();
            }
        }
        }

    protected string CurrentValueAsString
    {
        get => FormatValueAsString(Value);
        set
        {
            if (TryParseValueFromString(value, out var result, out var validationErrorMessage))
            {
                CurrentValue = result;
            }
            else
            {
                Validated = ValidatedOptions.Error;
                EditContext?.NotifyFieldChanged(FieldIdentifier);
                EditContext?.NotifyValidationStateChanged();
                CascadedFormGroup?.UpdateValidationState(Validated, validationErrorMessage);
            }
        }
    }

    protected EditContext EditContext { get; set; }

    /// For integration with <see cref="EditContext"/>
    /// https://chrissainty.com/creating-bespoke-input-components-for-blazor-from-scratch/
    protected internal FieldIdentifier FieldIdentifier
    {
        get;
        set;
    }

    protected virtual string FormatValueAsString(TValue value) => value?.ToString();

    protected abstract bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage);

    protected virtual void EditContextOnOnValidationStateChanged(object sender, ValidationStateChangedEventArgs e)
    {
        if (!EditContext.IsModified(FieldIdentifier))
        {
            return;
        }

        var messages = EditContext.GetValidationMessages(FieldIdentifier);
        Validated = messages.Any() ? ValidatedOptions.Error : null;
        CascadedFormGroup?.UpdateValidationState(Validated, Validated.HasValue ? messages.First() : null);

        StateHasChanged();
    }
}
