namespace Blatternfly.Components;

public partial class NotificationDrawerList : ComponentBase
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
    ///  Adds styling to the notification drawer list to indicate expand/hide state.
    /// </summary>
    [Parameter] public bool IsHidden { get; set; }

    private string CssClass => new CssBuilder("pf-c-notification-drawer__list")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}