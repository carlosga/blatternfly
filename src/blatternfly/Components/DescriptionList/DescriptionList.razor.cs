namespace Blatternfly.Components;

public partial class DescriptionList : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Sets the description list to auto fit.
    /// </summary>
    [Parameter] public bool IsAutoFit { get; set; }

    /// <summary>
    /// Sets the description list component term and description pair to a horizontal layout.
    /// </summary>
    [Parameter] public bool IsHorizontal { get; set; }

    /// <summary>
    /// Sets the description list to format automatically.
    /// </summary>
    [Parameter] public bool IsAutoColumnWidths { get; set; }

    /// <summary>
    /// Modifies the description list display to inline-grid.
    /// </summary>
    [Parameter] public bool IsInlineGrid { get; set; }

    /// <summary>
    /// Sets the description list to compact styling.
    /// </summary>
    [Parameter] public bool IsCompact { get; set; }

    /// <summary>
    /// Sets a horizontal description list to have fluid styling.
    /// </summary>
    [Parameter] public bool IsFluid { get; set; }

    /// <summary>
    /// Sets the the default placement of description list groups to fill from top to bottom.
    /// </summary>
    [Parameter] public bool IsFillColumns { get; set; }

    /// <summary>
    /// Sets the display size of the descriptions in the description list.
    /// </summary>
    [Parameter] public DescriptionListDisplaySize? DisplaySize { get; set; }

    /// <summary>
    /// Sets the number of columns on the description list at various breakpoints.
    /// </summary>
    [Parameter] public DescriptionListColumnModifiers ColumnModifier { get; set; }

    /// <summary>
    /// Indicates how the menu will align at various breakpoints.
    /// </summary>
    [Parameter] public OrientationModifiers Orientation { get; set; }

    /// <summary>
    /// Sets the minimum column size for the auto-fit (isAutoFit) layout at various breakpoints.
    /// </summary>
    [Parameter] public AutoFitModifiers AutoFitMinModifier { get; set; }

    /// <summary>
    /// Sets the description list's term column width.
    /// </summary>
    [Parameter] public string TermWidth { get; set; }

    /// <summary>
    /// Sets the horizontal description list's term column width at various breakpoints.
    /// </summary>
    [Parameter] public HorizontalTermWidthModifiers HorizontalTermWidthModifier { get; set; }

    private string CssClass => new CssBuilder("pf-c-description-list")
        .AddClass("pf-m-horizontal"         , IsHorizontal || IsFluid)
        .AddClass("pf-m-auto-column-widths" , IsAutoColumnWidths)
        .AddClass("pf-m-auto-fit"           , IsAutoFit)
        .AddClass(Orientation?.CssClass())
        .AddClass(ColumnModifier?.CssClass())
        .AddClass("pf-m-inline-grid"        , IsInlineGrid)
        .AddClass("pf-m-compact"            , IsCompact)
        .AddClass("pf-m-fluid"              , IsFluid)
        .AddClass("pf-m-fill-columns"       , IsFillColumns)
        .AddClass("pf-m-display-lg"         , DisplaySize is DescriptionListDisplaySize.Large)
        .AddClass("pf-m-display-2xl"        , DisplaySize is DescriptionListDisplaySize.ExtraLarge2)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddRaw(AutoFitMinModifier?.CssStyle            , IsAutoFit)
        .AddRaw(HorizontalTermWidthModifier?.CssStyle   , IsHorizontal)
        .AddStyle("--pf-c-description-list__term--width", TermWidth, !string.IsNullOrEmpty(TermWidth))
        .Build();
}