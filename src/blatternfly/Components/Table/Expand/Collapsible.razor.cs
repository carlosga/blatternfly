namespace Blatternfly.Components;

public partial class Collapsible : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary></summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary></summary>
    [Parameter] public string RowLabeledBy { get; set; } = "simple-node";

    /// <summary></summary>
    [Parameter] public string ExpandId { get; set; } = "expand-toggle";

    /// <summary></summary>
    [Parameter] public int RowIndex { get; set; }

    /// <summary></summary>
    [Parameter] public int? ColumnIndex { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<CollapseEventArgs> OnCollapse { get; set; }

    private string ColumnId       { get => $"{ExpandId}{RowIndex}"; }
    private string AriaLabelledBy { get => $"{RowLabeledBy}{RowIndex} {ExpandId}{RowIndex}"; }

    private async Task OnToggle(MouseEventArgs args)
    {
        IsOpen = !IsOpen;
        await OnCollapse.InvokeAsync(new CollapseEventArgs { RowIndex = RowIndex, IsOpen = IsOpen });
    }
}