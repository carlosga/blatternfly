namespace Blatternfly.Components;

public partial class DataListItemCells : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Id for the row</summary>
    [Parameter] public string RowId { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__item-content")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
