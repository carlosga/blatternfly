namespace Blatternfly.Components;

public class TextContent : BaseComponent
{
    /// Flag to indicate the all links in a the content block have visited styles applied if the browser determines the link has been visited.
    [Parameter] public bool IsVisited { get; set; }

    private string CssClass => new CssBuilder("pf-c-content")
        .AddClass("pf-m-visited", IsVisited)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
