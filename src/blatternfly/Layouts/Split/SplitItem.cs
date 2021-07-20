using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class SplitItem : LayoutBase
    {
        /// Flag indicating if this Split Layout item should fill the available horizontal space.
        [Parameter] public bool IsFilled { get; set; } = false;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var fillStyle = IsFilled ? "pf-m-fill" : null;

            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-split__item {fillStyle}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
