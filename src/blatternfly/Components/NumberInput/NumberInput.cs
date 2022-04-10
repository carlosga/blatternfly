// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Blatternfly.Components;

/// Partially based on Blazor source code.
/// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputNumber.cs
public class NumberInput<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputComponentBase<TValue>
{
    private static readonly string _stepAttributeValue = GetStepAttributeValue();

    private static string GetStepAttributeValue()
    {
        // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
        // of it for us. We will only get asked to parse the T for nonempty inputs.
        var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
        if (targetType == typeof(int) ||
            targetType == typeof(long) ||
            targetType == typeof(short) ||
            targetType == typeof(float) ||
            targetType == typeof(double) ||
            targetType == typeof(decimal))
        {
            return "any";
        }
        else
        {
            throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
        }
    }

    /// Gets or sets the associated <see cref="ElementReference"/>.
    public ElementReference Element { get; protected set; }

    /// Gets or sets the error message used when displaying an a parsing error.
    [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";

    /// Sets the width of the number input to a number of characters.
    [Parameter] public int? WidthChars { get; set; }

    /// Callback for the minus button.
    [Parameter] public EventCallback<MouseEventArgs> OnMinus { get; set; }

    /// Callback for the plus button.
    [Parameter] public EventCallback<MouseEventArgs> OnPlus { get; set; }

    /// Adds the given unit to the number input.
    [Parameter] public RenderFragment Unit { get; set; }

    /// Position of the number input unit in relation to the number input.
    [Parameter] public UnitPosition UnitPosition { get; set; } = UnitPosition.After;

    /// Minimum value of the number input, disabling the minus button when reached.
    [Parameter] public TValue Min { get; set; }

    /// Maximum value of the number input, disabling the plus button when reached.
    [Parameter] public TValue Max { get; set; }

    /// Name of the input.
    [Parameter] public string InputName { get; set; }

    /// Aria label of the input.
    [Parameter] public string InputAriaLabel { get; set; } = "Input";

    /// Aria label of the minus button.
    [Parameter] public string MinusBtnAriaLabel { get; set; } = "Minus";

    /// Aria label of the plus button.
    [Parameter] public string PlusBtnAriaLabel { get; set; } = "Plus";

    /// Flag to show if the number input is read only.
    [Parameter] public bool IsReadOnly { get; set; }

    /// Flag to to show or hide the minus and plus buttons.
    [Parameter] public NumberInputVariant Variant { get; set; } = NumberInputVariant.Default;

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-number-input--c-form-control--width-chars", WidthChars, WidthChars.HasValue)
        .Build();

    private string CssClass => new CssBuilder("pf-c-number-input")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string FormControlCssClass => new CssBuilder("pf-c-form-control")
        .AddClass(ValidationClass)
        .Build();

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "style", CssStyle);

        if (Unit is not null && UnitPosition is UnitPosition.Before)
        {
            builder.OpenElement(4, "div");
            builder.AddAttribute(5, "class", "pf-c-number-input__unit");
            builder.AddContent(6, Unit);
            builder.CloseElement();
        }

        builder.OpenComponent<InputGroup>(7);
        builder.AddAttribute(8, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            // Minus button
            if (Variant is NumberInputVariant.Default)
            {
                innerBuilder.OpenComponent<Button>(9);
                innerBuilder.AddAttribute(10, "Variant", ButtonVariant.Control);
                innerBuilder.AddAttribute(11, "AriaLabel", MinusBtnAriaLabel);
                innerBuilder.AddAttribute(12, "IsDisabled", IsDisabled || IsReadOnly || Value.Equals(Min));
                innerBuilder.AddAttribute(13, "OnClick", EventCallback.Factory.Create(this, OnMinus));
                innerBuilder.AddAttribute(14, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder __innerBuilder)
                {
                    __innerBuilder.OpenElement(15, "span");
                    __innerBuilder.AddAttribute(16, "class", "pf-c-number-input__icon");
                    __innerBuilder.OpenComponent<MinusIcon>(17);
                    __innerBuilder.AddAttribute(18, "aria-hidden", "true");
                    __innerBuilder.CloseComponent();
                    __innerBuilder.CloseElement();
                });
                innerBuilder.CloseComponent();
            }

            // Input element
            innerBuilder.OpenElement(19, "input");
            innerBuilder.AddAttribute(20, "step"        , _stepAttributeValue);
            innerBuilder.AddAttribute(21, "type"        , "number");
            innerBuilder.AddAttribute(22, "class"       , FormControlCssClass);
            innerBuilder.AddAttribute(23, "aria-label"  , InputAriaLabel);
            innerBuilder.AddAttribute(24, "aria-invalid", AriaInvalid);
            innerBuilder.AddAttribute(25, "required"    , IsRequired);
            innerBuilder.AddAttribute(26, "disabled"    , IsDisabled);
            innerBuilder.AddAttribute(27, "readOnly"    , IsReadOnly);
            innerBuilder.AddAttribute(28, "value"       , BindConverter.FormatValue(CurrentValueAsString));
            innerBuilder.AddAttribute(29, "onchange"    , EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            innerBuilder.AddElementReferenceCapture(30, __inputReference => Element = __inputReference);
            innerBuilder.CloseElement();

            // Plus Button
            if (Variant is NumberInputVariant.Default)
            {
                innerBuilder.OpenComponent<Button>(31);
                innerBuilder.AddAttribute(32, "Variant", ButtonVariant.Control);
                innerBuilder.AddAttribute(33, "AriaLabel", PlusBtnAriaLabel);
                innerBuilder.AddAttribute(34, "IsDisabled", IsDisabled || IsReadOnly || Value.Equals(Max));
                innerBuilder.AddAttribute(35, "OnClick", EventCallback.Factory.Create(this, OnPlus));
                innerBuilder.AddAttribute(36, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder __innerBuilder)
                {
                    __innerBuilder.OpenElement(37, "span");
                    __innerBuilder.AddAttribute(38, "class", "pf-c-number-input__icon");
                    __innerBuilder.OpenComponent<PlusIcon>(39);
                    __innerBuilder.AddAttribute(40, "aria-hidden", "true");
                    __innerBuilder.CloseComponent();
                    __innerBuilder.CloseElement();
                });
                innerBuilder.CloseComponent();
            }
        });

        builder.CloseComponent();

        if (Unit is not null && UnitPosition is UnitPosition.After)
        {
            builder.OpenElement(41, "div");
            builder.AddAttribute(42, "class", "pf-c-number-input__unit");
            builder.AddContent(43, Unit);
            builder.CloseElement();
        }

        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
        {
            validationErrorMessage = null;
            return true;
        }
        else
        {
            validationErrorMessage = string.Format(CultureInfo.InvariantCulture, ParsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
            return false;
        }
    }

    protected override string FormatValueAsString(TValue value)
    {
        return value switch
        {
            null               => null,
            int intValue       => BindConverter.FormatValue(intValue, CultureInfo.InvariantCulture),
            long longValue     => BindConverter.FormatValue(longValue, CultureInfo.InvariantCulture),
            short shortValue   => BindConverter.FormatValue(shortValue, CultureInfo.InvariantCulture),
            float floatValue   => BindConverter.FormatValue(floatValue, CultureInfo.InvariantCulture),
            double doubleValue => BindConverter.FormatValue(doubleValue, CultureInfo.InvariantCulture),
            decimal decValue   => BindConverter.FormatValue(decValue, CultureInfo.InvariantCulture),
            _                  => throw new NotSupportedException($"Unsupported type {value.GetType()}")
        };
    }
}
