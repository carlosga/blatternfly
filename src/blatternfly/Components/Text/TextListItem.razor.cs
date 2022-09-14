namespace Blatternfly.Components;

public partial class TextListItem : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The text list item component.</summary>
    [Parameter] public TextListItemVariants Component { get; set; } = TextListItemVariants.li;

    private string CssClass => new CssBuilder()
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Container
    {
        get => Component switch
        {
            TextListItemVariants.li => "li",
            TextListItemVariants.dt => "dt",
            TextListItemVariants.dd => "dd",
            _                       => null
        };
    }
}
