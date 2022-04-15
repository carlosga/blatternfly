namespace Blatternfly.Components;

public class MastheadBrand : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Component type of the masthead brand.
    [Parameter] public MastheadBrandComponent Component { get; set; } = MastheadBrandComponent.a;

    private string CssClass => new CssBuilder("pf-c-masthead__brand")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = Component is MastheadBrandComponent.a ? "a" : "div";

        builder.OpenElement(0, component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "tabindex", "0");
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
