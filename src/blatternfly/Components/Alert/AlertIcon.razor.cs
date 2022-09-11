namespace Blatternfly.Components;

public partial class AlertIcon
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Variant.
    /// </summary>
    [Parameter] public AlertIconVariants Variant { get; set; }

    /// <summary>
    /// A custom icon. If not set the icon is set according to the variant.
    /// </summary>
    [Parameter] public RenderFragment CustomIcon { get; set; }

    private string CssClass => new CssBuilder("pf-c-alert__icon")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
