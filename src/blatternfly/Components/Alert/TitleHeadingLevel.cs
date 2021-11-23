namespace Blatternfly.Components;

public class TitleHeadingLevel : BaseComponent
{
    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h4;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, HeadingLevel.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", InternalCssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
