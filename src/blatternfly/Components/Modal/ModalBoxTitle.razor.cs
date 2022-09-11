namespace Blatternfly.Components;

public partial class ModalBoxTitle : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the modal box header title.
    /// </summary>
    [Parameter]
    public RenderFragment Title { get; set; }

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

    private string CssClass => new CssBuilder("pf-c-modal-box__title")
        .AddClass("pf-m-icon", TitleIconVariant.HasValue)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes?.GetPropertyValue(HtmlAttributes.Id); }

    private bool   IsTooltipVisible { get; set; }
    private string TitleId          { get; set; }
    private string TooltipId        { get; set; }
    private string Label
    {
        get
        {
            if (!string.IsNullOrEmpty(TitleLabel))
            {
                return TitleLabel;
            }
            else if (TitleIconVariant.HasValue && TitleIconVariant is not ModalTitleVariant.Custom)
            {
                return $"{TitleIconVariant} alert:";
            }
            else
            {
                return TitleLabel;
            }
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        TitleId   = InternalId ?? ComponentIdGenerator.Generate("pf-c-modal-box__title");
        TooltipId = $"{TitleId}-tooltip";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            IsTooltipVisible = await DomUtils.HasTruncatedWidthAsync(Element);
            if (IsTooltipVisible)
            {
                StateHasChanged();
            }
        }
    }
}
