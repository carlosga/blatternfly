namespace Blatternfly.Components;

public class TableText : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Determines which element to render as a table text.
    [Parameter] public TableTextVariant Variant { get; set; } = TableTextVariant.span;

    /// Determines which wrapping modifier to apply to the table text.
    [Parameter] public WrapModifier? WrapModifier { get; set; }

    private string CssClass => new CssBuilder("pf-c-table__text")
        .AddClass(WrapModifierClass)
        .Build();

    private string WrapModifierClass
    {
        get => WrapModifier switch
        {
            Blatternfly.Components.WrapModifier.BreakWord  => "pf-m-break-word",
            Blatternfly.Components.WrapModifier.FitContent => "pf-m-fit-content",
            Blatternfly.Components.WrapModifier.Nowrap     => "pf-m-nowrap",
            Blatternfly.Components.WrapModifier.Truncate   => "pf-m-truncate",
            Blatternfly.Components.WrapModifier.Wrap       => "pf-m-wrap",
            _                                              => null
        };
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = Variant is TableTextVariant.span ? "span" : "div";

        builder.OpenElement(0, component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
