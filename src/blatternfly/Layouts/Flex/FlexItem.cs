namespace Blatternfly.Layouts;

public class FlexItem : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Spacers at various breakpoints.
    [Parameter] public FlexSpacerModifiers Spacer { get; set; }

    /// Whether to add flex: grow at various breakpoints.
    [Parameter] public FlexGrowModifiers Grow { get; set; }

    /// Whether to add flex: shrink at various breakpoints.
    [Parameter] public FlexShrinkModifiers Shrink { get; set; }

    /// Value to add for flex property at various breakpoints.
    [Parameter] public FlexModifiers Flex { get; set; }

    /// Value to add for align-self property at various breakpoints.
    [Parameter] public AlignSelfModifiers AlignSelf { get; set; }

    /// Value to use for margin: auto at various breakpoints
    [Parameter] public AlignmentModifiers Align { get; set; }

    /// Whether to set width: 100% at various breakpoints.
    [Parameter] public FlexFullWidth FullWidth { get; set; }

    /// Modifies the flex layout element order property.
    [Parameter] public FlexOrderModifiers Order { get; set; }

    /// Sets the base component to render. defaults to div.
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

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "style", CssStyle);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
