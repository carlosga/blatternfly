namespace Blatternfly.Components;

public class TableText : BaseComponent
{
    /// Determines which element to render as a table text.
    [Parameter] public TableTextVariant Variant { get; set; } = TableTextVariant.span;
    
    /// Determines which wrapping modifier to apply to the table text.
    [Parameter] public WrapModifier? WrapModifier { get; set; }

     private CssBuilder CssClass => new CssBuilder("pf-c-table__text")
         .AddClass(WrapModifierClass);
             
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
        var component = Variant == TableTextVariant.span ? "span" : "div";
        
        builder.OpenElement(1, component);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
