namespace Blatternfly.Components;

public partial class PageSection : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Section background color variant.</summary>
    [Parameter] public PageSectionVariants Variant { get; set; } = PageSectionVariants.Default;

    /// <summary>Section type variant.</summary>
    [Parameter] public PageSectionType Type { get; set; } = PageSectionType.Default;

    /// <summary>Enables the page section to fill the available vertical space.</summary>
    [Parameter] public bool? IsFilled { get; set; }

    /// <summary>Limits the width of the breadcrumb.</summary>
    [Parameter] public bool IsWidthLimited { get; set; }

    /// <summary>Flag indicating if the section content is center aligned. isWidthLimited must be set for this to work.</summary>
    [Parameter] public bool IsCenterAligned { get; set; }

    /// <summary>Padding at various breakpoints.</summary>
    [Parameter] public PaddingModifiers Padding { get; set; }

    /// <summary>Modifier indicating if the PageSection is sticky to the top or bottom at various breakpoints.</summary>
    [Parameter] public StickyPositionModifiers StickyOnBreakpoint { get; set; }

    /// <summary>Flag indicating if the PageSection should have a shadow at the top.</summary>
    [Parameter] public bool HasShadowTop { get; set; }

    /// <summary>Flag indicating if the PageSection should have a shadow at the bottom.</summary>
    [Parameter] public bool HasShadowBottom { get; set; }

    /// <summary>Flag indicating if the PageSection has a scrolling overflow.</summary>
    [Parameter] public bool HasOverflowScroll { get; set; }

    /// <summary>Sets the base component to render. Defaults to section.</summary>
    [Parameter] public string Component { get; set; } = "section";

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-page__main-section"   , Type is PageSectionType.Default)
        .AddClass("pf-c-page__main-nav"       , Type is PageSectionType.Nav)
        .AddClass("pf-c-page__main-subnav"    , Type is PageSectionType.SubNav)
        .AddClass("pf-c-page__main-breadcrumb", Type is PageSectionType.Breadcrumb)
        .AddClass("pf-c-page__main-tabs"      , Type is PageSectionType.Tabs)
        .AddClass("pf-c-page__main-wizard"    , Type is PageSectionType.Wizard)
        .AddClass(Padding?.CssClass())
        .AddClass(StickyOnBreakpoint?.CssClass())
        .AddClass("pf-m-light"                , Variant is PageSectionVariants.Light)
        .AddClass("pf-m-dark-200"             , Variant is PageSectionVariants.Dark)
        .AddClass("pf-m-dark-100"             , Variant is PageSectionVariants.Darker)
        .AddClass("pf-m-fill"                 , IsFilled.HasValue && IsFilled.Value)
        .AddClass("pf-m-no-fill"              , IsFilled.HasValue && !IsFilled.Value)
        .AddClass("pf-m-limit-width"          , IsWidthLimited)
        .AddClass("pf-m-align-center"         , IsWidthLimited && IsCenterAligned && Type is not PageSectionType.SubNav)
        .AddClass("pf-m-shadow-top"           , HasShadowTop)
        .AddClass("pf-m-shadow-bottom"        , HasShadowBottom)
        .AddClass("pf-m-overflow-scroll"      , HasOverflowScroll)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TabIndex { get => HasOverflowScroll ? "0" : null; }
}