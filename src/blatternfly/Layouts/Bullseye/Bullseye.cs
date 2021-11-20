namespace Blatternfly.Layouts;

public class Bullseye : LayoutBase
{
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-l-bullseye")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
