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
            var focusClass = Show ? "pf-m-focus" : null;

            builder.OpenElement(1, "a");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "href", Href);
            builder.AddAttribute(4, "class", $"pf-c-skip-to-content pf-c-button pf-m-primary {focusClass}");
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}
