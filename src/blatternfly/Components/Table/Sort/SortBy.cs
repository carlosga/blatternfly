namespace Blatternfly.Components;

/// <summary>Sort by params.</summary>
public sealed class SortBy
{
    /// <summary>Index of the current sorted column.</summary>
    public int? Index { get; set; }

    /// <summary>Current sort direction.</summary>
    public SortByDirection? Direction { get; set; }

    /// <summary>Defaulting sorting direction. Defaults to "asc".</summary>
    public SortByDirection? DefaultDirection { get; set; }
}
