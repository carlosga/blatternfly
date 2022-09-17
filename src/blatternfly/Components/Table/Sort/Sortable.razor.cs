namespace Blatternfly.Components;

public partial class Sortable : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Callback called when sortable column is clicked.</summary>
    [Parameter] public EventCallback<SortEventArgs> OnSort { get; set; }

    /// <summary>Column index</summary>
    [Parameter] public int ColumnIndex { get; set; }

    /// <summary>Sortable button aria-label.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Provide the currently active column's index and direction.</summary>
    [Parameter] public SortBy SortBy { get; set; }

    /// <summary>Determines which wrapping modifier to apply to the table text.</summary>
    [Parameter] public WrapModifier? WrapModifier { get; set; }

    private bool             IsSortedBy           { get => SortBy is not null && ColumnIndex == SortBy.Index; }
    private SortByDirection? DefaultSortDirection { get => IsSortedBy ? SortBy.DefaultDirection : SortByDirection.Asc; }
    private SortByDirection? SortDirection
    {
        get => IsSortedBy ? (SortBy.Direction ?? DefaultSortDirection) : SortByDirection.Asc;
    }

    private async Task SortClicked(MouseEventArgs args)
    {
        var reversedDirection = !IsSortedBy
            ? SortByDirection.Asc
                : SortBy.Direction == SortByDirection.Asc ? SortByDirection.Desc : SortByDirection.Asc;

        await OnSort.InvokeAsync(new SortEventArgs(ColumnIndex, reversedDirection));
    }
}