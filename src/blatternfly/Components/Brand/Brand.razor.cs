namespace Blatternfly.Components;

public partial class Brand : ComponentBase
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
    /// Attribute that specifies the URL of the image for the Brand.
    /// </summary>
    [Parameter] public string Src { get; set; } = string.Empty;

    /// <summary>
    /// Attribute that specifies the alternate text of the image for the Brand.
    /// </summary>
    [Parameter] public string Alt { get; set; }

    /// <summary>
    /// Widths at various breakpoints for a <picture> Brand.
    /// </summary>
    [Parameter] public BrandWidthModifiers Widths { get; set; }

    /// <summary>
    /// Heights at various breakpoints for a <picture> Brand.
    /// </summary>
    [Parameter] public BrandHeightModifiers Heights { get; set; }

    private string CssClass => new CssBuilder("pf-c-brand")
        .AddClass("pf-m-picture", ChildContent is not null)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddRaw(Widths?.CssStyle , ChildContent is not null && Widths is not null)
        .AddRaw(Heights?.CssStyle, ChildContent is not null && Heights is not null)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();
}