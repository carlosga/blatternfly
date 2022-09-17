namespace Blatternfly.Components;

public partial class Selectable : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary></summary>
    [Parameter] public string SelectName { get; set; }

    /// <summary></summary>
    [Parameter] public string Label { get; set; }

    /// <summary></summary>
    [Parameter] public RowSelectVariant SelectVariant { get; set; }

    /// <summary></summary>
    [Parameter] public int? RowIndex { get; set; }

    /// <summary></summary>
    [Parameter] public bool IsSelected { get; set; }

    /// <summary></summary>
    [Parameter] public bool IsHeaderSelectDisabled { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<SelectEventArgs> OnSelect { get; set; }

    private int RowId        { get => RowIndex ?? -1; }
    private string AriaLabel { get => RowId != 1 ? $"Select row {RowIndex}" : "Select all rows"; }

    private async Task SelectClick(bool newValue)
    {
        var selected = !RowIndex.HasValue ? newValue : IsSelected;

        await OnSelect.InvokeAsync(new SelectEventArgs { RowIndex = RowId, IsSelected = selected });
    }
}