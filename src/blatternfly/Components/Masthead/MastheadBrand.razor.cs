namespace Blatternfly.Components;

public partial class MastheadBrand : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// Component type of the masthead brand.
    [Parameter]
    public MastheadBrandComponent Component { get; set; } = MastheadBrandComponent.a;

    private string CssClass => new CssBuilder("pf-c-masthead__brand")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Container { get => Component is MastheadBrandComponent.a ? "a" : "div"; }
}
