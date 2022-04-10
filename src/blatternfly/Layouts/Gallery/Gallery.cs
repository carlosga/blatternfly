namespace Blatternfly.Layouts;

public class Gallery : LayoutBase
{
    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    /// Minimum widths at various breakpoints.
    [Parameter] public GalleryBreakpoints MinWidths { get; set; }

    /// Maximum widths at various breakpoints.
    [Parameter] public GalleryBreakpoints MaxWidths { get; set; }

    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min"       , () => MinWidths.Default    , MinWidths is not null && MinWidths.HasDefault)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-sm" , () => MinWidths.Small      , MinWidths is not null && MinWidths.HasSmall)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-md" , () => MinWidths.Medium     , MinWidths is not null && MinWidths.HasMedium)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-lg" , () => MinWidths.Large      , MinWidths is not null && MinWidths.HasLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-xl" , () => MinWidths.ExtraLarge , MinWidths is not null && MinWidths.HasExtraLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-2xl", () => MinWidths.ExtraLarge2, MinWidths is not null && MinWidths.HasExtraLarge2)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max"       , () => MaxWidths.Default    , MaxWidths is not null && MaxWidths.HasDefault)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-sm" , () => MaxWidths.Small      , MaxWidths is not null && MaxWidths.HasSmall)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-md" , () => MaxWidths.Medium     , MaxWidths is not null && MaxWidths.HasMedium)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-lg" , () => MaxWidths.Large      , MaxWidths is not null && MaxWidths.HasLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-xl" , () => MaxWidths.ExtraLarge , MaxWidths is not null && MaxWidths.HasExtraLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-2xl", () => MaxWidths.ExtraLarge2, MaxWidths is not null && MaxWidths.HasExtraLarge2)
        .Build();

    private string CssClass => new CssBuilder("pf-l-gallery")
        .AddClass("pf-m-gutter", HasGutter)
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
