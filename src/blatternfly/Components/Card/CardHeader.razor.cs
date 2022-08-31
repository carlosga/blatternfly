namespace Blatternfly.Components;

public partial class CardHeader : ComponentBase
{
    /// <summary>
    /// Parent card component.
    /// </summary>
    [CascadingParameter]
    private Card Parent { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Callback expandable card.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnExpand { get; set; }

    /// <summary>
    /// Additional props for expandable toggle button.
    /// </summary>
    [Parameter]
    public IReadOnlyDictionary<string, object> ToggleButtonProps { get; set; }

    /// <summary>
    /// Whether to right-align expandable toggle button.
    /// </summary>
    [Parameter]
    public bool IsToggleRightAligned { get; set; }

    private string CssClass => new CssBuilder("pf-c-card__header")
        .AddClass("pf-m-toggle-right", IsToggleRightAligned)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaExpanded { get => Parent.IsExpanded ? "true" : null; }
}