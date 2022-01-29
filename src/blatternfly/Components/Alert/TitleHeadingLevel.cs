namespace Blatternfly.Components;

public class TitleHeadingLevel : BaseComponent
{
    public ElementReference Element { get; protected set; }

    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h4;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, HeadingLevel.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddContent(3, ChildContent);
        builder.AddElementReferenceCapture(4, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }
}
