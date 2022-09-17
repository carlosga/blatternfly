namespace Blatternfly.Components;

/// <summary>Sort changed event args.</summary>
public sealed class SortEventArgs
{
    /// <summary>Column index.</summary>
    public int ColumnIndex { get; }

    /// <summary>Sort direction.</summary>
    public SortByDirection SortByDirection { get; }

    internal SortEventArgs(int columnIndex, SortByDirection direction)
    {
        ColumnIndex     = columnIndex;
        SortByDirection = direction;
    }
}
