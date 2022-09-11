namespace Blatternfly.Components;

public partial class CardTitle : ComponentBase
{
    [CascadingParameter] private Card Parent { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Sets the base component to render. defaults to div.
    /// </summary>
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-c-card__title")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TitleId { get => Parent?.CardId is not null ? $"{Parent?.CardId}-title" : null; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent?.RegisterTitleId(TitleId);
    }
}
