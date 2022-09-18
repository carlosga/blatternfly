namespace Blatternfly.Components;

public partial class ToolbarItem : ComponentBase
{
    [CascadingParameter] private Page ParentPage { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>A type modifier which modifies spacing specifically depending on the type of item.</summary>
    [Parameter] public ToolbarItemVariant? Variant { get; set; }

    /// <summary>Visibility at various breakpoints.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>Alignment at various breakpoints.</summary>
    [Parameter] public AlignmentModifiers Alignment { get; set; }

    /// <summary>Spacers at various breakpoints.</summary>
    [Parameter] public ToolbarSpacerModifiers ToolbarSpacer { get; set;}

    /// <summary>Widths at various breakpoints.</summary>
    [Parameter] public ToolbarItemWidthModifiers Widths { get; set; }

    /// <summary>Flag indicating if the expand-all variant is expanded or not.</summary>
    [Parameter] public bool IsAllExpanded { get; set; }

    private string CssClass => new CssBuilder("pf-c-toolbar__item")
        .AddClass("pf-m-bulk-select"  , Variant is ToolbarItemVariant.BulkSelect)
        .AddClass("pf-m-overflow-menu", Variant is ToolbarItemVariant.OverflowMenu)
        .AddClass("pf-m-pagination"   , Variant is ToolbarItemVariant.Pagination)
        .AddClass("pf-m-search-filter", Variant is ToolbarItemVariant.SearchFilter)
        .AddClass("pf-m-search-label" , Variant is ToolbarItemVariant.Label)
        .AddClass("pf-c-chip-group"   , Variant is ToolbarItemVariant.ChipGroup)
        .AddClass("pf-m-expand-all"   , Variant is ToolbarItemVariant.ExpandAll)
        .AddClass("pf-m-expanded"     , IsAllExpanded)
        .AddClass(Visibility?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(Alignment?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(ToolbarSpacer?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId  { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private string AriaHidden  { get => Variant is ToolbarItemVariant.Label ? "true" : null; }
    private string WidthsStyle { get => Widths?.CssStyle; }
}