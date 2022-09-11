namespace Blatternfly.Components;

public partial class Skeleton : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>The width of the Skeleton. Must specify pixels or percentage.</summary>
    [Parameter] public string Width { get; set; }

    /// <summary>The height of the Skeleton. Must specify pixels or percentage.</summary>
    [Parameter] public string Height { get; set; }

    /// <summary>The font size height of the Skeleton.</summary>
    [Parameter] public SkeletonFontSize? FontSize { get; set; }

    /// <summary>The shape of the Skeleton.</summary>
    [Parameter] public SkeletonShape? Shape { get; set; }

    /// <summary>Text read just to screen reader users.</summary>
    [Parameter] public string ScreenreaderText { get; set; }

    private string CssClass => new CssBuilder("pf-c-skeleton")
        .AddClass("pf-m-text-sm"  , FontSize is SkeletonFontSize.Small)
        .AddClass("pf-m-text-md"  , FontSize is SkeletonFontSize.Medium)
        .AddClass("pf-m-text-lg"  , FontSize is SkeletonFontSize.Large)
        .AddClass("pf-m-text-xl"  , FontSize is SkeletonFontSize.ExtraLarge)
        .AddClass("pf-m-text-2xl" , FontSize is SkeletonFontSize.ExtraLarge2)
        .AddClass("pf-m-text-3xl" , FontSize is SkeletonFontSize.ExtraLarge3)
        .AddClass("pf-m-text-4xl" , FontSize is SkeletonFontSize.ExtraLarge4)
        .AddClass("pf-m-circle"   , Shape is SkeletonShape.Circle)
        .AddClass("pf-m-square"   , Shape is SkeletonShape.Square)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-skeleton--Width"  , Width , !string.IsNullOrEmpty(Width))
        .AddStyle("--pf-c-skeleton--Height" , Height, !string.IsNullOrEmpty(Height))
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();
}