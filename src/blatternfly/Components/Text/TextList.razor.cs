namespace Blatternfly.Components;

public partial class TextList : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The text list component.</summary>
    [Parameter] public TextListVariants Component { get; set; } = TextListVariants.ul;

    private string CssClass => new CssBuilder()
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Container
    {
        get => Component switch
        {
            TextListVariants.ul => "ul",
            TextListVariants.ol => "ol",
            TextListVariants.dl => "dl",
            _                   => null
        };
    }
}
