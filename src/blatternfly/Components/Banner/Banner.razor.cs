namespace Blatternfly.Components;

public partial class Banner
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Variant styles for the banner.
    /// </summary>
    [Parameter]
    public BannerVariant Variant { get; set; } = BannerVariant.Default;

    /// <summary>
    /// If set to true, the banner sticks to the top of its container.
    /// </summary>
    [Parameter]
    public bool IsSticky { get; set; }

    /// <summary>
    /// Text announced by screen readers to indicate the type of banner.
    /// Defaults to "${variant} banner" if this prop is not passed in.
    /// </summary>
    [Parameter]
    public string ScreenReaderText { get; set; }

    private string CssClass => new CssBuilder("pf-c-banner")
        .AddClass("pf-m-sticky"  , IsSticky)
        .AddClass("pf-m-danger"  , Variant is BannerVariant.Danger)
        .AddClass("pf-m-info"    , Variant is BannerVariant.Info)
        .AddClass("pf-m-success" , Variant is BannerVariant.Success)
        .AddClass("pf-m-warning" , Variant is BannerVariant.Warning)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ReaderText 
    { 
        get => !string.IsNullOrEmpty(ScreenReaderText) ? ScreenReaderText : $"{Variant} banner"; 
    }
}