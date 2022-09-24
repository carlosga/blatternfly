namespace Blatternfly.Layouts;

public partial class Flex : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Spacers at various breakpoints.</summary>
    [Parameter] public FlexSpacerModifiers Spacer { get; set; }

    /// <summary>Space items at various breakpoints.</summary>
    [Parameter] public FlexSpaceItemModifiers SpaceItems { get; set; }

    /// <summary>Whether to add flex: grow at various breakpoints.</summary>
    [Parameter] public FlexGrowModifiers Grow { get; set; }

    /// <summary>Whether to add flex: shrink at various breakpoints.</summary>
    [Parameter] public FlexShrinkModifiers Shrink { get; set; }

    /// <summary>
    /// Value to add for flex property at various breakpoints.
    /// This is the shorthand for flex-grow, flex-shrink and flex-basis combined.
    /// </summary>
    [Parameter] public FlexModifiers FlexShorthand { get; set;}

    /// <summary>Value to add for flex-direction property at various breakpoints.</summary>
    [Parameter] public FlexDirectionModifiers Direction { get; set; }

    /// <summary>Value to add for align-items property at various breakpoints.</summary>
    [Parameter] public AlignItemModifiers AlignItems { get; set; }

    /// <summary>Value to add for align-content property at various breakpoints.</summary>
    [Parameter] public AlignContentModifiers AlignContent { get; set; }

    /// <summary>Value to add for align-self property at various breakpoints.</summary>
    [Parameter] public AlignSelfModifiers AlignSelf { get; set; }

    /// <summary>Value to use for margin: auto at various breakpoints.</summary>
    [Parameter] public AlignmentModifiers Align { get; set; }

    /// <summary>Value to add for justify-content property at various breakpoints.</summary>
    [Parameter] public JustifyContentModifiers JustifyContent { get; set; }

    /// <summary>Value to set to display property at various breakpoints.</summary>
    [Parameter] public FlexDisplayModifiers Display { get; set; }

    /// <summary>Whether to set width: 100% at various breakpoints.</summary>
    [Parameter] public FlexFullWidthModifiers FullWidth { get; set; }

    /// <summary>Value to set for flex-wrap property at various breakpoints.</summary>
    [Parameter] public FlexWrapModifiers FlexWrap { get; set; }

    /// <summary>Modifies the flex layout element order property.</summary>
    [Parameter] public FlexOrderModifiers Order { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";

    private string CssStyle => new StyleBuilder()
        .AddStyle(Order?.CssStyle)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string CssClass => new CssBuilder("pf-l-flex")
        .AddClass(Spacer?.CssClass())
        .AddClass(SpaceItems?.CssClass())
        .AddClass(Grow?.CssClass())
        .AddClass(Shrink?.CssClass())
        .AddClass(FlexShorthand?.CssClass())
        .AddClass(Direction?.CssClass())
        .AddClass(AlignItems?.CssClass())
        .AddClass(AlignContent?.CssClass())
        .AddClass(AlignSelf?.CssClass())
        .AddClass(Align?.CssClass())
        .AddClass(JustifyContent?.CssClass())
        .AddClass(Display?.CssClass())
        .AddClass(FullWidth?.CssClass())
        .AddClass(FlexWrap?.CssClass())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
