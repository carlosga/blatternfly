namespace Blatternfly.Layouts;

public class Bullseye : LayoutBase
{
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-l-bullseye")
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
