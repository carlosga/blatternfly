namespace Blatternfly.Components;

public class TextListItem : BaseComponent
{
    /// The text list item component.
    [Parameter] public TextListItemVariants Component { get; set; } = TextListItemVariants.li;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "data-pf-content", "true");
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
