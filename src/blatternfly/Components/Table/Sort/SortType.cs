namespace Blatternfly.Components;

public sealed class SortType
{
    /// Provide the currently active column's index and direction.
    public SortBy SortBy { get; set; }
    
    /// The column index.
    public int ColumnIndex { get; set; }
    
    /// True to make this a favoritable sorting cell.
    public bool IsFavorites { get; set; }        
}
