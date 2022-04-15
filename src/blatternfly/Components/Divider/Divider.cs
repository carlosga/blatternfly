namespace Blatternfly.Components;

public class Divider : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// The component type to use.
    [Parameter] public DividerVariant Component { get; set; } = DividerVariant.hr;

    /// Flag to indicate the divider is vertical (must be in a flex layout).
    [Parameter] public bool IsVertical { get; set; }

    /// Insets at various breakpoints.
    [Parameter] public InsetModifiers Inset { get; set; }

    private string CssClass => new CssBuilder("pf-c-divider")
        .AddClass("pf-m-vertical", IsVertical)
        .AddClass(Inset?.CssClass())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        if (Component is not DividerVariant.hr)
        {
            builder.AddAttribute(3, "role", "separator");
        }
        builder.CloseElement();
    }
}
