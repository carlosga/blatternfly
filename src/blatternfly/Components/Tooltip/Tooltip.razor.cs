using System.Diagnostics.CodeAnalysis;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public partial class Tooltip : ComponentBase, IAsyncDisposable
{
    [Inject] private ITooltipInteropModule TooltipInterop { get; set; }
    [Inject] private IJSRuntime JSRuntime { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// aria-labelledby or aria-describedby for tooltip.
    /// The trigger will be cloned to add the aria attribute, and the corresponding id in the form of 'pf-tooltip-#' is added to the content container.
    /// If you don't want that or prefer to add the aria attribute yourself on the trigger, set aria to 'none'.
    /// </summary>
    [Parameter] public TooltipAria Aria { get; set; } = TooltipAria.Describedby;

    /// <summary>
    /// Determines whether the tooltip is an aria-live region. If the reference prop is passed in the
    /// default behavior is 'polite' in order to ensure the tooltip contents is announced to
    /// assistive technologies. Otherwise the default behavior is 'off'.
    /// </summary>
    [Parameter] public TooltipAriaLive? AriaLive { get; set; }

    /// <summary>
    /// The ID of the reference element to which the Tooltip is relatively placed to.
    /// If you can wrap the reference with the Tooltip, you can use the children prop instead.
    /// </summary>
    [Parameter] public string Reference { get; set; }

    /// <summary>Tooltip content.</summary>
    [Parameter] public RenderFragment Content { get; set; }

    /// <summary>Distance of the tooltip to its target, defaults to 15.</summary>
    [Parameter] public int Distance { get; set; } = 15;

    /// <summary>If true, tries to keep the tooltip in view by flipping it if necessary.</summary>
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
    [Parameter] public TooltipPosition[] FlipBehavior { get; set; } =
    {
      TooltipPosition.Top,
      TooltipPosition.Right,
      TooltipPosition.Bottom,
      TooltipPosition.Left,
      TooltipPosition.Top,
      TooltipPosition.Right,
      TooltipPosition.Bottom
    };

    /// <summary>Delay in ms before the tooltip appears.</summary>
    [Parameter] public int EntryDelay { get; set; } = 300;

    /// <summary>
    /// Delay in ms before the tooltip disappears, avoid passing in a value of "0", as users should
    /// be given ample time to move their mouse from the trigger to the tooltip content without the content
    /// being hidden (default 300).
    /// </summary>
    [Parameter] public int ExitDelay { get; set; } = 300;

    /// <summary>Maximum width of the tooltip (default 18.75rem).</summary>
    [Parameter] public string MaxWidth { get; set; } = "18.75rem";

    /// <summary>
    /// Tooltip position. Note: With 'enableFlip' set to true,
    /// it will change the position if there is not enough space for the starting position.
    /// The behavior of where it flips to can be controlled through the flipBehavior prop.
    /// The 'auto' position chooses the side with the most space.
    /// The 'auto' position requires the 'enableFlip' prop to be true.
    /// </summary>
    [Parameter] public TooltipPosition? Position { get; set; } = TooltipPosition.Top;

    /// <summary>
    /// Tooltip trigger: click, mouseenter, focus, manual
    /// Set to manual to trigger tooltip programmatically (through the isVisible prop)
    /// </summary>
    // [Parameter] public string Trigger { get; set; } = "mouseenter focus"; *@

    /// <summary>Flag to indicate that the text content is left aligned.</summary>
    [Parameter] public bool IsContentLeftAligned { get; set; }

    /// <summary>z-index of the tooltip.</summary>
    [Parameter] public int ZIndex { get; set; } = 9999;

    /// <summary>CSS fade transition animation duration.</summary>
    [Parameter] public int AnimationDuration { get; set; } = 300;

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-tooltip--MaxWidth", MaxWidth, !string.IsNullOrEmpty(MaxWidth))
        .AddStyle("opacity"   , 0, !IsVisible)
        .AddStyle("opacity"   , 1)
        .AddStyle("z-index"   , ZIndex)
        .AddStyle("transition", $"opacity {AnimationDuration}ms cubic-bezier(.54, 1.5, .38, 1.11)")
        .AddStyle("position"  , "absolute")
        .AddStyle("top"       , "0")
        .AddStyle("left"      , "0")
        .AddStyle("transform" , () => $"translate3d({Placement.X}px,{Placement.Y}px,0)", IsVisible && Placement is not null)
        .Build();

    private string CssClass => new CssBuilder("pf-c-tooltip")
        .AddClass("pf-m-top"          , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.Top)
        .AddClass("pf-m-bottom"       , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.Bottom)
        .AddClass("pf-m-left"         , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.Left)
        .AddClass("pf-m-right"        , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.Right)
        .AddClass("pf-m-top-left"     , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.TopStart)
        .AddClass("pf-m-top-right"    , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.TopEnd)
        .AddClass("pf-m-bottom-left"  , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.BottomStart)
        .AddClass("pf-m-bottom-right" , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.BottomEnd)
        .AddClass("pf-m-left-top"     , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.LeftStart)
        .AddClass("pf-m-left-bottom"  , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.LeftEnd)
        .AddClass("pf-m-right-top"    , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.RightStart)
        .AddClass("pf-m-right-bottom" , IsVisible && Placement is not null && Placement.Placement is TooltipPosition.RightEnd)
        .Build();

    /// <summary>value for visibility when trigger is 'manual'.</summary>
    private bool IsVisible { get; set; }

    private string TooltipAriaValue
    {
        get => Aria switch
        {
            TooltipAria.None        => "none",
            TooltipAria.Describedby => "describedby",
            TooltipAria.Labelledby  => "labelledby",
            _                       => null
        };
    }

    public string TooltipAriaLiveValue
    {
        get
        {
            if (AriaLive.HasValue)
            {
                return AriaLive switch
                {
                    TooltipAriaLive.Off    => "off",
                    TooltipAriaLive.Polite => "polite",
                    _                      => null
                };
            }

            return string.IsNullOrEmpty(Reference) ? "off" : "polite";
        }
    }

    private string                             InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private FloatingPlacement<TooltipPosition> Placement  { get; set; }
    private FloatingOptions<TooltipPosition>   Options => new FloatingOptions<TooltipPosition>
    {
        Distance           = Distance,
        Placement          = Position ?? TooltipPosition.Top,
        EnableFlip         = EnableFlip,
        FallbackPlacements = EnableFlip ? FlipBehavior : null
    };

    private IJSObjectReference             _tooltipInstance;
    private DotNetObjectReference<Tooltip> _dotNetObjRef;

    public async ValueTask DisposeAsync()
    {
        await _tooltipInstance.InvokeVoidAsync("dispose");
        await _tooltipInstance.DisposeAsync();

        _dotNetObjRef?.Dispose();
    }

    [DynamicDependency(nameof(OnMouseEnter))]
    [DynamicDependency(nameof(OnMouseLeave))]
    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (string.IsNullOrEmpty(InternalId))
        {
            throw new InvalidOperationException("Tooltip: Tooltip requires an id to be specified");
        }
        if (string.IsNullOrEmpty(Reference))
        {
            throw new InvalidOperationException("Tooltip: Tooltip requires a reference element id to be specified");
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _dotNetObjRef    = DotNetObjectReference.Create(this);
            _tooltipInstance = await TooltipInterop.CreateAsync(_dotNetObjRef, Reference);
        }
    }

    [JSInvokable]
    public async ValueTask OnMouseEnter()
    {
        await ShowAsync();
    }

    [JSInvokable]
    public async ValueTask OnMouseLeave()
    {
        await HideAsync();
    }

    private async Task ShowAsync()
    {
        IsVisible = true;
        StateHasChanged();
        Placement = await TooltipInterop.ComputePositionAsync<TooltipPosition>(Reference, InternalId, Options);
        StateHasChanged();
    }

    private async Task HideAsync()
    {
        IsVisible = false;
        Placement = null;
        StateHasChanged();
        await Task.Delay(AnimationDuration);
    }
}