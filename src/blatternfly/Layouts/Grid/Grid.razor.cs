namespace Blatternfly.Layouts;

public partial class Grid : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Adds space between children.
    /// </summary>
    [Parameter] public bool HasGutter { get; set; }

    /// <summary>
    /// The number of rows a column in the grid should span. Value should be a number 1-12.
    /// </summary>
    [Parameter] public int? Span { get; set; }

    /// <summary>
    /// the number of columns all grid items should span on a small device.
    /// </summary>
    [Parameter] public int? Small { get; set; }

    /// <summary>
    /// the number of columns all grid items should span on a medium device.
    /// </summary>
    [Parameter] public int? Medium { get; set; }

    /// <summary>
    /// the number of columns all grid items should span on a large device.
    /// </summary>
    [Parameter] public int? Large { get; set; }

    /// <summary>
    /// the number of columns all grid items should span on a xLarge device.
    /// </summary>
    [Parameter] public int? ExtraLarge { get; set; }

    /// <summary>
    /// the number of columns all grid items should span on a 2xLarge device.
    /// </summary>
    [Parameter] public int? ExtraLarge2 { get; set; }

    /// <summary>
    /// Modifies the flex layout element order property.
    /// </summary>
    [Parameter] public GridOrderModifiers Order { get; set; }

    /// <summary>
    /// Sets the base component to render. defaults to div.
    /// </summary>
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
