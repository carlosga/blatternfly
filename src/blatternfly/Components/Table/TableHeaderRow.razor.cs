namespace Blatternfly.Components;

public partial class TableHeaderRow<TColumn> : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating the Tr is hidden.</summary>
    [Parameter] public bool IsHidden { get; set; }

    /// <summary>Column Headers</summary>
    [Parameter] public IReadOnlyList<TColumn> Columns { get; set; }

    /// <summary>Column Header Template</summary>
    [Parameter] public RenderFragment<TColumn> ColumnTemplate { get; set; }
}