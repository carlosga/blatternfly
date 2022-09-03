using Blatternfly.Interop;

namespace Blatternfly.Components;

public class Modal : ComponentBase, IDisposable
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Flag to show the modal.
    [Parameter] public bool IsOpen { get; set; }

    /// Complex header (more than just text), supersedes title for header content.
    [Parameter] public RenderFragment Header { get; set; }

    /// Optional help section for the Modal Header.
    [Parameter] public string Help { get; set; }

    /// Simple text content of the Modal Header, also used for aria-label on the body.
    [Parameter] public string Title { get; set; }

    /// Optional alert icon (or other) to show before the title of the Modal Header
    /// When the predefined alert types are used the default styling will be automatically applied.
    [Parameter] public ModalTitleVariant? TitleIconVariant { get; set; }

    /// Custom icon for the modal title.
    [Parameter] public RenderFragment CustomTitleIcon { get; set; }

    /// Optional title label text for screen readers.
    [Parameter] public string TitleLabel { get; set; }

    /// Id to use for Modal Box label.
    [Parameter] public string AriaLabelledBy { get; set; }

    /// Accessible descriptor of modal.
    [Parameter] public string AriaLabel { get; set; }

    /// Id to use for Modal Box descriptor.
    [Parameter] public string AriaDescribedBy { get; set; }

    /// Accessible label applied to the modal box body.
    /// This should be used to communicate important information about the modal box body div if needed, such as that it is scrollable.
    [Parameter] public string BodyAriaLabel { get; set; }

    /// Accessible role applied to the modal box body.
    /// This will default to region if a body aria label is applied.
    /// Set to a more appropriate role as applicable based on the modal content and context.
    [Parameter] public string BodyAriaRole { get; set; }

    /// Flag to show the close button in the header area of the modal.
    [Parameter] public bool ShowClose { get; set; } = true;

    /// Custom footer.
    [Parameter] public RenderFragment Footer { get; set; }

    /// Action buttons to add to the standard Modal Footer, ignored if `footer` is given.
    [Parameter] public RenderFragment Actions { get; set; }

    /// A callback for when the close button is clicked.
    [Parameter] public EventCallback OnClose { get; set; }

    /// Default width of the Modal..
    [Parameter] public string Width { get; set; }

    /// Flag to disable focus trap.
    [Parameter] public bool DisableFocusTrap { get; set; }

    /// Description of the modal.
    [Parameter] public RenderFragment Description { get; set; }

    /// Variant of the modal.
    [Parameter] public ModalVariant Variant { get; set; } = ModalVariant.Default;

    /// Alternate position of the modal.
    [Parameter] public ModalPosition? Position { get; set; }

    /// Offset from alternate position. Can be any valid CSS length/percentage.
    [Parameter] public string PositionOffset { get; set; }

    /// Flag indicating if modal content should be placed in a modal box body wrapper.
    [Parameter] public bool HasNoBodyWrapper { get; set; }

    /// Modal handles pressing of the Escape key and closes the modal.
    /// If you want to handle this yourself you can use this callback function.
    [Parameter] public EventCallback<KeyboardEventArgs> OnEscapePress { get; set; }

    [Inject] private IPortalConnector PortalConnector { get; set; }
    [Inject] private IDomUtils        DomUtils { get; set; }

    private static int _currentId = 0;

    private string InternalId   { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string BoxId        { get; set; }
    private string LabelId      { get; set; }
    private string DescriptorId { get; set; }

    private IDisposable _portalConnectedSubscription;
    private IDisposable _portalDisconnectedSubscription;

    public void Dispose()
    {
        _portalConnectedSubscription?.Dispose();
        _portalDisconnectedSubscription?.Dispose();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var boxIdNum        = Interlocked.Increment(ref _currentId);
        var labelIdNum      = boxIdNum + 1;
        var descriptorIdNum = boxIdNum + 2;

        BoxId        = !string.IsNullOrEmpty(InternalId) ? InternalId : $"pf-modal-part-{boxIdNum}";
        LabelId      = $"pf-modal-part-{labelIdNum}";
        DescriptorId = $"pf-modal-part-{descriptorIdNum}";

        _portalConnectedSubscription    = PortalConnector.OnConnect.Subscribe(async p => await OnPortalConnected(p));
        _portalDisconnectedSubscription = PortalConnector.OnDisconnect.Subscribe(async p => await OnPortalDisconnected(p));
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(AriaLabel) && string.IsNullOrEmpty(AriaLabelledBy))
        {
          throw new InvalidOperationException("Modal: Specify at least one of: title, aria-label, aria-labelledby.");
        }

        if (string.IsNullOrEmpty(AriaLabel) && string.IsNullOrEmpty(AriaLabelledBy) && (HasNoBodyWrapper || Header is not null))
        {
          throw new InvalidOperationException(
            "Modal: When using hasNoBodyWrapper or setting a custom header, ensure you assign an accessible name to the the modal container with aria-label or aria-labelledby."
          );
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
		builder.OpenComponent<Portal>(0);
		builder.AddAttribute(1, "IsOpen", IsOpen);
		builder.AddAttribute(2, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder builder1)
		{
			builder1.OpenComponent<ModalContent>(3);
			builder1.AddMultipleAttributes(4, AdditionalAttributes);
			builder1.AddAttribute( 5, "AriaLabel"       , AriaLabel);
			builder1.AddAttribute( 6, "AriaDescribedBy" , AriaDescribedBy);
			builder1.AddAttribute( 7, "AriaLabelledBy"  , AriaLabelledBy);
            builder1.AddAttribute( 8, "AriaLabelledBy"  , AriaLabelledBy);
            builder1.AddAttribute( 9, "BodyAriaLabel"   , BodyAriaLabel);
            builder1.AddAttribute(10, "BodyAriaRole"    , BodyAriaRole);
			builder1.AddAttribute(11, "BoxId"           , BoxId);
			builder1.AddAttribute(12, "DescriptorId"    , DescriptorId);
			builder1.AddAttribute(13, "DisableFocusTrap", DisableFocusTrap);
			builder1.AddAttribute(14, "HasNoBodyWrapper", HasNoBodyWrapper);
			builder1.AddAttribute(15, "IsOpen"          , IsOpen);
			builder1.AddAttribute(16, "LabelId"         , LabelId);
			builder1.AddAttribute(17, "Position"        , Position);
			builder1.AddAttribute(18, "PositionOffset"  , PositionOffset);
			builder1.AddAttribute(19, "ShowClose"       , ShowClose);
			builder1.AddAttribute(20, "Title"           , Title);
			builder1.AddAttribute(21, "TitleIconVariant", TitleIconVariant);
			builder1.AddAttribute(22, "TitleLabel"      , TitleLabel);
			builder1.AddAttribute(23, "Variant"         , Variant);
			builder1.AddAttribute(24, "Width"           , Width);
            builder1.AddAttribute(25, "Help"            , Help);
            builder1.AddAttribute(26, "Actions"         , Actions);
            builder1.AddAttribute(27, "CustomTitleIcon" , CustomTitleIcon);
            builder1.AddAttribute(28, "Description"     , Description);
            builder1.AddAttribute(29, "Footer"          , Footer);
            builder1.AddAttribute(30, "Header"          , Header);
			builder1.AddAttribute(31, "OnClose"         , EventCallback.Factory.Create(this, OnClose));
            builder1.AddAttribute(32, "OnEscapePress"   , EventCallback.Factory.Create<KeyboardEventArgs>(this, OnEscapePressHandler));
            builder1.AddAttribute(33, "ChildContent"    , ChildContent);
			builder1.CloseComponent();
        });
        builder.CloseComponent();
    }

    private async Task OnEscapePressHandler(KeyboardEventArgs args)
    {
        if (IsOpen)
        {
            if (OnEscapePress.HasDelegate)
            {
                await OnEscapePress.InvokeAsync(args);
            }
            else
            {
                await OnClose.InvokeAsync();
            }
        }
    }

    private async ValueTask OnPortalConnected(Portal _)
    {
        await DomUtils.SetBodyClass("pf-c-backdrop__open");
    }

    private async ValueTask OnPortalDisconnected(Portal _)
    {
        await DomUtils.RemoveBodyClass("pf-c-backdrop__open");
    }
}
