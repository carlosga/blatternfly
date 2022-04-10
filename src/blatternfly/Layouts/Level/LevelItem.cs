namespace Blatternfly.Layouts;

public class LevelItem : LayoutBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddContent(2, ChildContent);
        builder.CloseElement();
    }
}
