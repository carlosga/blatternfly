using Blatternfly.Interop;

namespace Blatternfly.Components;

public partial class AboutModal : ComponentBase
{
    [Inject] 
    private IDomUtils DomUtils { get; set; }
    
    [Inject] 
    private IPortalConnector PortalConnector  { get; set; }
    
    [Inject] 
    private IComponentIdGenerator ComponentIdGenerator { get; set; }

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
    /// Flag to show the about modal.
    /// </summary>
    [Parameter] 
    public bool IsOpen { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    [Parameter]
    public string ProductName { get; set; }

    /// <summary>
    /// Trademark information.
    /// </summary>
    [Parameter]
    public string Trademark { get; set; }

    /// <summary>
    /// The URL of the image for the brand.
    /// </summary>
    [Parameter]
    public string BrandImageSource { get; set; }

    /// <summary>
    /// The alternate text of the brand image.
    /// </summary>
    [Parameter]
    public string BrandImageAlternateText { get; set; }

    /// <summary>
    /// The URL of the image for the background.
    /// </summary>
    [Parameter]
    public string BackgroundImageSource { get; set; }

    /// <summary>
    /// Prevents the about modal from rendering content inside a container; allows for more flexible layouts.
    /// </summary>
    [Parameter]
    public bool NoAboutModalBoxContentContainer { get; set; }

    /// <summary>
    /// Set aria label to the close button.
    /// </summary>
    [Parameter]
    public string CloseButtonAriaLabel { get; set; }

    /// <summary>
    /// Flag to disable focus trap.
    /// </summary>
    [Parameter]
    public bool DisableFocusTrap { get; set; }

    /// <summary>
    /// A callback for when the close button is clicked.
    /// </summary>
    [Parameter]
    public EventCallback OnClose { get; set; }

    private IDisposable _portalConnectedSubscription;
    private IDisposable _portalDisconnectedSubscription;
    private string Id { get; set; }

    private string AboutModalBoxHeaderId { get; set; }

    private string AboutModalBoxContentId { get; set; }

    public void Dispose()
    {
        _portalConnectedSubscription?.Dispose();
        _portalDisconnectedSubscription?.Dispose();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id = ComponentIdGenerator.Generate("pf-c-aboutmodal");
        
        AboutModalBoxHeaderId  = $"pf-about-modal-title-{Id}";
        AboutModalBoxContentId = $"pf-about-modal-content-{Id}";

        _portalConnectedSubscription    = PortalConnector.OnConnect.Subscribe(async p => await OnPortalConnected(p));
        _portalDisconnectedSubscription = PortalConnector.OnDisconnect.Subscribe(async p => await OnPortalDisconnected(p));
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (!string.IsNullOrEmpty(BrandImageSource) && string.IsNullOrEmpty(BrandImageAlternateText))
        {
            throw new InvalidOperationException($"AboutModal: {nameof(BrandImageAlternateText)} is required when a {nameof(BrandImageSource)} is specified");
        }
    }

    internal async Task CloseAsync()
    {
        IsOpen = false;
        StateHasChanged();
        await OnClose.InvokeAsync();
    }

    private async Task OnCloseHandler(MouseEventArgs args)
    {
        await CloseAsync();
    }

    private async Task OnEscapePressHandler(KeyboardEventArgs args)
    {
        await OnClose.InvokeAsync();
    }

    private async ValueTask OnPortalConnected(Portal portal)
    {
        await DomUtils.SetBodyClass("pf-c-backdrop__open");
    }

    private async ValueTask OnPortalDisconnected(Portal portal)
    {
        await DomUtils.RemoveBodyClass("pf-c-backdrop__open");
    }
}
