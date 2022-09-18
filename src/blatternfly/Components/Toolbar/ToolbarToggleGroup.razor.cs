namespace Blatternfly.Components;

public partial class ToolbarToggleGroup : ComponentBase
{
    [Inject] private IDomUtils DomUtils { get; set; }

    [CascadingParameter] private Page ParentPage { get; set; }
    [CascadingParameter] private Toolbar Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>An icon to be rendered when the toggle group has collapsed down.</summary>
    [Parameter] public RenderFragment ToggleIcon { get; set; }

    /// <summary>Controls when filters are shown and when the toggle button is hidden.</summary>
    [Parameter] public Breakpoint? Breakpoint { get; set; }

    /// <summary>Visibility at various breakpoints.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>A type modifier which modifies spacing specifically depending on the type of group.</summary>
    [Parameter] public ToolbarGroupVariant? Variant { get; set; }

    /// <summary>Alignment at various breakpoints..</summary>
    [Parameter] public AlignmentModifiers Alignment { get; set; }

    /// <summary>Spacers at various breakpoints..</summary>
    [Parameter] public ToolbarSpacerModifiers ToolbarSpacer { get; set; }

    /// <summary>Space items at various breakpoints..</summary>
    [Parameter] public ToolbarSpaceItemModifiers ToolbarSpaceItems { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> ToggleIsExpanded { get; set; }

    private string CssClass => new CssBuilder("pf-c-toolbar__group pf-m-toggle-group")
        .AddClass("pf-m-filter-group"     , Variant is ToolbarGroupVariant.FilterGroup)
        .AddClass("pf-m-icon-button-group", Variant is ToolbarGroupVariant.IconButtonGroup)
        .AddClass("pf-m-button-group"     , Variant is ToolbarGroupVariant.ButtonGroup)
        .AddClass(() => BreakpointModifers.FromBreakpoint(Breakpoint.Value).CssClass(ParentPage?.WidthBreakpoint), Breakpoint.HasValue)
        .AddClass(Visibility?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(Alignment?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(ToolbarSpacer?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(ToolbarSpaceItems?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private Size<int> _windowSize;
    private string    AriaExpanded        { get => Parent.IsExpanded ? "true" : null; }
    private string    AriaHaspopup        { get => Parent.IsExpanded ? IsContentPopup() : null; }
    private string    ExpandableContentId { get => ""; }

    private string IsContentPopup() => _windowSize.Width < GlobalWidthBreakpoints.Large ? "true" : null;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (!Breakpoint.HasValue || ToggleIcon is null)
        {
            throw new Exception("ToolbarToggleGroup will not be visible without a breakpoint or toggleIcon.");
        }

        _windowSize = await DomUtils.GetWindowSizeAsync();
    }
}