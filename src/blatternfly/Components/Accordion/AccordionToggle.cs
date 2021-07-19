using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class AccordionToggle : BaseComponent
    {
        /// Parent Accordion
        [CascadingParameter] public Accordion Parent { get; set; }

        /// Flag to show if the expanded content of the Accordion item is visible.
        [Parameter] public bool IsExpanded { get; set; } = false;

        /// Container to override the default for toggle.
        [Parameter] public string Component { get; set; }

        [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index         = 0;
            var expandedClass = IsExpanded ? "pf-m-expanded" : null;

            builder.OpenElement(index++, Component ?? Parent.ToggleContainer);

            builder.OpenElement(index++, "button");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-accordion__toggle {expandedClass}");
            builder.AddAttribute(index++, "aria-expanded", IsExpanded);
            builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnToggle));
            builder.AddEventStopPropagationAttribute(index++, "onclick", true);

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-accordion__toggle-text");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-accordion__toggle-icon");

            builder.OpenComponent<AngleRightIcon>(index++);
            builder.CloseComponent();

            builder.CloseElement();

            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
