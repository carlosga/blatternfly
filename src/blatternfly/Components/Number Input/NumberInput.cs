using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class NumberInput<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputComponentBase<TValue>
    {
        private readonly static string _stepAttributeValue; // Null by default, so only allows whole numbers as per HTML spec

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
        [DisallowNull] public ElementReference Element { get; protected set; }

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

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var computedStyle = WidthChars.HasValue ? $"--pf-c-number-input--c-form-control--width-chars': {WidthChars}" : null;

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-number-input");
            builder.AddAttribute(index++, "style", computedStyle);

            if (Unit != null && UnitPosition == UnitPosition.Before)
            {
                index = BuildUnitRenderTree(builder, index);
            }

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-input-group");

            // Minus button
            if (ShowButtons)
            {
                index = BuildMinusButtonRenderTree(builder, index);
            }
            
            // Input element
            builder.OpenElement(index++, "input");
            builder.AddAttribute(index++, "step", _stepAttributeValue);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "type", "number");
            builder.AddAttribute(index++, "class", $"pf-c-form-control {ValidationClass}");
            builder.AddAttribute(index++, "aria-label", InputAriaLabel);
            builder.AddAttribute(index++, "required", IsRequired);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "readOnly", IsReadOnly);
            builder.AddAttribute(index++, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(index++, "oninput", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
            builder.CloseElement();

            // Plus Button
            if (ShowButtons)
            {
                BuildPlusButtonRenderTree(builder, index);
            }
            
            builder.CloseElement();

            if (Unit != null && UnitPosition == UnitPosition.After)
            {
                index = BuildUnitRenderTree(builder, index);
            }

            builder.CloseElement();
        }

        private int BuildPlusButtonRenderTree(RenderTreeBuilder builder, int index)
        {
            builder.OpenComponent<Button>(index++);
            builder.AddAttribute(index++, "Variant", ButtonVariant.Control);
            builder.AddAttribute(index++, "aria-label", PlusBtnAriaLabel);
            builder.AddAttribute(index++, "disabled", IsDisabled || IsReadOnly || Value.Equals(Max));
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
            builder.AddAttribute(index++, "aria-label", MinusBtnAriaLabel);
            builder.AddAttribute(index++, "disabled", IsDisabled || IsReadOnly || Value.Equals(Max));
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
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out result))
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
}
