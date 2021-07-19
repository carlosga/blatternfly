using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class FormSelect<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputComponentBase<TValue>
    {
        [DisallowNull] public ElementReference Element { get; protected set; }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, "select");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-form-control {ValidationClass}");
            builder.AddAttribute(index++, "aria-invalid", AriaInvalid);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "required", IsRequired);
            builder.AddAttribute(index++, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(index++, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddElementReferenceCapture(index++, __selectReference => Element = __selectReference);
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var parsedValue))
            {
                result = parsedValue;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage = $"The {DisplayName ?? FieldIdentifier.FieldName} field is not valid.";
                return false;
            }
        }
    }
}
