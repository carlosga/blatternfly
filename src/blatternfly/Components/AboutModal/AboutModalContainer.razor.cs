namespace Blatternfly.Components;

public partial class AboutModalContainer : ComponentBase
{
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
    /// Flag to show the About Modal.
    /// </summary>
    [Parameter]
    public bool IsOpen { get; set; }

    /// <summary>
    /// Product Name.
    /// </summary>
    [Parameter]
    public string ProductName { get; set; }

    /// <summary>
    /// Trademark information.
    /// </summary>
    [Parameter]
    public string Trademark { get; set; }

    /// <summary>
    /// the URL of the image for the Brand.
    /// </summary>
    [Parameter]
    public string BrandImageSource { get; set; }

    /// <summary>
    /// the alternate text of the Brand image.
    /// </summary>
    [Parameter]
    public string BrandImageAlternateText { get; set; }

    /// <summary>
    /// the URL of the image for the background.
    /// </summary>
    [Parameter]
    public string BackgroundImageSource { get; set; }

    /// <summary>
    /// id to use for About Modal Box aria labeled by.
    /// </summary>
    [Parameter]
    public string AboutModalBoxHeaderId { get; set; }

    /// <summary>
    /// id to use for About Modal Box aria described by  
    /// </summary>
    [Parameter]
    public string AboutModalBoxContentId { get; set; }

    /// <summary>
    /// Set close button aria label
    /// </summary>
    [Parameter]
    public string CloseButtonAriaLabel { get; set; }

    /// <summary>
    /// Flag to disable focus trap.
    /// </summary>
    [Parameter]
    public bool DisableFocusTrap { get; set; }

    /// <summary>
    /// Prevents the about modal from rendering content inside a container; allows for more flexible layouts.
    /// </summary>
    [Parameter]
    public bool NoAboutModalBoxContentContainer { get; set; }

    /// <summary>
    /// A callback for when the close button is clicked.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// <summary>
    /// Modal handles pressing of the Escape key and closes the modal.
    /// </summary>
    [Parameter]
    public EventCallback<KeyboardEventArgs> OnEscapePress { get; set; }

    private bool IsFocusTrapActive { get => !DisableFocusTrap; }
    
    private FocusTrapOptions FocusTrapOptions { get; } = new FocusTrapOptions
    {
        TabbableOptions = new TabbableOptions{DisplayCheck = TabbableDisplayCheck.None}
    };

    private async Task KeydownHandler(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Escape)
        {
            await OnEscapePress.InvokeAsync(args);
        }
    }
}
