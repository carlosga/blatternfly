namespace Blatternfly.Layouts;

public class SplitItem : LayoutBase
{
    /// Flag indicating if this Split Layout item should fill the available horizontal space.
    [Parameter] public bool IsFilled { get; set; }

    private string CssClass => new CssBuilder("pf-l-split__item")
        .AddClass("pf-m-fill", IsFilled)
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
