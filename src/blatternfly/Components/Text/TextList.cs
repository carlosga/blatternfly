namespace Blatternfly.Components;

public class TextList : BaseComponent
{
    /// The text list component.
    [Parameter] public TextListVariants Component { get; set; } = TextListVariants.ul;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "data-pf-content", "true");
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
