namespace Blatternfly.Components;

public partial class NotificationBadge : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Determines the variant of the notification badge.</summary>
    [Parameter] public NotificationBadgeVariant Variant { get; set; }

    /// <summary>A number displayed in the badge alongside the icon.</summary>
    [Parameter] public int? Count { get; set; }

    /// <summary>Adds accessible text to the Notification Badge.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Icon to display for attention variant.</summary>
    [Parameter] public RenderFragment AttentionIcon { get; set; }

    /// <summary>Icon do display in notification badge.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    private string CssClass => new CssBuilder("pf-c-notification-badge")
        .AddClass("pf-m-attention", Variant is NotificationBadgeVariant.Attention)
        .AddClass("pf-m-read"     , Variant is NotificationBadgeVariant.Read)
        .AddClass("pf-m-unread"   , Variant is NotificationBadgeVariant.Unread)
        .Build();
}