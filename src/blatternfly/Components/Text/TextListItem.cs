namespace Blatternfly.Components;

public class TextListItem : BaseComponent
{
    /// The text list item component.
    [Parameter] public TextListItemVariants Component { get; set; } = TextListItemVariants.li;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "data-pf-content", "true");
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
