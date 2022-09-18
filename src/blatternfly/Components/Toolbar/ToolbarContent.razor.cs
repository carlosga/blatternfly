namespace Blatternfly.Components;

public partial class ToolbarContent : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [CascadingParameter] private Page ParentPage { get; set; }
    [CascadingParameter] private Toolbar ParentToolbar { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Visibility at various breakpoints.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>Alignment at various breakpoints.</summary>
    [Parameter] public AlignmentModifiers Alignment { get; set; }

    /// <summary>Flag indicating if a data toolbar toggle group's expandable content is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Optional callback for clearing all filters in the toolbar.</summary>
    [Parameter] public EventCallback ClearAllFilters { get; set; }

    /// <summary>Flag indicating that the clear all filters button should be visible.</summary>
    [Parameter] public bool ShowClearFiltersButton { get; set; }

    /// <summary>Text to display in the clear all filters button.</summary>
    [Parameter] public string ClearFiltersButtonText { get; set; }

    private string CssClass => new CssBuilder("pf-c-toolbar__content")
        .AddClass(Visibility?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(Alignment?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ExpandableContentId { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ExpandableContentId = ParentToolbar.ToolbarId ?? ComponentIdGenerator.Generate("pf-toolbar-expandable-content");
    }
}