namespace Blatternfly.Components;

public partial class NotificationDrawerGroup : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Notification drawer group count.
    /// </summary>
    [Parameter] public int Count { get; set; }

    /// <summary>
    /// Adds styling to the group to indicate expanded state.
    /// </summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>
    /// Adds styling to the group to indicate whether it has been read.
    /// </summary>
    [Parameter] public bool IsRead { get; set; }

    /// <summary>
    /// Callback for when group button is clicked to expand.
    /// </summary>
    [Parameter] public EventCallback<bool> OnExpand { get; set; }

    /// <summary>
    /// Notification drawer group title.
    /// </summary>
    [Parameter] public string Title { get; set; }

    /// <summary>
    /// Truncate title to number of lines.
    /// </summary>
    [Parameter] public int TruncateTitle { get; set; }

    /// <summary>
    /// Position of the tooltip which is displayed if text is truncated.
    /// </summary>
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    /// <summary>
    /// Sets the heading level to use for the group title. Default is h1.
    /// </summary>
    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h1;

    private string TitleCssStyle => new StyleBuilder()
        .AddStyle("--pf-c-notification-drawer__group-toggle-title--max-lines", TruncateTitle, TruncateTitle > 0)
        .Build();

    private string CssClass => new CssBuilder("pf-c-notification-drawer__group")
        .AddClass("pf-m-expanded", IsExpanded)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaExpanded { get => IsExpanded ? "true" : "false"; }

    private ElementReference TitleRef { get; set; }

    private bool   ShouldRenderTooltip { get; set; }
    private string TitleId             { get; set; }
    private string TooltipId           { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        TitleId   = ComponentIdGenerator.Generate("pf-c-notification-drawer__group-toggle-title");
        TooltipId = $"{TitleId}-tooltip";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            ShouldRenderTooltip = await DomUtils.HasTruncatedHeightAsync(TitleRef);
            if (ShouldRenderTooltip)
            {
                StateHasChanged();
            }
        }
    }

    private async Task HandleToggle(MouseEventArgs _)
    {
        IsExpanded = !IsExpanded;
        await OnExpand.InvokeAsync(IsExpanded);
    }

    private async Task OnKeyDown(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Enter || args.Key == Keys.Space)
        {
            IsExpanded = !IsExpanded;
            await OnExpand.InvokeAsync(IsExpanded);
        }
    }
}