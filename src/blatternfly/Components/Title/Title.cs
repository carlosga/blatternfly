namespace Blatternfly.Components;

public class Title : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// The size of the Title.
    [Parameter] public TitleSizes? Size { get; set; }

    /// The heading level to use.
    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h1;

    private string CssClass => new CssBuilder("pf-c-title")
        .AddClass(SizeCssClass)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string SizeCssClass
    {
        get => (Size ?? DefaultSize) switch
        {
            TitleSizes.Medium      => "pf-m-md",
            TitleSizes.Large       => "pf-m-lg",
            TitleSizes.ExtraLarge  => "pf-m-xl",
            TitleSizes.ExtraLarge2 => "pf-m-2xl",
            TitleSizes.ExtraLarge3 => "pf-m-3xl",
            TitleSizes.ExtraLarge4 => "pf-m-4xl",
            _                      => null
        };
    }

    private TitleSizes? DefaultSize
    {
        get => HeadingLevel switch
        {
            HeadingLevel.h1 => TitleSizes.ExtraLarge2,
            HeadingLevel.h2 => TitleSizes.ExtraLarge,
            HeadingLevel.h3 => TitleSizes.Large,
            HeadingLevel.h4 => TitleSizes.Medium,
            HeadingLevel.h5 => TitleSizes.Medium,
            HeadingLevel.h6 => TitleSizes.Medium,
            _               => null
        };
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, HeadingLevel.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
