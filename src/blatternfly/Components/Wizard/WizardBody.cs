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

        private CssBuilder MainBodyCssClass => new CssBuilder("pf-c-wizard__main-body")
            .AddClass("pf-m-no-padding", HasNoBodyPadding);
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, MainComponent);
            builder.AddAttribute(2, "class", "pf-c-wizard__main");
            builder.AddAttribute(3, "aria-label", AriaLabel);
            builder.AddAttribute(4, "aria-labelledby", AriaLabelledby);
            builder.AddMultipleAttributes(5, AdditionalAttributes);

            builder.OpenElement(6, "div");
            builder.AddAttribute(7, "class", MainBodyCssClass);
            builder.AddContent(8, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
