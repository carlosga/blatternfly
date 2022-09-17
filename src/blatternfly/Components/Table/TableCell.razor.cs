namespace Blatternfly.Components;

public partial class TableCell : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The column header the cell corresponds to.</summary>
    /// <summary>This attribute replaces table header in mobile viewport. It is rendered by ::before pseudo element.</summary>
    [Parameter] public string DataLabel { get; set; }

    /// <summary>Modifies cell to center its contents.</summary>
    [Parameter] public bool TextCenter { get; set; }

    /// <summary>Style modifier to apply.</summary>
    [Parameter] public WrapModifier? Modifier { get; set; }

    /// <summary>Width percentage modifier.</summary>
    [Parameter] public TableCellWidth? Width { get; set; }

    /// <summary>Visibility breakpoint modifiers.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>True to remove padding.</summary>
    [Parameter] public bool NoPadding { get; set; }

    /// <summary>Renders a checkbox select.</summary>
    [Parameter] public SelectType Select { get; set; }

    /// <summary>Callback on select.</summary>
    [Parameter] public EventCallback<SelectEventArgs> OnSelect { get; set; }

    /// <summary>Indicates the header column should be sticky.</summary>
    [Parameter] public bool IsStickyColumn { get; set; }

    /// <summary>Adds a border to the right side of the cell.</summary>
    [Parameter] public bool HasRightBorder { get; set; }

    /// <summary>Minimum width for a sticky column.</summary>
    [Parameter] public string StickyMinWidth { get; set; } = "120px";

    /// <summary>Left offset of a sticky column. This will typically be equal to the combined value set by stickyMinWidth of any sticky columns that precede the current sticky column.</summary>
    [Parameter] public string StickyLeftOffset { get; set; }

    /// <summary>Turns the cell into an expansion toggle and determines if the corresponding expansion row is open.</summary>
    [Parameter] public ExpandType Expand { get; set; }

    /// <summary>On toggling the expansion.</summary>
    [Parameter] public EventCallback<CollapseEventArgs> OnToggle { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-table__sticky-column--MinWidth", StickyMinWidth  , IsStickyColumn && !string.IsNullOrEmpty(StickyMinWidth))
        .AddStyle("--pf-c-table__sticky-column--Left"    , StickyLeftOffset, IsStickyColumn && !string.IsNullOrEmpty(StickyLeftOffset))
        .Build();

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-table__toggle"       , Expand is not null)
        .AddClass("pf-m-center"              , TextCenter)
        .AddClass("pf-m-no-padding"          , NoPadding)
        .AddClass("pf-c-table__sticky-column", IsStickyColumn)
        .AddClass("pf-m-border-right"        , HasRightBorder)
        .AddClass(Visibility?.CssClass())
        .AddClass("pf-m-break-word"          , Modifier is WrapModifier.BreakWord)
        .AddClass("pf-m-fit-content"         , Modifier is WrapModifier.FitContent)
        .AddClass("pf-m-nowrap"              , Modifier is WrapModifier.Nowrap)
        .AddClass("pf-m-truncate"            , Modifier is WrapModifier.Truncate)
        .AddClass("pf-m-wrap"                , Modifier is WrapModifier.Wrap)
        .AddClass("pf-m-width-10"            , Width is TableCellWidth.W10)
        .AddClass("pf-m-width-15"            , Width is TableCellWidth.W15)
        .AddClass("pf-m-width-20"            , Width is TableCellWidth.W20)
        .AddClass("pf-m-width-25"            , Width is TableCellWidth.W25)
        .AddClass("pf-m-width-30"            , Width is TableCellWidth.W30)
        .AddClass("pf-m-width-35"            , Width is TableCellWidth.W35)
        .AddClass("pf-m-width-40"            , Width is TableCellWidth.W40)
        .AddClass("pf-m-width-45"            , Width is TableCellWidth.W45)
        .AddClass("pf-m-width-50"            , Width is TableCellWidth.W50)
        .AddClass("pf-m-width-60"            , Width is TableCellWidth.W60)
        .AddClass("pf-m-width-70"            , Width is TableCellWidth.W70)
        .AddClass("pf-m-width-80"            , Width is TableCellWidth.W80)
        .AddClass("pf-m-width-90"            , Width is TableCellWidth.W90)
        .AddClass("pf-m-width-100"           , Width is TableCellWidth.W100)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string DataLabelValue
    {
        get
        {
            var cssClass = AdditionalAttributes.GetPropertyValue("class");
            if (string.IsNullOrEmpty(cssClass) || !cssClass.Contains("pf-c-table__tree-view-title-cell"))
            {
                return DataLabel;
            }
            return null;
        }
    }
}