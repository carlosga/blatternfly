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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "select");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-form-control {ValidationClass}");
            builder.AddAttribute(4, "aria-invalid", AriaInvalid);
            builder.AddAttribute(5, "disabled", IsDisabled);
            builder.AddAttribute(6, "required", IsRequired);
            builder.AddAttribute(7, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(8, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddElementReferenceCapture(9, __selectReference => Element = __selectReference);
            builder.AddContent(10, ChildContent);
            builder.CloseElement();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            
            if (string.IsNullOrEmpty(InternalId) && string.IsNullOrEmpty(AriaLabel)) 
            {
                throw new InvalidOperationException("FormSelect requires either an id or aria-label to be specified.");
            }            
        }

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
