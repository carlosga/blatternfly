namespace Blatternfly.Layouts;

public class StackItem : LayoutBase
{
    /// Flag indicating if this Stack Layout item should fill the available vertical space.
    [Parameter] public bool IsFilled { get; set; }

    private string CssClass => new CssBuilder("pf-l-stack__item")
        .AddClass("pf-m-fill", IsFilled)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "div");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
