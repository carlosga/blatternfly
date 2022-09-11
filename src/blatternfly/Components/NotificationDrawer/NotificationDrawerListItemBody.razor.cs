namespace Blatternfly.Components;

public partial class NotificationDrawerListItemBody : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary> List item timestamp.</summary>
    [Parameter] public RenderFragment Timestamp { get; set; }

    private string CssClass => new CssBuilder("pf-c-notification-drawer__list-item-description")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}