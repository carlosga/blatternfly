namespace Blatternfly.Components;

public partial class ModalContent : ComponentBase
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
    /// Variant of the modal.
    /// </summary>
    [Parameter]
    public ModalVariant Variant { get; set; } = ModalVariant.Default;

    /// <summary>
    /// Alternate position of the modal.
    /// </summary>
    [Parameter]
    public ModalPosition? Position { get; set; }

    /// <summary>
    /// Offset from alternate position. Can be any valid CSS length/percentage.
    /// </summary>
    [Parameter]
    public string PositionOffset { get; set; }

    /// <summary>
    /// Flag to show the modal.
    /// </summary>
    [Parameter]
    public bool IsOpen { get; set; }

    /// <summary>
    /// Complex header (more than just text), supersedes title for header content.
    /// </summary>
    [Parameter]
    public RenderFragment Header { get; set; }

    /// <summary>
    /// Optional help section for the Modal Header.
    /// </summary>
    [Parameter]
    public string Help { get; set; }

    /// <summary>
    /// Description of the modal.
    /// </summary>
    [Parameter]
    public RenderFragment Description { get; set; }

    /// <summary>
    /// Simple text content of the Modal Header, also used for aria-label on the body.
    /// </summary>
    [Parameter]
    public string Title { get; set; }

    /// <summary>
    /// Optional alert icon (or other) to show before the title of the Modal Header
    /// When the predefined alert types are used the default styling will be automatically applied.
    /// </summary>
    [Parameter]
    public ModalTitleVariant? TitleIconVariant { get; set; }

    /// <summary>
    /// Custom icon for the modal title.
    /// </summary>
    [Parameter]
    public RenderFragment CustomTitleIcon { get; set; }

    /// <summary>
    /// Optional title label text for screen readers.
    /// </summary>
    [Parameter]
    public string TitleLabel { get; set; }

    /// <summary>
    /// Id of Modal Box label.
    /// </summary>
    [Parameter]
    public string AriaLabelledBy { get; set; }

    /// <summary>
    /// Accessible descriptor of modal.
    /// </summary>
    [Parameter]
    public string AriaLabel { get; set; }

    /// <summary>
    /// Id of Modal Box description.
    /// </summary>
    [Parameter]
    public string AriaDescribedBy { get; set; }

    /// <summary>
    /// Accessible label applied to the modal box body.
    /// This should be used to communicate important information about the modal box body div if needed, such as that it is scrollable.
    /// </summary>
    [Parameter]
    public string BodyAriaLabel { get; set; }

    /// <summary>
    /// Accessible role applied to the modal box body.
    /// This will default to region if a body aria label is applied.
    /// Set to a more appropriate role as applicable based on the modal content and context.
    /// </summary>
    [Parameter]
    public string BodyAriaRole { get; set; }

    /// <summary>
    /// Flag to show the close button in the header area of the modal.
    /// </summary>
    [Parameter]
    public bool ShowClose { get; set; } = true;

    /// <summary>
    /// Default width of the content.
    /// </summary>
    [Parameter]
    public string Width { get; set; }

    /// <summary>
    /// Custom footer.
    /// </summary>
    [Parameter]
    public RenderFragment Footer { get; set; }

    /// <summary>
    /// Action buttons to add to the standard Modal Footer, ignored if `footer` is given.
    /// </summary>
    [Parameter]
    public RenderFragment Actions { get; set; }

    /// <summary>
    /// A callback for when the close button is clicked.
    /// </summary>
    [Parameter]
    public EventCallback OnClose { get; set; }

    /// <summary>
    /// Id of the ModalBox container.
    /// </summary>
    [Parameter]
    public string BoxId { get; set; }

    /// <summary>
    /// Id of the ModalBox title.
    /// </summary>
    [Parameter]
    public string LabelId { get; set; }

    /// <summary>
    /// Id of the ModalBoxBody.
    /// </summary>
    [Parameter]
    public string DescriptorId { get; set; }

    /// <summary>
    /// Flag to disable focus trap.
    /// </summary>
    [Parameter]
    public bool DisableFocusTrap { get; set; }

    /// <summary>
    /// Flag indicating if modal content should be placed in a modal box body wrapper.
    /// </summary>
    [Parameter]
    public bool HasNoBodyWrapper { get; set; }

    /// <summary>
    /// Modal handles pressing of the Escape key and closes the modal.
    /// </summary>
    [Parameter]
    public EventCallback<KeyboardEventArgs> OnEscapePress { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-m-danger"  , TitleIconVariant is ModalTitleVariant.Danger)
        .AddClass("pf-m-warning" , TitleIconVariant is ModalTitleVariant.Warning)
        .AddClass("pf-m-success" , TitleIconVariant is ModalTitleVariant.Success)
        .AddClass("pf-m-default" , TitleIconVariant is ModalTitleVariant.Default)
        .AddClass("pf-m-info"    , TitleIconVariant is ModalTitleVariant.Info)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private FocusTrapOptions FocusTrapOptions { get; } = new FocusTrapOptions
    {
        TabbableOptions = new TabbableOptions { DisplayCheck = TabbableDisplayCheck.None }
    };

    private string BoxStyle
    {
        get => !string.IsNullOrEmpty(Width) ? $"width: {Width};" : null;
    }

    private string ModalBodyId
    {
        get => Description is null && string.IsNullOrEmpty(AriaDescribedBy) ? DescriptorId : null;
    }

    private string AriaDescribedByValue
    {
        get
        {
            if (!string.IsNullOrEmpty(AriaDescribedBy))
            {
                return AriaDescribedBy;
            }
            return HasNoBodyWrapper ? null : DescriptorId;
            }
        }

    private string AriaLabelledByFormatted
    {
        get
        {
            if (string.IsNullOrEmpty(AriaLabelledBy))
            {
                return null;
            }
            var idRefList = new List<string>(4);
            if (!string.IsNullOrEmpty(AriaLabel) && !string.IsNullOrEmpty(BoxId))
            {
                idRefList.Add(AriaLabel);
                idRefList.Add(BoxId);
            }
            if (!string.IsNullOrEmpty(AriaLabelledBy))
            {
                idRefList.Add(AriaLabelledBy);
            }
            if (!string.IsNullOrEmpty(Title))
            {
                idRefList.Add(LabelId);
            }
            return string.Join(' ', idRefList);
        }
    }

    private string DefaultModalBodyAriaRole
    {
        get => !string.IsNullOrEmpty(BodyAriaLabel) ? "region" : null;
    }

    private string BodyRole
    {
        get => !string.IsNullOrEmpty(BodyAriaRole) ? BodyAriaRole : DefaultModalBodyAriaRole;
    }

    private async Task KeydownHandler(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Escape)
        {
           await OnEscapePress.InvokeAsync(args);
        }
    }
}