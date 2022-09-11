using System.Reactive.Linq;

namespace Blatternfly.Components;

public partial class Page : ComponentBase, IAsyncDisposable
{
    public ElementReference Element { get; protected set; }

    [Inject] private IDomUtils DomUtils { get; set; }
    [Inject] private IResizeObserver ResizeObserver { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Page content</summary>
    [Parameter] public RenderFragment Content { get; set; }

    /// <summary>Header component (e.g. <PageHeader />).</summary>
    [Parameter] public RenderFragment Header { get; set; } // PageHeaderComponent

    /// <summary>Sidebar component for a side nav (e.g. <PageSidebar />).</summary>
    [Parameter] public RenderFragment Sidebar { get; set; } // PageSidebarComponent

    /// <summary>Notification drawer component for an optional notification drawer (e.g. <NotificationDrawer />)</summary>
    [Parameter] public RenderFragment NotificationDrawer { get; set; }

    /// <summary>Flag indicating Notification drawer in expanded.</summary>
    [Parameter] public bool IsNotificationDrawerExpanded { get; set; }

    /// <summary>Flag indicating if breadcrumb width should be limited.</summary>
    [Parameter] public bool IsBreadcrumbWidthLimited { get; set; }

    /// <summary>Skip to content component for the page.</summary>
    [Parameter] public RenderFragment SkipToContent { get; set; }

    /// <summary>Sets the value for role on the <main /> element.</summary>
    [Parameter] public string Role { get; set; }

    /// <summary>an id to use for the [role="main"] element.</summary>
    [Parameter] public string MainContainerId { get; set; }

    /// <summary>tabIndex to use for the [role="main"] element, null to unset it.</summary>
    [Parameter] public int MainTabIndex { get; set; } = -1;

    /// <summary>
    /// If true, manages the sidebar open/close state and there is no need to pass the isNavOpen boolean into
    /// the sidebar component or add a callback onNavToggle function into the PageHeader component.
    /// </summary>
    [Parameter] public bool IsManagedSidebar { get; set; }

    /// <summary>Flag indicating if tertiary nav width should be limited.</summary>
    [Parameter] public bool IsTertiaryNavWidthLimited { get; set; }

    /// <summary>If true, the managed sidebar is initially open for desktop view.</summary>
    [Parameter] public bool DefaultManagedSidebarIsOpen { get; set; } = true;

    /// <summary>Can add callback to be notified when resize occurs, for example to set the sidebar isNav prop to false for a width < 768px</summary>
    [Parameter] public EventCallback<PageResizeEventArgs> OnPageResize { get; set; }

    /// <summary>Breadcrumb component for the page.</summary>
    [Parameter] public RenderFragment Breadcrumb { get; set; }

    /// <summary>Tertiary nav component for the page.</summary>
    [Parameter] public RenderFragment TertiaryNav { get; set; }

    /// <summary>Accessible label, can be used to name main section.</summary>
    [Parameter] public string MainAriaLabel { get; set; }

    /// <summary>Flag indicating if the tertiaryNav should be in a group.</summary>
    [Parameter] public bool IsTertiaryNavGrouped { get; set; }

    /// <summary>Flag indicating if the breadcrumb should be in a group.</summary>
    [Parameter] public bool IsBreadcrumbGrouped { get; set; }

    /// <summary>Additional props of the breadcrumb.</summary>
    [Parameter] public StickyPositionModifiers BreadcrumbStickyOnBreakpoint { get; set; }

    /// <summary>Additional content of the group.</summary>
    [Parameter] public RenderFragment AdditionalGroupedContent { get; set; }

    /// <summary>Additional props of the group.</summary>
    [Parameter] public StickyPositionModifiers PageGroupStickyOnBreakpoint { get; set; }

    /// <summary>Modifier indicating if PageGroup should have a shadow at the top.</summary>
    [Parameter] public bool PageGroupHasShadowTop { get; set; }

    /// <summary>Modifier indicating if PageGroup should have a shadow at the bottom.</summary>
    [Parameter] public bool PageGroupHasShadowBottom { get; set; }

    /// <summary>Flag indicating if the PageGroup has a scrolling overflow.</summary>
    [Parameter] public bool PageGroupHasOverflowScroll { get; set; }

    /// <summary>Callback when notification drawer panel is finished expanding.</summary>
    [Parameter] public EventCallback OnNotificationDrawerExpand { get; set; }

    /// <summary>Page Width</summary>
    [Parameter] public int? Width  { get; set; }

    /// <summary>Page Height</summary>
    [Parameter] public int? Height { get; set; }

    /// <summary>Indicates whether the nav is open on a desktop view.</summary>
    [Parameter] public bool DesktopIsNavOpen { get; set; }

    /// <summary>Indicates whether the nav is open on a mobile view.</summary>
    [Parameter] public bool MobileIsNavOpen  { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<bool> DesktopIsNavOpenChanged { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<bool> MobileIsNavOpenChanged { get; set; }

    private string CssClass => new CssBuilder("pf-c-page")
        .AddClass("pf-m-resize-observer"                            , Width.HasValue && Height.HasValue)
        .AddClass($"pf-m-breakpoint-{WidthBreakpointValue}"         , Width.HasValue)
        .AddClass($"pf-m-height-breakpoint-{HeightBreakpointValue}" , Height.HasValue)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    internal Breakpoint? WidthBreakpoint       { get => GlobalWidthBreakpoints.GetBreakpoint(Width); }
    private  string      WidthBreakpointValue  { get => GlobalWidthBreakpoints.GetBreakpointString(Width); }

    internal Breakpoint? HeightBreakpoint      { get => GlobalHeightBreakpoints.GetBreakpoint(Height); }
    private  string      HeightBreakpointValue { get => GlobalHeightBreakpoints.GetBreakpointString(Height); }

    private  bool IsGrouped
    {
        get => IsTertiaryNavGrouped || IsBreadcrumbGrouped || AdditionalGroupedContent is not null;
    }

    private IDisposable _resizeSubscription;

    public async ValueTask DisposeAsync()
    {
        _resizeSubscription?.Dispose();
        await ResizeObserver.UnobserveAsync(Element);
        await ResizeObserver.DisposeAsync();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        DesktopIsNavOpen = !IsManagedSidebar || DefaultManagedSidebarIsOpen;
        MobileIsNavOpen  = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            await ResizeObserver.ObserveAsync(Element);

            _resizeSubscription = ResizeObserver
                .OnResize
                .Throttle(TimeSpan.FromMilliseconds(250))
                .Subscribe(async r => await OnHandleResize(r));

            await Resize(await DomUtils.GetClientSizeAsync(Element));
        }
    }

    private async Task HandleMainClick(MouseEventArgs args)
    {
        var isMobile = await IsMobile();
        if (isMobile && MobileIsNavOpen)
        {
            MobileIsNavOpen = false;
            await MobileIsNavOpenChanged.InvokeAsync(MobileIsNavOpen);
        }
    }

    private async Task<bool> IsMobile()
    {
        var width = await GetWindowWidth();
        return width < GlobalWidthBreakpoints.ExtraLarge;
    }

    private async Task<int> GetWindowWidth()
    {
        var rect = await DomUtils.GetClientSizeAsync(Element);
        return rect.Width;
    }

    private async Task OnHandleResize(ResizeEvent e)
    {
        await Resize(e.InnerSize);
    }

    private async Task Resize(Size<int> size)
    {
        var isMobile = await IsMobile();
        await OnPageResize.InvokeAsync(new PageResizeEventArgs(isMobile, size));
        Width  = size.Width;
        Height = size.Height;
        StateHasChanged();
    }
}