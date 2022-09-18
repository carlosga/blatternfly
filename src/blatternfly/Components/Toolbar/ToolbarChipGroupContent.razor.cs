namespace Blatternfly.Components;

public partial class ToolbarChipGroupContent : ComponentBase
{
    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Flag indicating if a data toolbar toggle group's expandable content is expanded.</summary>
    [Parameter] public  bool IsExpanded { get; set; }

    /// <summary>optional callback for clearing all filters in the toolbar.</summary>
    [Parameter] public EventCallback ClearAllFilters { get; set; }

    /// <summary>Flag indicating that the clear all filters button should be visible.</summary>
    [Parameter] public bool ShowClearFiltersButton { get; set; }

    /// <summary>Text to display in the clear all filters button.</summary>
    [Parameter] public string ClearFiltersButtonText { get; set; } = "Clear all filters";

    /// <summary>Total number of filters currently being applied across all ToolbarFilter components.</summary>
    [Parameter] public int NumberOfFilters { get; set; }

    /// <summary>Text to display in the total number of applied filters ToolbarFilter</summary>
    [Parameter] public string NumberOfFiltersText { get; set; } = "{0} filters applied";

    /// <summary>The breakpoint at which the listed filters in chip groups are collapsed down to a summary.</summary>
    [Parameter] public CollapseFilterBreakpoints CollapseListedFiltersBreakpoint { get; set; } = CollapseFilterBreakpoints.Large;

    /// <summary>
    /// Custom additional content appended to the generated chips.
    /// To maintain spacing and styling, each node should be a ToolbarItem or ToolbarGroup.
    /// This property will remove the built in "Clear all filters" button.
    /// </summary>
    [Parameter] public RenderFragment CustomChipGroupContent { get; set; }

    private string FormattedNumberOfFiltersText { get => string.Format(NumberOfFiltersText, NumberOfFilters); }

    private string CssClass => new CssBuilder("pf-c-toolbar__content")
        .AddClass("pf-m-hidden", IsHidden)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private Size<int> _windowSize;

    private bool   IsHidden           { get => NumberOfFilters == 0 || IsExpanded; }
    private string ContentHidden      { get => IsHidden ? "true" : null; }
    private string ToolbarGroupClass  { get => CollapseListedFilters ? "pf-m-hidden" : null; }
    private string ToolbarGroupHidden { get => CollapseListedFilters ? "true" : null; }

    private int CollapseListedFiltersBreakpointValue
    {
        get => CollapseListedFiltersBreakpoint switch
        {
            CollapseFilterBreakpoints.Small       => GlobalWidthBreakpoints.Small,
            CollapseFilterBreakpoints.Medium      => GlobalWidthBreakpoints.Medium,
            CollapseFilterBreakpoints.Large       => GlobalWidthBreakpoints.Large,
            CollapseFilterBreakpoints.ExtraLarge  => GlobalWidthBreakpoints.ExtraLarge,
            CollapseFilterBreakpoints.ExtraLarge2 => GlobalWidthBreakpoints.ExtraLarge2,
            _                                     => 0
        };
    }

    private bool CollapseListedFilters
    {
        get
        {
           return (CollapseListedFiltersBreakpoint is CollapseFilterBreakpoints.All)
                ? true
                    : _windowSize.Width < CollapseListedFiltersBreakpointValue;
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        _windowSize = await DomUtils.GetWindowSizeAsync();
    }
}