using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Level : LayoutBase
    {
        /// Adds space between children.
        [Parameter] public bool HasGutters { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index       = 0;
            var gutterClass = HasGutters ? "pf-m-gutter" : string.Empty;

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-l-level {gutterClass}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
