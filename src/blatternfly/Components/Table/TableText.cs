namespace Blatternfly.Components;

public partial class TableText : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Determines which element to render as a table text.</summary>
    [Parameter] public TableTextVariant Variant { get; set; } = TableTextVariant.span;

    /// <summary>Determines which wrapping modifier to apply to the table text.</summary>
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
