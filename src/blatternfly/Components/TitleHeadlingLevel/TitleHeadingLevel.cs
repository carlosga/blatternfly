namespace Blatternfly.Components;

public class TitleHeadingLevel : BaseComponent
{
    public ElementReference Element { get; protected set; }

    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h4;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, HeadingLevel.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddContent(2, ChildContent);
        builder.AddElementReferenceCapture(3, __reference => Element = __reference);
        builder.CloseElement();
    }
}
