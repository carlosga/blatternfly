namespace Blatternfly.Components;

public class Divider : BaseComponent
{
    /// The component type to use.
    [Parameter] public DividerVariant Component { get; set; } = DividerVariant.hr;

    /// Flag to indicate the divider is vertical (must be in a flex layout).
    [Parameter] public bool IsVertical { get; set; }

    /// Insets at various breakpoints.
    [Parameter] public Inset Inset { get; set; }

    private string CssClass => new CssBuilder("pf-c-divider")
        .AddClass("pf-m-vertical", IsVertical)
        .AddClass(Inset?.CssClass)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component.ToString());
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        if (Component != DividerVariant.hr)
        {
            builder.AddAttribute(4, "role", "separator");
        }
        builder.CloseElement();
    }
}
