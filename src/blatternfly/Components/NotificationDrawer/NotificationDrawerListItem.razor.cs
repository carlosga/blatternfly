namespace Blatternfly.Components;

public partial class NotificationDrawerListItem : ComponentBase
{
    public ElementReference Element { get; protected set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Modifies the list item to include hover styles on :hover.
    /// </summary>
    [Parameter] public bool IsHoverable { get; set; } = true;

    /// <summary>
    /// Adds styling to the list item to indicate it has been read.
    /// </summary>
    [Parameter] public bool IsRead { get; set; }

    /// <summary>
    /// Callback for when a list item is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>
    /// Tab index for the list item.
    /// </summary>
    [Parameter] public int? TabIndex { get; set; } = 0;

    /// <summary>
    /// Variant indicates the severity level.
    /// </summary>
    [Parameter] public SeverityLevel Variant { get; set; } = SeverityLevel.Default;

    private string CssClass => new CssBuilder("pf-c-notification-drawer__list-item")
        .AddClass("pf-m-hoverable", IsHoverable)
        .AddClass("pf-m-read"     , IsRead)
        .AddClass("pf-m-success"  , Variant is SeverityLevel.Success)
        .AddClass("pf-m-danger"   , Variant is SeverityLevel.Danger)
        .AddClass("pf-m-warning"  , Variant is SeverityLevel.Warning)
        .AddClass("pf-m-info"     , Variant is SeverityLevel.Info)
        .AddClass("pf-m-default"  , Variant is SeverityLevel.Default)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private async Task OnKeyDown(KeyboardEventArgs args)
    {
        // Accessibility function. Click on the list item when pressing Enter or Space on it.
        if (args.Key is Keys.Enter or Keys.Space)
        {
            await OnClick.InvokeAsync();
        }
    }
}