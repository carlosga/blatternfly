using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Checkbox : InputComponentBase<bool>
    {
        public ElementReference Element { get; protected set; }

        /// Label text of the checkbox.
        [Parameter] public string Label { get; set; }

        /// Aria-label of the checkbox.
        [Parameter] public string AriaLabel { get; set; }
        
        /// Description text of the checkbox.
        [Parameter] public RenderFragment Description { get; set; }

        /// Description text of the checkbox.
        [Parameter] public RenderFragment Body { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            
            if (string.IsNullOrEmpty(InternalId))
            {
                throw new InvalidOperationException("Checkbox: id is required to make input accessible.");
            }            
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", $"pf-c-check {InternalCssClass}");

            builder.OpenElement(index++, "input");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", "pf-c-check__input");
            builder.AddAttribute(index++, "type", "checkbox");
            builder.AddAttribute(index++, "aria-invalid", AriaInvalid);
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "checked", CurrentValue);
            builder.AddAttribute(index++, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
            builder.CloseElement();

            if (!string.IsNullOrEmpty(Label))
            {
                builder.OpenElement(index++, "label");
                builder.AddAttribute(index++, "class", $"pf-c-check__label {DisabledClass}");
                if (!string.IsNullOrEmpty(InternalId))
                {
                    builder.AddAttribute(index++, "for", InternalId);
                }
                builder.AddContent(index++, Label);
                builder.CloseElement();
            }

            if (Description is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-check__description");
                builder.AddContent(index++, Description);
                builder.CloseElement();
            }

            if (Body is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-check__body");
                builder.AddContent(index++, Body);
                builder.CloseElement();
            }

            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
            => throw new NotSupportedException();
    }
}
