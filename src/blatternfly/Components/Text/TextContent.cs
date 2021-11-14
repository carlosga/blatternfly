namespace Blatternfly.Components;

public class TextContent : BaseComponent
{
    /// Flag to indicate the all links in a the content block have visited styles applied if the browser determines the link has been visited.
    [Parameter] public bool IsVisited { get; set; }

    private CssBuilder CssClass => new CssBuilder("pf-c-content")
        .AddClass("pf-m-visited", IsVisited);
            
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "div");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
