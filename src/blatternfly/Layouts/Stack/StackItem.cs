using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class StackItem : LayoutBase
    {
        /// Flag indicating if this Stack Layout item should fill the available vertical space.
        [Parameter] public bool IsFilled { get; set; } = false;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 0;
            var fillStyle = IsFilled ? "pf-m-fill" : string.Empty;


            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-l-stack__item {fillStyle}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
