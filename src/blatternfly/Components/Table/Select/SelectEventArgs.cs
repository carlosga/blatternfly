namespace Blatternfly.Components;

/// <summary>Row select evet args.</summary>
public sealed class SelectEventArgs
{
    /// <summary>Row index.</summary>
    public int  RowIndex { get; set; }

    /// <summary>A value indicating whether the row is selected.</summary>
    public bool IsSelected { get; set; }
}
