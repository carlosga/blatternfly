using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class SkipToContent : BaseComponent
    {
        /// The skip to content link.
        [Parameter] public string Href { get; set; }

        /// Forces the skip to component to display. This is primarily for demonstration purposes and would not normally be used. */
        [Parameter] public bool Show { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index      = 0;
            var focusClass = Show ? "pf-m-focus" : null;

            builder.OpenElement(index++, "a");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "href", Href);
            builder.AddAttribute(index++, "class", $"pf-c-skip-to-content pf-c-button pf-m-primary {focusClass} {VisibilityClass}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
