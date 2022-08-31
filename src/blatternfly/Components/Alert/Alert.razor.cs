using Blatternfly.Interop;

namespace Blatternfly.Components;

public partial class Alert : ComponentBase
{
    [Inject] private IDomUtils DomUtils { get; set; }
    
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

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
    /// Adds alert variant styles.
    /// <summary>
    [Parameter]
    public AlertVariant Variant { get; set; } = AlertVariant.Default;

    /// <summary>
    /// Flag to indicate if the Alert is inline.
    /// </summary>
    [Parameter]
    public bool IsInline { get; set; }

    /// <summary>
    /// Flag to indicate if the alert is plain.
    /// </summary>
    [Parameter]
    public bool IsPlain { get; set; }

    /// <summary>
    /// Title of the Alert.
    /// </summary>
    [Parameter]
    public string Title { get; set; }

    /// <summary>
    /// Sets the heading level to use for the alert title. Default is h4.
    /// </summary>
    [Parameter]
    public HeadingLevel TitleHeadingLevel { get; set; } = HeadingLevel.h4;

    /// <summary>
    /// Close button; use the AlertActionCloseButton component.
    /// </summary>
    [Parameter]
    public RenderFragment ActionClose { get; set; }

    /// <summary>
    /// Action links; use a single AlertActionLink component or multiple wrapped in an array or React.Fragment.
    /// </summary>
    [Parameter]
    public RenderFragment ActionLinks { get; set; }

    /// <summary>
    /// Adds accessible text to the Alert.
    /// </summary>
    [Parameter]
    public string AriaLabel { get; set; }

    /// <summary>
    /// Variant label text for screen readers.
    /// </summary>
    [Parameter]
    public string VariantLabel { get; set; }

    /// <summary>
    /// Flag to indicate if the Alert is in a live region.
    /// </summary>
    [Parameter]
    public bool IsLiveRegion { get; set; }

    /// <summary>
    /// Truncate title to number of lines.
    /// </summary>
    [Parameter]
    public int TruncateTitle { get; set; }

    /// <summary>
    /// Set a custom icon to the Alert. If not set the icon is set according to the variant.
    /// </summary>
    [Parameter]
    public RenderFragment CustomIcon { get; set; }

    /// <summary>
    /// Flag indicating that the alert is expandable
    /// </summary>
    [Parameter]
    public bool IsExpandable { get; set; }

    /// <summary>
    /// Adds accessible text to the alert Toggle.
    /// </summary>
    [Parameter]
    public string ToggleAriaLabel { get; set; }

    /// <summary>
    /// Position of the tooltip which is displayed if text is truncated.
    /// </summary>
    [Parameter]
    public TooltipPosition TooltipPosition { get; set; }

    private string CssClass => new CssBuilder("pf-c-alert")
        .AddClass("pf-m-inline"    , IsInline)
        .AddClass("pf-m-plain"     , IsPlain)
        .AddClass("pf-m-expandable", IsExpandable)
        .AddClass("pf-m-expanded"  , IsExpanded)
        .AddClass("pf-m-danger"    , Variant is AlertVariant.Danger)
        .AddClass("pf-m-info"      , Variant is AlertVariant.Info)
        .AddClass("pf-m-success"   , Variant is AlertVariant.Success)
        .AddClass("pf-m-warning"   , Variant is AlertVariant.Warning)
        .Build();
    
    private string TitleCssClass => new CssBuilder("pf-c-alert__title")
        .AddClass("pf-m-truncate", TruncateTitle > 0)
        .Build();
    
    private string TruncateTitleStyle => new StyleBuilder()
        .AddStyle("--pf-c-alert__title--max-lines", TruncateTitle, TruncateTitle > 0)
        .Build();
    
    private TitleHeadingLevel TitleRef { get; set; }

    private string TitleId { get; set; }

    private string TooltipId { get; set; }

    private bool IsClosed { get; set; }

    private bool IsExpanded { get; set; }

    private AlertIconVariants AlertIconVariant 
    { 
        get => Variant switch
        {
            AlertVariant.Success => AlertIconVariants.Success,
            AlertVariant.Danger  => AlertIconVariants.Danger,
            AlertVariant.Warning => AlertIconVariants.Warning,
            AlertVariant.Info    => AlertIconVariants.Info,
            _                    => AlertIconVariants.Default
        }; 
    }

    private string AriaLive { get => IsLiveRegion ? "polite" : null; }

    private string AriaAtomic { get => IsLiveRegion ? "false" : null; }

    private string AriaLabelValue { get => string.IsNullOrEmpty(AriaLabel) ? $"{Variant} Alert" : AriaLabel; }

    private string VariantLabelValue 
    { 
        get => string.IsNullOrEmpty(VariantLabel) ? $"{Variant} alert:" : VariantLabel; 
    }

    private string ToggleAriaLabelValue 
    {
        get => string.IsNullOrEmpty(ToggleAriaLabel) ? $"{Variant} alert details" : ToggleAriaLabel; 
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        TitleId   = ComponentIdGenerator.Generate("pf-c-alert-title");
        TooltipId = $"{TitleId}-tooltip";
    }

    private void OnToggleExpand(MouseEventArgs _)
    {
        IsExpanded = !IsExpanded;
    }
}
