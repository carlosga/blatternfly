namespace Blatternfly.Components;

public partial class NotificationDrawerListItemHeader : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Add custom icon for notification drawer list item header.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>Notification drawer list item header screen reader title.</summary>
    [Parameter] public string ScreenReaderTitle { get; set; }

    /// <summary>Notification drawer list item title.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>Variant indicates the severity level.</summary>
    [Parameter] public SeverityLevel Variant { get; set; } = SeverityLevel.Default;

    /// <summary>Truncate title to number of lines.</summary>
    [Parameter] public int TruncateTitle { get; set; }

    /// <summary>Position of the tooltip which is displayed if text is truncated.</summary>
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    /// <summary>Sets the heading level to use for the group title. Default is h2.</summary>
    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h2;

    private string CssClass => new CssBuilder("pf-c-notification-drawer__list-item-header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TitleCssClass => new CssBuilder("pf-c-notification-drawer__list-item-header-title")
        .AddClass("pf-m-truncate", TruncateTitle > 0)
        .Build();

    private string TitleCssStyle => new StyleBuilder()
        .AddStyle("--pf-c-notification-drawer__list-item-header-title--max-lines", TruncateTitle, TruncateTitle > 0)
        .Build();

    private TitleHeadingLevel TitleRef { get; set; }

    private bool   IsTooltipVisible { get; set; }
    private string TitleId          { get; set; }
    private string TooltipId        { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        TitleId   = ComponentIdGenerator.Generate("pf-c-notification-drawer-group-toggle-title");
        TooltipId = $"{TitleId}-tooltip";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            IsTooltipVisible = await DomUtils.HasTruncatedHeightAsync(TitleRef.Element);
            if (IsTooltipVisible)
            {
                StateHasChanged();
            }
        }
    }
}