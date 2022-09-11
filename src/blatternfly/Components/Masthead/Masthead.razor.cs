namespace Blatternfly.Components;

public partial class Masthead : ComponentBase
{
    [CascadingParameter] private Page ParentPage { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Background theme color of the masthead.
    /// </summary>
    [Parameter] public MastheadBackground BackgroundColor { get; set; } = MastheadBackground.Dark;

    /// <summary>
    /// Display type at various breakpoints.
    /// </summary>
    [Parameter] public MastheadDisplayModifiers Display { get; set; } = new () { Medium = MastheadDisplay.Inline };

    /// <summary>
    /// Insets at various breakpoints.
    /// </summary>
    [Parameter] public InsetModifiers Inset { get; set; }

    private string CssClass => new CssBuilder("pf-c-masthead")
        .AddClass("pf-m-light"    , BackgroundColor is MastheadBackground.Light)
        .AddClass("pf-m-light-200", BackgroundColor is MastheadBackground.Light200)
        .AddClass(Display?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClass(Inset?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}