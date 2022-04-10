namespace Blatternfly.Layouts;

public class Level : LayoutBase
{
    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    private string CssClass => new CssBuilder("pf-l-level")
        .AddClass("pf-m-gutter", HasGutter)
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
