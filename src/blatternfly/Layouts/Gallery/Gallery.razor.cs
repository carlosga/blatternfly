namespace Blatternfly.Layouts;

public partial class Gallery : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds space between children.</summary>
    [Parameter] public bool HasGutter { get; set; }

    /// <summary>Minimum widths at various breakpoints.</summary>
    [Parameter] public GalleryBreakpoints MinWidths { get; set; }

    /// <summary>Maximum widths at various breakpoints.</summary>
    [Parameter] public GalleryBreakpoints MaxWidths { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min"       , MinWidths?.Default    , MinWidths is not null && MinWidths.HasDefault)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-sm" , MinWidths?.Small      , MinWidths is not null && MinWidths.HasSmall)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-md" , MinWidths?.Medium     , MinWidths is not null && MinWidths.HasMedium)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-lg" , MinWidths?.Large      , MinWidths is not null && MinWidths.HasLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-xl" , MinWidths?.ExtraLarge , MinWidths is not null && MinWidths.HasExtraLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--min-on-2xl", MinWidths?.ExtraLarge2, MinWidths is not null && MinWidths.HasExtraLarge2)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max"       , MaxWidths?.Default    , MaxWidths is not null && MaxWidths.HasDefault)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-sm" , MaxWidths?.Small      , MaxWidths is not null && MaxWidths.HasSmall)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-md" , MaxWidths?.Medium     , MaxWidths is not null && MaxWidths.HasMedium)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-lg" , MaxWidths?.Large      , MaxWidths is not null && MaxWidths.HasLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-xl" , MaxWidths?.ExtraLarge , MaxWidths is not null && MaxWidths.HasExtraLarge)
        .AddStyle("--pf-l-gallery--GridTemplateColumns--max-on-2xl", MaxWidths?.ExtraLarge2, MaxWidths is not null && MaxWidths.HasExtraLarge2)
        .Build();

    private string CssClass => new CssBuilder("pf-l-gallery")
        .AddClass("pf-m-gutter", HasGutter)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
