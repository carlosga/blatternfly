// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Blatternfly.Components;

/// <summary>
/// Partially based on Blazor source code.
/// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputNumber.cs
/// </summary>
public class NumberInput<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputComponentBase<TValue>
{
    private static readonly string _stepAttributeValue = GetStepAttributeValue();

    private static string GetStepAttributeValue()
    {
        // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
        // of it for us. We will only get asked to parse the T for nonempty inputs.
        var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
        if (targetType == typeof(int)
         || targetType == typeof(long)
         || targetType == typeof(short)
         || targetType == typeof(float)
         || targetType == typeof(double)
         || targetType == typeof(decimal))
        {
            return "any";
        }
        else
        {
            throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
        }
    }

    public ElementReference Element { get; protected set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating whether the Form Control is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating whether the form control is required.</summary>
    [Parameter] public bool IsRequired { get; set; }

    /// <summary>Gets or sets the error message used when displaying an a parsing error.</summary>
    [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";

    /// <summary>Sets the width of the number input to a number of characters.</summary>
    [Parameter] public int? WidthChars { get; set; }

    /// <summary>Callback for the minus button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnMinus { get; set; }

    /// <summary>Callback function when text input is blurred (focus leaves).</summary>
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }

    /// <summary>Callback for the plus button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnPlus { get; set; }

    /// <summary>Adds the given unit to the number input.</summary>
    [Parameter] public RenderFragment Unit { get; set; }

    /// <summary>Position of the number input unit in relation to the number input.</summary>
    [Parameter] public UnitPosition UnitPosition { get; set; } = UnitPosition.After;

    /// <summary>Minimum value of the number input, disabling the minus button when reached.</summary>
    [Parameter] public TValue Min { get; set; }

    /// <summary>Maximum value of the number input, disabling the plus button when reached.</summary>
    [Parameter] public TValue Max { get; set; }

    /// <summary>Name of the input.</summary>
    [Parameter] public string InputName { get; set; }

    /// <summary>Aria label of the input.</summary>
    [Parameter]
    public string InputAriaLabel { get; set; } = "Input";

    /// <summary>Aria label of the minus button.</summary>
    [Parameter] public string MinusBtnAriaLabel { get; set; } = "Minus";

    /// <summary>Aria label of the plus button.</summary>
    [Parameter] public string PlusBtnAriaLabel { get; set; } = "Plus";

    /// <summary>Flag to show if the number input is read only.</summary>
    [Parameter] public bool IsReadOnly { get; set; }

    /// <summary>Flag to to show or hide the minus and plus buttons.</summary>
    [Parameter]
    public NumberInputVariant Variant { get; set; } = NumberInputVariant.Default;

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
            innerBuilder.AddAttribute(31, "onblur"      , EventCallback.Factory.Create(this, OnBlur));
            innerBuilder.AddElementReferenceCapture(31, __inputReference => Element = __inputReference);
            innerBuilder.CloseElement();

            // Plus Button
            if (Variant is NumberInputVariant.Default)
            {
                innerBuilder.OpenComponent<Button>(32);
                innerBuilder.AddAttribute(33, "Variant", ButtonVariant.Control);
                innerBuilder.AddAttribute(34, "AriaLabel", PlusBtnAriaLabel);
                innerBuilder.AddAttribute(35, "IsDisabled", IsDisabled || IsReadOnly || Value.Equals(Max));
                innerBuilder.AddAttribute(36, "OnClick", EventCallback.Factory.Create(this, OnPlus));
                innerBuilder.AddAttribute(37, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder __innerBuilder)
                {
                    __innerBuilder.OpenElement(38, "span");
                    __innerBuilder.AddAttribute(39, "class", "pf-c-number-input__icon");
                    __innerBuilder.OpenComponent<PlusIcon>(40);
                    __innerBuilder.AddAttribute(41, "aria-hidden", "true");
                    __innerBuilder.CloseComponent();
                    __innerBuilder.CloseElement();
                });
                innerBuilder.CloseComponent();
            }
        });

        builder.CloseComponent();

        if (Unit is not null && UnitPosition is UnitPosition.After)
        {
            builder.OpenElement(42, "div");
            builder.AddAttribute(43, "class", "pf-c-number-input__unit");
            builder.AddContent(44, Unit);
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
