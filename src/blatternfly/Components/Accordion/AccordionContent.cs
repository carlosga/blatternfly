using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class AccordionContent : BaseComponent
    {
        /// Parent Accordion
        [CascadingParameter] public Accordion Parent { get; set; }

        /// Flag to show if the expanded content of the Accordion item is visible.
        [Parameter] public bool IsHidden { get; set; } = true;

        /// Flag to indicate Accordion content is fixed.
        [Parameter] public bool IsFixed { get; set; }

        /// Adds accessible text to the Accordion content.
        [Parameter] public string AriaLabel { get; set; }

        /// Component to use as content container.
        [Parameter] public string Component { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index         = 0;
            var fixedClass    = IsFixed ? "pf-m-fixed" : null;
            var expandedClass = !IsHidden ? "pf-m-expanded" : null;

            builder.OpenElement(index++, Component ?? Parent.ContentContainer);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-accordion__expanded-content {fixedClass} {expandedClass}");
            builder.AddAttribute(index++, "hidden", IsHidden);
            builder.AddAttribute(index++, "aria-label", AriaLabel);

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-accordion__expanded-content-body");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
