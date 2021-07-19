using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Split : LayoutBase
    {
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        /// Adds space between children.
        [Parameter] public bool HasGutter { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index       = 0;
            var gutterClass = HasGutter ? "pf-m-gutter" : string.Empty;

            builder.OpenElement(index++, Component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-l-split {gutterClass}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
