using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components;

public class CardFooter : BaseComponent
{
    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    private CssBuilder CssClass => new CssBuilder("pf-c-card__footer")
        .AddClassFromAttributes(AdditionalAttributes);
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
