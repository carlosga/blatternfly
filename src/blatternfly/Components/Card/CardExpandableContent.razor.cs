namespace Blatternfly.Components;

public partial class CardExpandableContent : ComponentBase
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
    /// Parent card component.
    /// </summary>
    [CascadingParameter] public Card Parent { get; set; }

    private string CssClass => new CssBuilder("pf-c-card__expandable-content")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}