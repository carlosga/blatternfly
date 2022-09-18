namespace Blatternfly.Components;

public partial class Table : ComponentBase
{
    public ElementReference Element { get; protected  set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds an accessible name for the Table.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Style variant for the Table .</summary>
    [Parameter] public TableVariant? Variant { get; set; }

    /// <summary>
    /// Render borders. Borders can only currently be disabled if the variant is set to 'compact'.
    /// https://github.com/patternfly/patternfly/issues/3650
    /// </summary>
    [Parameter] public bool Borders { get; set; } = true;

    /// <summary>Specifies the grid breakpoints .</summary>
    [Parameter] public TableGridBreakPoint GridBreakPoint { get; set; } = TableGridBreakPoint.Medium;

    /// <summary>A valid WAI-ARIA role to be applied to the table element.</summary>
    [Parameter] public string Role { get; set; } = "grid";

    /// <summary>If set to true, the table header sticks to the top of its container.</summary>
    [Parameter] public bool IsStickyHeader { get; set; }

    /// <summary>Flag indicating table is a tree table.</summary>
    [Parameter] public bool IsTreeTable { get; set; }

    /// <summary>Flag indicating this table is nested within another table.</summary>
    [Parameter] public bool IsNested { get; set; }

    /// <summary>
    /// Flag indicating this table should be striped. This property works best for a single 'tbody' table.
    /// Striping may also be done manually by applying this property to Tbody and Tr components.
    /// </summary>
    [Parameter] public bool IsStriped { get; set; }

    /// <summary>Flag indicating this table contains expandable rows to maintain proper striping.</summary>
    [Parameter] public bool IsExpandable { get; set; }

    /// <summary>Modifies the body to allow for expandable rows.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    // Collection of column spans for nested headers.
    [Parameter] public int[] NestedHeaderColumnSpans { get; set; }

    /// <summary>
    /// Flag to apply a caption element with visually hidden instructions that improves a11y for tables with selectable rows.
    /// If this prop is set to true other caption elements should not be passed as children of this table,
    /// and you should instead use the selectableRowCaptionText prop.
    /// </summary>
    [Parameter] public bool HasSelectableRowCaption { get; set; }

    /// <summary>
    /// Visible text to add alongside the hidden a11y caption for tables with selectable rows.
    /// This prop must be used to add custom caption content to the table when the hasSelectableRowCaption prop is set to true.
    /// </summary>
    [Parameter] public string SelectableRowCaptionText { get; set; }

    /// <summary>Text announced by screen readers to indicate the table has selectable rows.</summary>
    [Parameter] public string SelectableRowsScreenReaderText { get; set; } = "This table has selectable rows. It can be navigated by row using tab, and each row can be selected using space or enter.";

    private string TableRole { get => IsTreeTable ? "treegrid" : Role; }

    private string CssClass => new CssBuilder("pf-c-table")
        .AddClass("pf-m-compact"        , Variant is TableVariant.Compact)
        .AddClass("pf-m-no-border-rows" , !Borders)
        .AddClass("pf-m-sticky-header"  , IsStickyHeader)
        .AddClass("pf-m-tree-view"      , IsTreeTable)
        .AddClass("pf-m-nested"         , IsNested)
        .AddClass("pf-m-striped"        , IsStriped)
        .AddClass("pf-m-expandable"     , IsExpandable)
        .AddClass(GridClass)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string GridClass
    {
        get
        {
            return GridBreakPoint switch
            {
                TableGridBreakPoint.Medium      => IsTreeTable ? "pf-m-tree-view-grid-md"  : "pf-m-grid-md",
                TableGridBreakPoint.Large       => IsTreeTable ? "pf-m-tree-view-grid-lg"  : "pf-m-grid-lg",
                TableGridBreakPoint.ExtraLarge  => IsTreeTable ? "pf-m-tree-view-grid-xl"  : "pf-m-grid-xl",
                TableGridBreakPoint.ExtraLarge2 => IsTreeTable ? "pf-m-tree-view-grid-2xl" : "pf-m-grid-2xl",
                _                               => null
            };
        }
    }

    private bool HasSelectableRows { get; set; }

    internal void RegisterSelectableRow() => HasSelectableRows = true;
}