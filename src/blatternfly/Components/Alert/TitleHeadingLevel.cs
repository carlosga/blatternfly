namespace Blatternfly.Components;

public class TitleHeadingLevel : BaseComponent
{
    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h4;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, HeadingLevel.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
