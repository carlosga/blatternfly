using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class GalleryItem : LayoutBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddContent(3, ChildContent);
            builder.CloseElement();
        }
    }
}
