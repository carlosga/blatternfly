using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Radio : InputComponentBase<string>
    {
        [DisallowNull] public ElementReference Element { get; protected set; }

        /// Flag to show if the radio label is wrapped on small screen.
        [Parameter] public bool IsLabelWrapped { get; set; }

        /// Flag to show if the radio label is shown before the radio button.
        [Parameter] public bool IsLabelBeforeButton { get; set; }

        /// Flag to show if the radio is checked.
        [Parameter] public bool DefaultChecked { get; set; }

        /// Flag to show if the radio is checked.
        [Parameter] public bool? Checked { get; set; }

        /// Flag to show if the radio is checked.
        [Parameter] public bool? IsChecked { get; set; }

        /// Flag to show if the radio selection is valid or invalid.
        [Parameter] public bool IsValid { get; set; }

        /// Label text of the radio.
        [Parameter] public RenderFragment Label { get; set; }

        /// Description text of the radio.
        [Parameter] public string Description { get; set; }

        /// Body of the radio.
        [Parameter] public RenderFragment Body { get; set; }

        /// Flag to show if the radio is read only.
        [Parameter] public bool IsReadOnly { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-radio");

            if (IsLabelBeforeButton)
            {
                BuildLabelRenderTree(builder, index);
                BuildInputRenderTree(builder, index);
            }
            else
            {
                BuildLabelRenderTree(builder, index);
                BuildInputRenderTree(builder, index);
            }

            if (!string.IsNullOrEmpty(Description))
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-radio__description");
                builder.AddContent(index++, Description);
                builder.CloseElement();
            }

            if (Body is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-radio__body");
                builder.AddContent(index++, Body);
                builder.CloseElement();
            }

            builder.CloseElement();
        }

        private void BuildLabelRenderTree(RenderTreeBuilder builder, int index)
        {
            if (Label is not null && IsLabelWrapped)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", $"pf-c-radio__label {DisabledClass}");
                builder.AddContent(index++, Label);
                builder.CloseElement();
            }
            else if (Label is not null)
            {
                builder.OpenElement(index++, "label");
                builder.AddAttribute(index++, "class", $"pf-c-radio__label {DisabledClass}");
                builder.AddAttribute(index++, "htmlFor", InternalId);
                builder.AddContent(index++, Label);
                builder.CloseElement();
            }
        }

        private void BuildInputRenderTree(RenderTreeBuilder builder, int index)
        {
            builder.OpenElement(index++, "input");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", "pf-c-radio__input");
            builder.AddAttribute(index++, "type", "radio");
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "aria-invalid", AriaInvalid);
            builder.AddAttribute(index++, "required", IsRequired);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "readOnly", IsReadOnly);
            builder.AddAttribute(index++, "value", BindConverter.FormatValue(Value));
            builder.AddAttribute(index++, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddElementReferenceCapture(5, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
