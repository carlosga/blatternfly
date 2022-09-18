namespace Blatternfly.Components;

public partial class ToolbarGroup : ComponentBase
{
    [CascadingParameter] private Page ParentPage { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>A type modifier which modifies spacing specifically depending on the type of group.</summary>
    [Parameter] public ToolbarGroupVariant? Variant { get; set; }

    /// <summary>Visibility at various breakpoints.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>Alignment at various breakpoints.</summary>
    [Parameter] public AlignmentModifiers Alignment { get; set; }

    /// <summary>Spacers at various breakpoints.</summary>
    [Parameter] public ToolbarSpacerModifiers Spacer { get; set; }

    /// <summary>Space items at various breakpoints.</summary>
    [Parameter] public ToolbarSpaceItemModifiers SpaceItems { get; set; }

    private string CssClass => new CssBuilder("pf-c-toolbar__group")
        .AddClass("pf-m-filter-group"     , Variant is ToolbarGroupVariant.FilterGroup)
        .AddClass("pf-m-icon-button-group", Variant is ToolbarGroupVariant.IconButtonGroup)
        .AddClass("pf-m-button-group"     , Variant is ToolbarGroupVariant.ButtonGroup)
        .AddClass(Visibility?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(Alignment?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(Spacer?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(SpaceItems?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}