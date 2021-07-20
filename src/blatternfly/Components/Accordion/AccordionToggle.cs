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
            var expandedClass = IsExpanded ? "pf-m-expanded" : null;

            builder.OpenElement(1, Component ?? Parent.ToggleContainer);

            builder.OpenElement(2, "button");
            builder.AddMultipleAttributes(3, AdditionalAttributes);
            builder.AddAttribute(4, "class", $"pf-c-accordion__toggle {expandedClass}");
            builder.AddAttribute(5, "aria-expanded", IsExpanded);
            builder.AddAttribute(6, "onclick", EventCallback.Factory.Create(this, OnToggle));
            builder.AddEventStopPropagationAttribute(7, "onclick", true);

            builder.OpenElement(8, "span");
            builder.AddAttribute(9, "class", "pf-c-accordion__toggle-text");
            builder.AddContent(10, ChildContent);
            builder.CloseElement();

            builder.OpenElement(11, "span");
            builder.AddAttribute(12, "class", "pf-c-accordion__toggle-icon");

            builder.OpenComponent<AngleRightIcon>(13);
            builder.CloseComponent();

            builder.CloseElement();

            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
