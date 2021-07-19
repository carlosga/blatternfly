using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class SplitItem : LayoutBase
    {
        /// Flag indicating if this Split Layout item should fill the available horizontal space.
        [Parameter] public bool IsFilled { get; set; } = false;

        private string FillStyle => IsFilled ? "pf-m-fill" : string.Empty;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-l-split__item {FillStyle}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
