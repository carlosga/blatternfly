namespace Blatternfly.Components;

/// <summary>Sort.</summary>
public sealed class SortType
{
    /// <summary>Provide the currently active column's index and direction.</summary>
    public SortBy SortBy { get; set; }

    /// <summary>The column index.</summary>
    public int ColumnIndex { get; set; }

    /// <summary>True to make this a favoritable sorting cell.</summary>
    public bool IsFavorites { get; set; }
}
