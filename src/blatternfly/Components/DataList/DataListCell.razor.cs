namespace Blatternfly.Components;

public partial class DataListCell : ComponentBase
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
    /// Width (from 1-5) to the DataList cell.
    /// </summary>
    [Parameter]
    public int? Width { get; set; } = 1;

    /// <summary>
    /// Enables the body Content to fill the height of the card.
    /// </summary>
    [Parameter]
    public bool IsFilled { get; set; } = true;

    /// <summary>
    ///  Aligns the cell content to the right of its parent.
    /// </summary>
    [Parameter]
    public bool AlignRight { get; set; }

    /// <summary>
    /// Set to true if the cell content is an Icon.
    /// </summary>
    [Parameter]
    public bool IsIcon { get; set; }

    /// <summary>
    /// Determines which wrapping modifier to apply to the data list text.
    /// </summary>
    [Parameter]
    public DataListWrapModifier? WrapModifier { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__cell")
        .AddClass($"pf-m-flex-{Width}", Width is> 1)
        .AddClass("pf-m-no-fill"      , !IsFilled)
        .AddClass("pf-m-align-right"  , AlignRight)
        .AddClass("pf-m-icon"         , IsIcon)
        .AddClass("pf-m-nowrap"       , WrapModifier is DataListWrapModifier.Nowrap)
        .AddClass("pf-m-truncate"     , WrapModifier is DataListWrapModifier.Truncate)
        .AddClass("pf-m-break-word"   , WrapModifier is DataListWrapModifier.BreakWord)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (Width is < 1 or > 5)
        {
            throw new InvalidOperationException("DataListCell: Width should be between 1 and 5.");
        }
    }
}
