namespace Blatternfly.Components;

/// <summary>The main expandable section component.</summary>
public partial class ExpandableSection : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>ID of the content of the expandable section.</summary>
    [Parameter] public string ContentId { get; set; }

    /// <summary>Display size variant. Set to large for disclosure styling.</summary>
    [Parameter] public DisplaySize DisplaySize { get; set; } = DisplaySize.Default;

    /// <summary>Forces active state.</summary>
    [Parameter] public bool IsActive { get; set; }

    /// <summary>Indicates the expandable section has a detached toggle.</summary>
    [Parameter] public bool IsDetached { get; set; }

    /// <summary>Flag to indicate if the content is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Flag to indicate if the content is indented.</summary>
    [Parameter] public bool IsIndented { get; set; }

    /// <summary>Flag to indicate the width of the component is limited. Set to true for disclosure styling.</summary>
    [Parameter] public bool IsWidthLimited { get; set; }

    /// <summary>Callback function to toggle the expandable content. Detached expandable sections should use the onToggle property of ExpandableSectionToggle.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>RenderFragment that appears in the attached toggle in place of toggle text.</summary>
    [Parameter] public RenderFragment ToggleContent { get; set; }

    /// <summary>Text that appears in the attached toggle.</summary>
    [Parameter] public string ToggleText { get; set; }

    /// <summary>Text that appears in the attached toggle when collapsed (will override toggleText if both are specified; used for uncontrolled expandable with dynamic toggle text).</summary>
    [Parameter] public string ToggleTextCollapsed { get; set; }

    /// <summary>Text that appears in the attached toggle when expanded (will override toggleText if both are specified; used for uncontrolled expandable with dynamic toggle text).</summary>
    [Parameter] public string ToggleTextExpanded { get; set; }

    /// <summary>@beta Truncates the expandable content to the specified number of lines when using the "truncate" variant.</summary>
    [Parameter] public int? TruncateMaxLines { get; set; }

    /// <summary>@beta Determines the variant of the expandable section. When passing in "truncate" as the variant, the expandable content will be truncated after 3 lines by default.</summary>
    [Parameter] public ExpandableSectionVariant Variant { get; set; } = ExpandableSectionVariant.Default;

    private string CssClass => new CssBuilder("pf-c-expandable-section")
        .AddClass("pf-m-expanded"   , IsExpanded)
        .AddClass("pf-m-active"     , IsActive)
        .AddClass("pf-m-detached"   , IsDetached)
        .AddClass("pf-m-display-lg" , DisplaySize is DisplaySize.Large)
        .AddClass("pf-m-limit-width", IsWidthLimited)
        .AddClass("pf-m-indented"   , IsIndented)
        .AddClass("pf-m-truncate"   , Variant is ExpandableSectionVariant.Truncate)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TruncateStyle => new StyleBuilder()
        .AddStyle("--pf-c-expandable-section--m-truncate__content--LineClamp", LineClamp, ShouldTruncate)
        .Build();

    private bool ShouldTruncate { get => Variant is ExpandableSectionVariant.Truncate && LineClamp > 0; }
    private int  LineClamp      { get => TruncateMaxLines.GetValueOrDefault() < 1 ? 0 : TruncateMaxLines.Value; }

    private string ComputedToggleText
    {
        get
        {
            if (IsExpanded && !string.IsNullOrEmpty(ToggleTextExpanded))
            {
                return ToggleTextExpanded;
            }
            if (!IsExpanded && !string.IsNullOrEmpty(ToggleTextCollapsed))
            {
                return ToggleTextCollapsed;
            }
            return ToggleText;
        }
    }

    private string AriaExpanded { get => IsExpanded ? "true" : null; }
    private string Hidden       { get => !IsExpanded ? "true" : null; }

    private async Task OnHandleToggle(MouseEventArgs args)
    {
        IsExpanded = !IsExpanded;
        await OnToggle.InvokeAsync(IsExpanded);
    }
}