using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class SplitItem : LayoutBase
    {
        /// Flag indicating if this Split Layout item should fill the available horizontal space.
        [Parameter] public bool IsFilled { get; set; }

        private CssBuilder CssClass => new CssBuilder("pf-l-split__item")
            .AddClass("pf-m-fill", IsFilled);
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
