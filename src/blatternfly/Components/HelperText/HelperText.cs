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
        builder.OpenElement(0, Component.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
