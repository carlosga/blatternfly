namespace Blatternfly.Components;

/// <summary>Row selection type.</summary>
public sealed class SelectType
{
    /// <summary>The selectable variant.</summary>
    public RowSelectVariant Variant { get; set; } = RowSelectVariant.Checkbox;

    /// <summary>Whether the cell is selected.</summary>
    public bool IsSelected { get; set; }

    /// <summary>Flag indicating the select checkbox in the th is disabled.</summary>
    public bool IsHeaderSelectDisabled { get; set; }

    /// <summary>Whether to disable the selection.</summary>
    public bool Disable { get; set; }

    /// <summary>The row index.</summary>
    public int RowIndex { get; set; }
}
