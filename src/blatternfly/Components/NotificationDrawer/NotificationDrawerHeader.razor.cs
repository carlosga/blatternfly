namespace Blatternfly.Components;

public partial class NotificationDrawerHeader : ComponentBase
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
    /// Adds custom accessible text to the notification drawer close button.
    /// </summary>
    [Parameter] public string CloseButtonAriaLabel { get; set; } = "Close";

    /// <summary>
    /// Notification drawer heading count.
    /// </summary>
    [Parameter] public int? Count { get; set; }

    /// <summary>
    /// Notification drawer heading custom text which can be used instead of providing count/unreadText.
    /// </summary>
    [Parameter] public string CustomText { get; set; }

    /// <summary>
    /// Callback for when close button is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// <summary>
    /// Notification drawer heading title.
    /// </summary>
    [Parameter] public string Title { get; set; } = "Notifications";

    /// <summary>
    /// Notification drawer heading unread text used in combination with a count.
    /// </summary>
    [Parameter] public string UnreadText { get; set; } = "unread";

    private string CssClass => new CssBuilder("pf-c-notification-drawer__header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string UnreadTextWithCount { get => $"{Count} {UnreadText}"; }
}