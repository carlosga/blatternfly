using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts;

public class Level : LayoutBase
{
    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    private CssBuilder CssClass => new CssBuilder("pf-l-level")
        .AddClass("pf-m-gutter", HasGutter);

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "div");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
