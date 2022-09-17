namespace Blatternfly.Components;

/// <summary></summary>
public sealed class ExpandType
{
    /// <summary>Flag indicating the child row associated with this cell is expanded.</summary>
    public bool IsExpanded { get; set; }

    /// <summary>The row index.</summary>
    public int RowIndex { get; set; }

    /// <summary>The column index.</summary>
    public int? ColumnIndex { get; set; }

    /// <summary></summary>
    public bool FullWidth { get; set; }

    /// <summary></summary>
    public bool NoPadding { get; set; }
}
