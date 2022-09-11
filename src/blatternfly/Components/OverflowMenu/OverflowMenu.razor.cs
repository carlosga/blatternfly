using System.Reactive.Linq;

namespace Blatternfly.Components;

public partial class OverflowMenu : ComponentBase, IDisposable
{
    [Inject] private IDomUtils DomUtils { get; set; }
    [Inject] private IWindowObserver WindowObserver { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates breakpoint at which to switch between horizontal menu and vertical dropdown.</summary>
    [Parameter] public Breakpoint Breakpoint { get; set; }

    private string CssClass => new CssBuilder("pf-c-overflow-menu")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool IsBelowBreakpoint { get; set; }

    private IDisposable _resizeSubscription;

    public void Dispose()
    {
        _resizeSubscription?.Dispose();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _resizeSubscription = WindowObserver
        .OnResize
        .Throttle(TimeSpan.FromMilliseconds(250))
        .Subscribe(OnWindowResize);
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        var windowSize = await DomUtils.GetWindowSizeAsync();
        HandleResize(windowSize);
    }

    private void OnWindowResize(ResizeEvent e)
    {
        HandleResize(e.InnerSize);
    }

    private void HandleResize(Size<int> size)
    {
        var breakpointWidth = Breakpoint switch
        {
            Breakpoint.Medium      => GlobalWidthBreakpoints.Medium,
            Breakpoint.Large       => GlobalWidthBreakpoints.Large,
            Breakpoint.ExtraLarge  => GlobalWidthBreakpoints.ExtraLarge,
            Breakpoint.ExtraLarge2 => GlobalWidthBreakpoints.ExtraLarge2,
            _                      => throw new InvalidOperationException("OverflowMenu will not be visible without a valid breakpoint.")
        };
        IsBelowBreakpoint = size.Width < breakpointWidth;
        StateHasChanged();
    }
}