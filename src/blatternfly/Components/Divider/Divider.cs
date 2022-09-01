namespace Blatternfly.Components;

public class Divider : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// The component type to use.
    /// </summary>
    [Parameter] public DividerVariant Component { get; set; } = DividerVariant.hr;

    /// <summary>
    /// Insets at various breakpoints.
    /// </summary>
    [Parameter] public InsetModifiers Inset { get; set; }

    /// <summary>
    /// Indicates how the divider will display at various breakpoints. Vertical divider must be in a flex layout.
    /// </summary>
    [Parameter] public OrientationModifiers Orientation { get; set; }

    private string CssClass => new CssBuilder("pf-c-divider")
        .AddClass(Inset?.CssClass())
        .AddClass(Orientation?.CssClass())
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
