using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Switch : InputComponentBase<bool>
    {
        public ElementReference Element { get; protected set; }

        /// Text value for the label when on.
        [Parameter] public RenderFragment Label { get; set; }

        /// Text value for the label when off.
        [Parameter] public RenderFragment LabelOff { get; set; }
        
        /// Adds accessible text to the Switch, and should describe the isChecked="true" state.
        /// When label is defined, aria-label should be set to the text string that is visible when isChecked is true.
        [Parameter] public string AriaLabel { get; set; } = "";
        
        /// Flag to reverse the layout of toggle and label (toggle on right).
        [Parameter] public bool IsReversed { get; set; }        

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            
            if (string.IsNullOrEmpty(InternalId))
            {
                throw new InvalidOperationException("Switch: id is required to make it accessible.");
            }            
            if (Label is null && AriaLabel is null) 
            {
                throw new InvalidOperationException("Switch: Switch requires either a label or an aria-label to be specified.");
            }            
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index             = 0;
            var reversedClass     = IsReversed ? "pf-m-reverse" : null;
            var isAriaLabelledBy  = string.IsNullOrEmpty(AriaLabel);
            var ariaLabelledByOn  = isAriaLabelledBy ? $"{InternalId}-on" : null;
            var ariaLabelledByOff = isAriaLabelledBy ? $"{InternalId}-off" : null;

            builder.OpenElement(index++, "label");
            builder.AddAttribute(index++, "class", $"pf-c-switch {reversedClass} {InternalCssClass}");
            builder.AddAttribute(index++, "for", InternalId);

            builder.OpenElement(index++, "input");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", "pf-c-switch__input");
            builder.AddAttribute(index++, "type", "checkbox");
            builder.AddAttribute(index++, "aria-invalid", AriaInvalid);
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "aria-labelledby", ariaLabelledByOn);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "checked", CurrentValue);
            builder.AddAttribute(index++, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
            builder.CloseElement();

            if (Label is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-switch__toggle");
                builder.CloseElement();
                
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-switch__label pf-m-on");
                builder.AddAttribute(index++, "id", ariaLabelledByOn);
                builder.AddAttribute(index++, "aria-hidden", "true");
                builder.AddContent(index++, Label);
                builder.CloseElement();

                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-switch__label pf-m-off");
                builder.AddAttribute(index++, "id", ariaLabelledByOff);
                builder.AddAttribute(index++, "aria-hidden", "true");
                if (LabelOff is not null)
                {
                    builder.AddContent(index++, LabelOff);
                }
                else
                {
                    builder.AddContent(index++, Label);
                }
                builder.CloseElement();
            }
            else
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-switch__toggle");
                
                builder.OpenElement(index++, "div");
                builder.AddAttribute(index++, "class", "pf-c-switch__toggle-icon");
                builder.AddAttribute(index++, "aria-hidden", "true");
                
                builder.OpenComponent<CheckIcon>(index++);
                builder.AddAttribute(index++, "NoVerticalAlign", true);
                builder.CloseComponent();
                
                builder.CloseElement();
                
                builder.CloseElement();
            }
            
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
            => throw new NotSupportedException();
    }
}
