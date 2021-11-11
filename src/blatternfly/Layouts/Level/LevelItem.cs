using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts;

public class LevelItem : LayoutBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "div");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", InternalCssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
