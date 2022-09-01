namespace Blatternfly.Components;

public partial class DataListItemRow : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Id for the row item.
    /// </summary>
    [Parameter]
    public string RowId { get; set; }

    /// <summary>
    /// Determines which wrapping modifier to apply to the DataListItemRow.
    /// </summary>
    [Parameter]
    public DataListWrapModifier? WrapModifier { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__item-row")
        .AddClass("pf-m-nowrap"    , WrapModifier is DataListWrapModifier.Nowrap)
        .AddClass("pf-m-truncate"  , WrapModifier is DataListWrapModifier.Truncate)
        .AddClass("pf-m-break-word", WrapModifier is DataListWrapModifier.BreakWord)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
