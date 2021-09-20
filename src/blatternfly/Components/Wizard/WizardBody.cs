using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class WizardBody : BaseComponent
    {
        /// Set to true to remove the default body padding.
        [Parameter] public bool HasNoBodyPadding { get; set; }

        /// An aria-label to use for the main element.
        [Parameter] public string AriaLabel { get; set; }

        /// Sets the aria-labelledby attribute for the main element.
        [Parameter] public string AriaLabelledby { get; set; }

        /// Component used as the primary content container.
        [Parameter] public string MainComponent { get; set; } = "div";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var paddingClass = HasNoBodyPadding ? "pf-m-no-padding" : null;

            builder.OpenElement(index++, MainComponent);
            builder.AddAttribute(index++, "class", "pf-c-wizard__main");
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "aria-labelledby", AriaLabelledby);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", $"pf-c-wizard__main-body {paddingClass}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
