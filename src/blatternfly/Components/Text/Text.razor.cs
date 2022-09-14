namespace Blatternfly.Components;

public partial class Text : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The text component.</summary>
    [Parameter] public TextVariants Component { get; set; } = TextVariants.p;

    /// <summary>Flag to indicate the link has visited styles applied if the browser determines the link has been visited.</summary>
    [Parameter] public bool IsVisitedLink { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-m-visited", IsVisitedLink && Component == TextVariants.a)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Container
    {
        get => Component switch
        {
            TextVariants.blockquote => "blockquote",
            TextVariants.h1         => "h1",
            TextVariants.h2         => "h2",
            TextVariants.h3         => "h3",
            TextVariants.h4         => "h4",
            TextVariants.h5         => "h5",
            TextVariants.h6         => "h6",
            TextVariants.a          => "a",
            TextVariants.p          => "p",
            TextVariants.pre        => "pre",
            TextVariants.small      => "small",
            _                       => null
        };
    }
}
