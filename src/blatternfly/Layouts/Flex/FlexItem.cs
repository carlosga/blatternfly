namespace Blatternfly.Layouts;

public partial class FlexItem : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Spacers at various breakpoints.</summary>
    [Parameter] public FlexSpacerModifiers Spacer { get; set; }

    /// <summary>Whether to add flex: grow at various breakpoints.</summary>
    [Parameter] public FlexGrowModifiers Grow { get; set; }

    /// <summary>Whether to add flex: shrink at various breakpoints.</summary>
    [Parameter] public FlexShrinkModifiers Shrink { get; set; }

    /// <summary>Value to add for flex property at various breakpoints.</summary>
    [Parameter] public FlexModifiers Flex { get; set; }

    /// <summary>Value to add for align-self property at various breakpoints.</summary>
    [Parameter] public AlignSelfModifiers AlignSelf { get; set; }

    /// <summary>Value to use for margin: auto at various breakpoints</summary>
    [Parameter] public AlignmentModifiers Align { get; set; }

    /// <summary>Whether to set width: 100% at various breakpoints.</summary>
    [Parameter] public FlexFullWidthModifiers FullWidth { get; set; }

    /// <summary>Modifies the flex layout element order property.</summary>
    [Parameter] public FlexOrderModifiers Order { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";

    private string CssStyle => new StyleBuilder()
        .AddStyle(Order?.CssStyle)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string CssClass => new CssBuilder()
        .AddClass(Spacer?.CssClass())
        .AddClass(Grow?.CssClass())
        .AddClass(Shrink?.CssClass())
        .AddClass(Flex?.CssClass())
        .AddClass(AlignSelf?.CssClass())
        .AddClass(Align?.CssClass())
        .AddClass(FullWidth?.CssClass())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
