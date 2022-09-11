namespace Blatternfly.Components;

public partial class DrawerCloseButton : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Accessible label for the drawer close button.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; } = "Close drawer panel";

    /// <summary>
    /// A callback for when the close button is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    private string CssClass => new CssBuilder("pf-c-drawer__close")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}