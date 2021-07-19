using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class GalleryItem : LayoutBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
