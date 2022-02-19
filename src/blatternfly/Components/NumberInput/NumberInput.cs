using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Blatternfly.Components;

public class NumberInput<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue>
    : InputComponentBase<TValue>
{
    private static readonly string _stepAttributeValue; // Null by default, so only allows whole numbers as per HTML spec

    static NumberInput()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
        if (targetType == typeof(int)
         || targetType == typeof(long)
         || targetType == typeof(short)
         || targetType == typeof(float)
         || targetType == typeof(double)
         || targetType == typeof(decimal))
        {
            _stepAttributeValue = "any";
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
    [Parameter] public bool ShowButtons { get; set; } = true;

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
        var index = 0;

        builder.OpenElement(index++, "div");
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass);
        builder.AddAttribute(index++, "style", CssStyle);

        if (Unit is not null && UnitPosition == UnitPosition.Before)
        {
            index = BuildUnitRenderTree(builder, index);
        }

        builder.OpenComponent<InputGroup>(index++);
        builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            // Minus button
            if (ShowButtons)
            {
                index = BuildMinusButtonRenderTree(innerBuilder, index);
            }

            // Input element
            innerBuilder.OpenElement(index++, "input");
            innerBuilder.AddAttribute(index++, "step"       , _stepAttributeValue);
            innerBuilder.AddAttribute(index++, "type"       , "number");
            innerBuilder.AddAttribute(index++, "class"      , FormControlCssClass);
            innerBuilder.AddAttribute(index++, "aria-label" , InputAriaLabel);
            innerBuilder.AddAttribute(index++, "required"   , IsRequired);
            innerBuilder.AddAttribute(index++, "disabled"   , IsDisabled);
            innerBuilder.AddAttribute(index++, "readOnly"   , IsReadOnly);
            innerBuilder.AddAttribute(index++, "value"      , BindConverter.FormatValue(CurrentValueAsString));
            innerBuilder.AddAttribute(index++, "oninput"    , EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            innerBuilder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
            innerBuilder.CloseElement();

            // Plus Button
            if (ShowButtons)
            {
                BuildPlusButtonRenderTree(innerBuilder, index);
            }
        });

        builder.CloseComponent();

        if (Unit is not null && UnitPosition == UnitPosition.After)
        {
            _ = BuildUnitRenderTree(builder, index);
        }

        builder.CloseElement();
    }

    private int BuildPlusButtonRenderTree(RenderTreeBuilder builder, int index)
    {
        builder.OpenComponent<Button>(index++);
        builder.AddAttribute(index++, "Variant", ButtonVariant.Control);
        builder.AddAttribute(index++, "AriaLabel", PlusBtnAriaLabel);
        builder.AddAttribute(index++, "IsDisabled", IsDisabled || IsReadOnly || Value.Equals(Max));
        builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnPlus));
        builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
        {
            rfbuilder.OpenElement(index++, "span");
            rfbuilder.AddAttribute(index++, "class", "pf-c-number-input__icon");
            rfbuilder.OpenComponent<PlusIcon>(index++);
            rfbuilder.AddAttribute(index++, "aria-hidden", "true");
            rfbuilder.CloseComponent();
            rfbuilder.CloseElement();
        });
        builder.CloseComponent();

        return index;
    }

    private int BuildMinusButtonRenderTree(RenderTreeBuilder builder, int index)
    {
        builder.OpenComponent<Button>(index++);
        builder.AddAttribute(index++, "Variant", ButtonVariant.Control);
        builder.AddAttribute(index++, "AriaLabel", MinusBtnAriaLabel);
        builder.AddAttribute(index++, "IsDisabled", IsDisabled || IsReadOnly || Value.Equals(Min));
        builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnMinus));
        builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
        {
            rfbuilder.OpenElement(index++, "span");
            rfbuilder.AddAttribute(index++, "class", "pf-c-number-input__icon");
            rfbuilder.OpenComponent<MinusIcon>(index++);
            rfbuilder.AddAttribute(index++, "aria-hidden", "true");
            rfbuilder.CloseComponent();
            rfbuilder.CloseElement();
        });
        builder.CloseComponent();

        return index;
    }

    private int BuildUnitRenderTree(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index++, "div");
        builder.AddAttribute(index++, "class", "pf-c-number-input__unit");
        builder.AddContent(index++, Unit);
        builder.CloseElement();

        return index;
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
