using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Bullseye : LayoutBase
    {
        [Parameter] public string Component { get; set; } = "div";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-bullseye {InternalCssClass}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
