using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Stack : LayoutBase
    {
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        /// Adds space between children.
        [Parameter] public bool HasGutter { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var gutterClass = HasGutter ? "pf-m-gutter" : null;

            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-stack {gutterClass}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
