namespace Blatternfly.Components;

public sealed class SortBy
{
    /// Index of the current sorted column.
    public int? Index { get; set; }
    
    /// Current sort direction.
    public SortByDirection? Direction { get; set; }
    
    /// Defaulting sorting direction. Defaults to "asc".
    public SortByDirection? DefaultDirection { get; set; }
}
