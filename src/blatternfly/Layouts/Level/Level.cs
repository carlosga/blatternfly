using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Level : LayoutBase
    {
        /// Adds space between children.
        [Parameter] public bool HasGutter { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var gutterClass = HasGutter ? "pf-m-gutter" : null;

            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-level {gutterClass}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
