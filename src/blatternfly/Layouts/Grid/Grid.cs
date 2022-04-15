namespace Blatternfly.Layouts;

public class Grid : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    /// The number of rows a column in the grid should span. Value should be a number 1-12.
    [Parameter] public int? Span { get; set; }

    /// the number of columns all grid items should span on a small device.
    [Parameter] public int? Small { get; set; }

    /// the number of columns all grid items should span on a medium device.
    [Parameter] public int? Medium { get; set; }

    /// the number of columns all grid items should span on a large device.
    [Parameter] public int? Large { get; set; }

    /// the number of columns all grid items should span on a xLarge device.
    [Parameter] public int? ExtraLarge { get; set; }

    /// the number of columns all grid items should span on a 2xLarge device.
    [Parameter] public int? ExtraLarge2 { get; set; }

    /// Modifies the flex layout element order property.
    [Parameter] public GridOrder Order { get; set; }

    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    private string CssStyle => new StyleBuilder()
        .AddStyle(Order?.CssStyle)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string CssClass => new CssBuilder("pf-l-grid")
        .AddClass($"pf-m-all-{Span}-col"              , Span.HasValue)
        .AddClass($"pf-m-all-{Small}-col-on-sm"       , Small.HasValue)
        .AddClass($"pf-m-all-{Medium}-col-on-md"      , Medium.HasValue)
        .AddClass($"pf-m-all-{Large}-col-on-lg"       , Large.HasValue)
        .AddClass($"pf-m-all-{ExtraLarge}-col-on-xl"  , ExtraLarge.HasValue)
        .AddClass($"pf-m-all-{ExtraLarge2}-col-on-2xl", ExtraLarge2.HasValue)
        .AddClass("pf-m-gutter"                       , HasGutter)
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

    protected override void OnParametersSet()
    {
        ValidateRange(nameof(Span), Span);
        ValidateRange(nameof(Small), Small);
        ValidateRange(nameof(Medium), Medium);
        ValidateRange(nameof(Large), Large);
        ValidateRange(nameof(ExtraLarge), ExtraLarge);
        ValidateRange(nameof(ExtraLarge2), ExtraLarge2);

        base.OnParametersSet();
    }

    private static void ValidateRange(string name, int? value)
    {
        if (!value.HasValue)
        {
            return;
        }

        if (value.Value < 0 || value.Value > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}
