namespace Blatternfly.Layouts;

public class Flex : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public virtual RenderFragment ChildContent { get; set; }

    /// Spacers at various breakpoints.
    [Parameter] public FlexSpacer Spacer { get; set; }

    /// Space items at various breakpoints.
    [Parameter] public FlexSpaceItem SpaceItems { get; set; }

    /// Whether to add flex: grow at various breakpoints.
    [Parameter] public FlexGrow Grow { get; set; }

    /// Whether to add flex: shrink at various breakpoints.
    [Parameter] public FlexShrink Shrink { get; set; }

    /// Value to add for flex property at various breakpoints.
    /// This is the shorthand for flex-grow, flex-shrink and flex-basis combined.
    [Parameter] public FlexShorthand FlexShorthand { get; set;}

    /// Value to add for flex-direction property at various breakpoints.
    [Parameter] public FlexDirection Direction { get; set; }

    /// Value to add for align-items property at various breakpoints.
    [Parameter] public AlignItem AlignItems { get; set; }

    /// Value to add for align-content property at various breakpoints.
    [Parameter] public AlignContent AlignContent { get; set; }

    /// Value to add for align-self property at various breakpoints.
    [Parameter] public AlignSelf AlignSelf { get; set; }

    /// Value to use for margin: auto at various breakpoints.
    [Parameter] public Alignment Align { get; set; }

    /// Value to add for justify-content property at various breakpoints.
    [Parameter] public JustifyContent JustifyContent { get; set; }

    /// Value to set to display property at various breakpoints.
    [Parameter] public FlexDisplay Display { get; set; }

    /// Whether to set width: 100% at various breakpoints.
    [Parameter] public FlexFullWidth FullWidth { get; set; }

    /// Value to set for flex-wrap property at various breakpoints.
    [Parameter] public FlexWrap FlexWrap { get; set; }

    /// Modifies the flex layout element order property.
    [Parameter] public FlexOrder Order { get; set; }

    /// Sets the base component to render. defaults to div.
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
