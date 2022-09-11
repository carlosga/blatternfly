namespace Blatternfly.Components;

public partial class DataList : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Adds accessible text to the DataList list.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>
    /// Optional callback to make DataList selectable, fired when DataListItem selected.
    /// </summary>
    [Parameter] public EventCallback<string> OnSelectDataListItem { get; set; }

    /// <summary>
    /// Id of DataList item currently selected.
    /// </summary>
    [Parameter] public string SelectedDataListItemId { get; set; }

    /// <summary>
    /// Flag indicating if DataList should have compact styling.
    /// </summary>
    [Parameter] public bool IsCompact { get; set; }

    /// <summary>
    /// Specifies the grid breakpoints.
    /// </summary>
    [Parameter] public DataListGridBreakpoint GridBreakpoint { get; set; } = DataListGridBreakpoint.Medium;

    /// <summary>
    /// Determines which wrapping modifier to apply to the DataList.
    /// </summary>
    [Parameter] public DataListWrapModifier? WrapModifier { get; set; }

    /// <summary>
    /// Callback that executes when the screen reader accessible element receives a change event.
    /// </summary>
    [Parameter] public EventCallback<string> SelectableRow { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list")
        .AddClass("pf-m-compact"   , IsCompact)
        .AddClass("pf-m-grid-none" , GridBreakpoint is DataListGridBreakpoint.None)
        .AddClass("pf-m-grid"      , GridBreakpoint is DataListGridBreakpoint.Always)
        .AddClass("pf-m-grid-sm"   , GridBreakpoint is DataListGridBreakpoint.Small)
        .AddClass("pf-m-grid-md"   , GridBreakpoint is DataListGridBreakpoint.Medium)
        .AddClass("pf-m-grid-lg"   , GridBreakpoint is DataListGridBreakpoint.Large)
        .AddClass("pf-m-grid-xl"   , GridBreakpoint is DataListGridBreakpoint.ExtraLarge)
        .AddClass("pf-m-grid-2xl"  , GridBreakpoint is DataListGridBreakpoint.ExtraLarge2)
        .AddClass("pf-m-nowrap"    , WrapModifier is DataListWrapModifier.Nowrap)
        .AddClass("pf-m-truncate"  , WrapModifier is DataListWrapModifier.Truncate)
        .AddClass("pf-m-break-word", WrapModifier is DataListWrapModifier.BreakWord)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    internal bool IsSelectable      => OnSelectDataListItem.HasDelegate;
    internal bool AllowRowSelection => SelectableRow.HasDelegate;

    internal async Task SelectableRowChange(string id)
    {
        await SelectableRow.InvokeAsync(id);
    }

    internal async Task SelectItem(string id)
    {
        SelectedDataListItemId = id;
        await OnSelectDataListItem.InvokeAsync(id);
    }
}
