namespace Blatternfly.Layouts;

public class Stack : LayoutBase
{
    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    private string CssClass => new CssBuilder("pf-l-stack")
        .AddClass("pf-m-gutter", HasGutter)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
