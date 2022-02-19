namespace Blatternfly.Components;

public class HelperText : BaseComponent
{
    /// Component type of the helper text container.
    [Parameter] public HelperTextComponent Component { get; set; } = HelperTextComponent.div;

    private string CssClass => new CssBuilder("pf-c-helper-text")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
