namespace Blatternfly.Components;

public partial class PageGroup : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Modifier indicating if the PageBreadcrumb is sticky to the top or bottom at various breakpoints.</summary>
    [Parameter] public StickyPositionModifiers StickyOnBreakpoint { get; set; }

    /// <summary>Modifier indicating if PageGroup should have a shadow at the top.</summary>
    [Parameter] public bool HasShadowTop { get; set; }

    /// <summary>Modifier indicating if PageGroup should have a shadow at the bottom.</summary>
    [Parameter] public bool HasShadowBottom { get; set; }

    /// <summary>Flag indicating if the PageGroup has a scrolling overflow.</summary>
    [Parameter] public bool HasOverflowScroll { get; set; }

    private string CssClass => new CssBuilder("pf-c-page__main-group")
        .AddClass(StickyOnBreakpoint?.CssClass())
        .AddClass("pf-m-shadow-top"     , HasShadowTop)
        .AddClass("pf-m-shadow-bottom"  , HasShadowBottom)
        .AddClass("pf-m-overflow-scroll", HasOverflowScroll)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TabIndex { get => HasOverflowScroll ? "0" : null; }
}