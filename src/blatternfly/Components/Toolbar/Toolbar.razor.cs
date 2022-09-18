namespace Blatternfly.Components;

public partial class Toolbar : ComponentBase
{
    [Inject] private IDomUtils DomUtils { get; set; }
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [CascadingParameter] private Page ParentPage { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Optional callback for clearing all filters in the toolbar.</summary>
    [Parameter] public EventCallback ClearAllFilters { get; set; }

    /// <summary>Text to display in the clear all filters button.</summary>
    [Parameter] public string ClearFiltersButtonText { get; set; }

    /// <summary>
    /// Custom content appended to the filter generated chip group.
    /// To maintain spacing and styling, each node should be wrapped in a ToolbarItem or ToolbarGroup.
    /// This property will remove the default "Clear all filters" button.
    /// </summary>
    [Parameter] public RenderFragment CustomChipGroupContent { get; set; }

    /// <summary>The breakpoint at which the listed filters in chip groups are collapsed down to a summary.</summary>
    [Parameter] public CollapseFilterBreakpoints CollapseListedFiltersBreakpoint { get; set; }

    /// <summary>Flag indicating if a data toolbar toggle group's expandable content is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>A callback for setting the isExpanded flag.</summary>
    [Parameter] public EventCallback ToggleIsExpanded { get; set; }

    /// <summary>Flag indicating the toolbar height should expand to the full height of the container.</summary>
    [Parameter] public bool IsFullHeight { get; set; }

    /// <summary>Flag indicating the toolbar is static.</summary>
    [Parameter] public bool IsStatic { get; set; }

    /// <summary>Flag indicating the toolbar should use the Page insets.</summary>
    [Parameter] public bool UsePageInsets { get; set; }

    /// <summary>Flag indicating the toolbar should stick to the top of its container.</summary>
    [Parameter] public bool IsSticky { get; set; }

    /// <summary>Insets at various breakpoints.</summary>
    [Parameter] public InsetModifiers Inset { get; set; }

    /// <summary>
    /// Flag used if the user has opted NOT to manage the 'isExpanded' state of the toggle group.
    /// Indicates whether or not the toggle group is expanded.
    /// </summary>
    [Parameter] public bool IsManagedToggleExpanded { get; set; }

    /// <summary>Total number of filters currently being applied across all ToolbarFilter components.</summary>
    [Parameter] public int NumberOfFilters { get; set; }

    /// <summary>Text to display in the total number of applied filters ToolbarFilter</summary>
    [Parameter] public string NumberOfFiltersText { get; set; }

    /// <summary>Used to keep track of window width so we can collapse expanded content when window is resizing.</summary>
    [Parameter] public int WindowWidth { get; set; }

    private string CssClass => new CssBuilder("pf-c-toolbar")
        .AddClass("pf-m-page-insets", UsePageInsets)
        .AddClass(Inset?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass("pf-m-full-height", IsFullHeight)
        .AddClass("pf-m-static"     , IsStatic)
        .AddClass("pf-m-sticky"     , IsSticky)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    internal string ToolbarId              { get; private set; }
    private  bool   IsToggleManaged        { get => !IsExpanded || ToggleIsExpanded.HasDelegate; }
    private  bool   ShowClearFiltersButton { get => NumberOfFilters > 0; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ToolbarId = ComponentIdGenerator.Generate("pf-c-toolbar");
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        var windowSize = await DomUtils.GetWindowSizeAsync();

        WindowWidth = windowSize.Width;
    }
}