namespace Blatternfly.Components;

public partial class ToolbarExpandableContent : ComponentBase
{
    [CascadingParameter] private Toolbar Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Flag indicating the expandable content is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>optional callback for clearing all filters in the toolbar.</summary>
    [Parameter] public EventCallback ClearAllFilters { get; set; }

    /// <summary>Text to display in the clear all filters button.</summary>
    [Parameter] public string ClearFiltersButtonText { get; set; } = "Clear all filters";

    /// <summary>Flag indicating that the clear all filters button should be visible.</summary>
    [Parameter] public bool ShowClearFiltersButton { get; set; }

    private string CssClass => new CssBuilder("pf-c-toolbar__expandable-content")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}