using System.Diagnostics.CodeAnalysis;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

/// <summary>
/// The main popover component. The following properties can also be passed into another component
/// that has a property specifically for passing in popover properties.
/// </summary>
public partial class Popover : ComponentBase, IAsyncDisposable
{
    [Inject] private IPopoverInteropModule PopoverInterop { get; set; }
    [Inject] private IWindowObserver WindowObserver { get; set; }
    [Inject] private IJSRuntime JSRuntime { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>@beta Text announced by screen reader when alert severity variant is set to indicate severity level.</summary>
    [Parameter] public string AlertSeverityScreenReaderText { get; set; }

    /// <summary>@beta Severity variants for an alert popover. This modifies the color of the header to match the severity.</summary>
    [Parameter] public AlertVariant? AlertSeverityVariant { get; set; }

    /// <summary>CSS fade transition animation duration.</summary>
    [Parameter] public int AnimationDuration { get; set; } = 300;

    /// <summary>Accessible label, required when header is not present.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Body content</summary>
    [Parameter] public RenderFragment BodyContent { get; set; }

    /// <summary>Aria label for the Close button.</summary>
    [Parameter] public string CloseBtnAriaLabel { get; set; } = "Close";

    /// <summary>Distance of the popover to its target, defaults to 25.</summary>
    [Parameter] public int Distance { get; set; } = 25;

    /// <summary>
    /// If true, tries to keep the popover in view by flipping it if necessary.
    /// If the position is set to 'auto', this prop is ignored.
    /// </summary>
    [Parameter] public bool EnableFlip { get; set; } = true;

    /// <summary>
    /// The desired position to flip the tooltip to if the initial position is not possible.
    /// By setting this prop to 'flip' it attempts to flip the tooltip to the opposite side if there is no space.
    /// You can also pass an array of positions that determines the flip order. It should contain the initial position
    /// followed by alternative positions if that position is unavailable.
    /// Example: Initial position is 'top'. Button with tooltip is in the top right corner. 'flipBehavior' is set to
    /// ['top', 'right', 'left']. Since there is no space to the top, it checks if right is available. There's also no
    /// space to the right, so it finally shows the tooltip on the left.
    /// </summary>
    [Parameter] public PopoverPosition[] FlipBehavior { get; set; } =
    {
      PopoverPosition.Top,
      PopoverPosition.Right,
      PopoverPosition.Bottom,
      PopoverPosition.Left,
      PopoverPosition.Top,
      PopoverPosition.Right,
      PopoverPosition.Bottom
    };

    /// <summary>Footer content</summary>
    [Parameter] public RenderFragment FooterContent { get; set; }

    /// <summary>Removes fixed-width and allows width to be defined by contents.</summary>
    [Parameter] public bool HasAutoWidth { get; set; }

    /// <summary>Allows content to touch edges of popover container.</summary>
    [Parameter] public bool HasNoPadding { get; set; }

    /// <summary>Sets the heading level to use for the popover header. Default is h6.</summary>
    [Parameter] public HeadingLevel? HeaderComponent { get; set; } = HeadingLevel.h6;

    /// <summary>Simple header content to be placed within a title.</summary>
    [Parameter] public RenderFragment HeaderContent { get; set; }

    /// <summary>@beta Icon to be displayed in the popover header.</summary>
    [Parameter] public RenderFragment HeaderIcon { get; set; }

    /// <summary>Hides the popover when a click occurs outside (only works if isVisible is not controlled by the user).</summary>
    [Parameter] public bool HideOnOutsideClick { get; set; } = true;

    /// <summary>id used as part of the various popover elements (popover-${id}-header/body/footer).</summary>
    [Parameter] public string id { get; set; }

    /// <summary>
    /// True to show the popover programmatically. Used in conjunction with the shouldClose prop.
    /// By default, the popover child element handles click events automatically. If you want to control this programmatically,
    /// the popover will not auto-close if the Close button is clicked, ESC key is used, or if a click occurs outside the popover.
    /// Instead, the consumer is responsible for closing the popover themselves by adding a callback listener for the shouldClose prop.
    /// </summary>
    [Parameter] public bool IsVisible { get; set; }

    /// <summary>Maximum width of the popover (default 18.75rem).</summary>
    [Parameter] public string MaxWidth { get; set; }

    /// <summary>Minimum width of the popover (default 6.25rem).</summary>
    [Parameter] public string MinWidth { get; set; }

    /// <summary>Lifecycle function invoked when the popover has fully transitioned out.</summary>
    [Parameter] public EventCallback OnHidden { get; set; }

    /// <summary>Lifecycle function invoked when the popover begins to transition out.</summary>
    [Parameter] public EventCallback OnHide { get; set; }

    /// <summary>Lifecycle function invoked when the popover has been mounted to the DOM.</summary>
    [Parameter] public EventCallback OnMount { get; set; }

    /// <summary>Lifecycle function invoked when the popover begins to transition in.</summary>
    [Parameter] public EventCallback OnShow { get; set; }

    /// <summary>Lifecycle function invoked when the popover has fully transitioned in.</summary>
    [Parameter] public EventCallback OnShown { get; set; }

    /// <summary>
    /// Popover position. Note: With 'enableFlip' set to true,
    /// it will change the position if there is not enough space for the starting position.
    /// The behavior of where it flips to can be controlled through the flipBehavior prop.
    /// </summary>
    [Parameter] public PopoverPosition? Position { get; set; }

    /// <summary>
    /// The reference element to which the Popover is relatively placed to.
    /// If you can wrap the reference with the Popover, you can use the children prop instead.
    /// </summary>
    [Parameter] public string Reference { get; set; }

    /// <summary>
    /// Callback function that is only invoked when isVisible is also controlled. Called when the popover Close button is
    /// clicked, Enter key was used on it, or the ESC key is used.
    /// </summary>
    [Parameter] public EventCallback ShouldClose { get; set; }

    /// <summary>Callback function that is only invoked when isVisible is also controlled. Called when the Enter key is</summary>
    /// <summary>used on the focused trigger</summary>
    [Parameter] public EventCallback ShouldOpen { get; set; }

    /// <summary>Whether to show the close button.</summary>
    [Parameter] public bool ShowClose { get; set; } = true;

    /// <summary>Whether to trap focus in the popover.</summary>
    [Parameter] public bool WithFocusTrap { get; set; }

    /// <summary>z-index of the popover.</summary>
    [Parameter] public int ZIndex { get; set; } = 9999;

    private string CssStyle => new StyleBuilder()
      .AddStyle("min-width"  , MinWidth, HasCustomMinWidth)
      .AddStyle("max-width"  , MaxWidth, HasCustomMaxWidth)
      .AddStyle("visibility" , "collapse", !IsVisible)
      .AddStyle("opacity"    , 0, !IsVisible)
      .AddStyle("opacity"    , 1, IsVisible)
      .AddStyle("z-index"    , ZIndex)
      .AddStyle("transition" , $"opacity {AnimationDuration}ms cubic-bezier(.54, 1.5, .38, 1.11)")
      .AddStyle("position"   , "absolute")
      .AddStyle("top"        , "0")
      .AddStyle("left"       , "0")
      .AddStyle("transform"  , "translate3d(0px,0px,0)", IsVisible && Placement is null)
      .AddStyle("transform"  , () => $"translate3d({Placement.X}px,{Placement.Y}px,0)", IsVisible && Placement is not null)
      .Build();

    private string CssClass => new CssBuilder("pf-c-popover")
      .AddClass("pf-m-success"      , AlertSeverityVariant is AlertVariant.Success)
      .AddClass("pf-m-danger"       , AlertSeverityVariant is AlertVariant.Danger)
      .AddClass("pf-m-warning"      , AlertSeverityVariant is AlertVariant.Warning)
      .AddClass("pf-m-info"         , AlertSeverityVariant is AlertVariant.Info)
      .AddClass("pf-m-default"      , AlertSeverityVariant is AlertVariant.Default)
      .AddClass("pf-m-no-padding"   , HasNoPadding)
      .AddClass("pf-m-width-auto"   , HasAutoWidth)
      .AddClass("pf-m-top"          , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.Top)
      .AddClass("pf-m-bottom"       , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.Bottom)
      .AddClass("pf-m-left"         , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.Left)
      .AddClass("pf-m-right"        , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.Right)
      .AddClass("pf-m-top-left"     , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.TopStart)
      .AddClass("pf-m-top-right"    , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.TopEnd)
      .AddClass("pf-m-bottom-left"  , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.BottomStart)
      .AddClass("pf-m-bottom-right" , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.BottomEnd)
      .AddClass("pf-m-left-top"     , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.LeftStart)
      .AddClass("pf-m-left-bottom"  , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.LeftEnd)
      .AddClass("pf-m-right-top"    , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.RightStart)
      .AddClass("pf-m-right-bottom" , IsVisible && Placement is not null && Placement.Placement is PopoverPosition.RightEnd)
      .Build();

    private string FocusTrapAriaLabel       { get => HeaderContent is not null ? null : AriaLabel; }
    private string FocusTrapAriaLabelledBy  { get => HeaderContent is not null ? HeaderId : null; }
    private string FocusTrapAriaDescribedBy { get => BodyId; }

    private bool HasCustomMinWidth { get => !string.IsNullOrEmpty(MinWidth); }
    private bool HasCustomMaxWidth { get => !string.IsNullOrEmpty(MaxWidth); }

    private string AlertSeverityScreenReaderTextValue
    {
        get => AlertSeverityScreenReaderText ?? $"{AlertSeverityVariant} alert:";
    }

    private string HeaderId { get => $"popover-{id}-header"; }
    private string BodyId   { get => $"popover-{id}-body"; }
    private string FooterId { get => $"popover-{id}-footer"; }

    private bool FocusTrapActive { get; set; }
    private FocusTrapOptions FocusTrapOptions => new FocusTrapOptions
    {
        ReturnFocusOnDeactivate = true,
        ClickOutsideDeactivates = true,
        PreventScroll           = true
    };

    private FloatingPlacement<PopoverPosition> Placement { get; set; }
    private FloatingOptions<PopoverPosition>   Options => new FloatingOptions<PopoverPosition>
    {
        Distance           = Distance,
        Placement          = Position ?? PopoverPosition.Top,
        EnableFlip         = EnableFlip,
        FallbackPlacements = EnableFlip ? FlipBehavior : null
    };

    private IJSObjectReference             _popoverInstance;
    private DotNetObjectReference<Popover> _dotNetObjRef;

    private IDisposable _windowClickSubscription;

    public async ValueTask DisposeAsync()
    {
        await _popoverInstance.InvokeVoidAsync("dispose");
        await _popoverInstance.DisposeAsync();

        _dotNetObjRef?.Dispose();
        _windowClickSubscription?.Dispose();
    }

    [DynamicDependency(nameof(OnReferenceElementClicked))]
    protected override void OnInitialized()
    {
        base.OnInitialized();

        _windowClickSubscription = WindowObserver.OnClick.Subscribe(async e => await OnWindowClick(e));
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (string.IsNullOrEmpty(id))
        {
          throw new InvalidOperationException("Popover: Popover requires an id to be specified");
        }
        if (string.IsNullOrEmpty(Reference))
        {
          throw new InvalidOperationException("Popover: Popover requires a reference element id to be specified");
        }

        FocusTrapActive = WithFocusTrap;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _dotNetObjRef    = DotNetObjectReference.Create(this);
            _popoverInstance = await PopoverInterop.CreateAsync(_dotNetObjRef, Reference);
        }
    }

    private void OnContentMouseDown(MouseEventArgs _)
    {
        if (FocusTrapActive)
        {
            FocusTrapActive = false;
        }
    }

    private async Task ClosePopover(MouseEventArgs _)
    {
        await HideAsync(false);
    }

    private async Task OnWindowClick(MouseEvent e)
    {
        if (HideOnOutsideClick && IsVisible)
        {
            var clickedOnPopover   = e.ComposedPath?.Any(x => x == id);
            var clickedOnReference = e.ComposedPath?.Any(x => x == Reference);
            if (!clickedOnPopover.GetValueOrDefault() && !clickedOnReference.GetValueOrDefault())
            {
                await HideAsync();
            }
        }
    }

    [JSInvokable]
    public async ValueTask OnReferenceElementClicked()
    {
        if (IsVisible)
        {
            await HideAsync();
        }
        else
        {
            await ShowAsync();
        }
    }

    private async Task ShowAsync()
    {
        await OnShow.InvokeAsync();
        IsVisible       = true;
        FocusTrapActive = !FocusTrapActive && WithFocusTrap;
        StateHasChanged();
        Placement = await PopoverInterop.ComputePositionAsync<PopoverPosition>(Reference, id, Options);
        StateHasChanged();
        await OnShown.InvokeAsync();
    }

    private async Task HideAsync(bool notifyStateChanged = true)
    {
        await OnHide.InvokeAsync();
        IsVisible       = false;
        FocusTrapActive = false;
        Placement       = null;
        if (notifyStateChanged)
        {
            StateHasChanged();
        }
        await Task.Delay(AnimationDuration);
        await OnHidden.InvokeAsync();
    }
}