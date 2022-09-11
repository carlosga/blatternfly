using System.Reactive.Linq;

namespace Blatternfly.Components;

public partial class NavList : ComponentBase, IAsyncDisposable
{
    public ElementReference Element { get; protected set; }

    [Inject] private IDomUtils DomUtils { get; set; }
    [Inject] private IResizeObserver ResizeObserver { get; set; }

    [CascadingParameter] private Nav Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>aria-label for the left scroll button.</summary>
    [Parameter] public string AriaLeftScroll { get; set; } = "Scroll left";

    /// <summary>aria-label for the right scroll button.</summary>
    [Parameter] public string AriaRightScroll { get; set; } = "Scroll right";

    private string CssClass => new CssBuilder("pf-c-nav__list")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool          _scrollViewAtStart = false;
    private bool          _scrollViewAtEnd   = false;
    private List<NavItem> _items             = new(10);
    private IDisposable   _resizeSubscription;

    public async ValueTask DisposeAsync()
    {
        _resizeSubscription?.Dispose();
        await ResizeObserver.UnobserveAsync(Element);
        await ResizeObserver.DisposeAsync();
    }

    internal void RegisterItem(NavItem item)
    {
        if (!Parent.IsHorizontal)
        {
            return;
        }

        if (!_items.Contains(item))
        {
            _items.Add(item);
        }
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
                .Subscribe(async r => await HandleScrollButtons());

            await HandleScrollButtons();
        }
    }

    private async Task HandleScrollButtons()
    {
        if (_items.Count > 0)
        {
            var firstChild = _items[0].Element;
            var lastChild  = _items[^1].Element;

            // check if it elements are in view
            _scrollViewAtStart = await IsElementInView(Element, firstChild, false);
            _scrollViewAtEnd   = await IsElementInView(Element, lastChild, false);
            Parent.UpdateIsScrollableState(!_scrollViewAtStart || !_scrollViewAtEnd);
        }
    }

    private async Task ScrollLeft()
    {
        NavItem firstElementInView   = null;
        NavItem lastElementOutOfView = null;
        for (var i = 0; i < _items.Count && firstElementInView is null; i++)
        {
            var isInView = await IsElementInView(Element, _items[i].Element, false);
            if (isInView)
            {
                firstElementInView   = _items[i];
                lastElementOutOfView = _items[i - 1];
            }
        }
        if (lastElementOutOfView is not null)
        {
            var scrollSize = await DomUtils.GetScrollSizeAsync(lastElementOutOfView.Element);
            await DomUtils.ScrollLeftAsync(Element, -scrollSize.Width);
        }
        await HandleScrollButtons();
    }

    private async Task ScrollRight()
    {
        NavItem firstElementOutOfView = null;
        NavItem lastElementInView     = null;
        for (var i = _items.Count - 1; i >= 0 && lastElementInView is null; i--)
        {
            var isInView = await IsElementInView(Element, _items[i].Element, false);
            if (isInView)
            {
                lastElementInView     =_items[i];
                firstElementOutOfView =_items[i + 1];
            }
        }
        if (firstElementOutOfView is not null)
        {
            var scrollSize = await DomUtils.GetScrollSizeAsync(firstElementOutOfView.Element);
            await DomUtils.ScrollLeftAsync(Element, scrollSize.Width);
        }
        await HandleScrollButtons();
    }

    private async ValueTask<bool> IsElementInView(
        ElementReference container,
        ElementReference element,
        bool             partial,
        bool             strict = false)
    {
        var containerBounds      = await DomUtils.GetBoundingClientRectAsync(container);
        var elementBounds        = await DomUtils.GetBoundingClientRectAsync(element);
        var containerBoundsLeft  = Math.Floor(containerBounds.Left);
        var containerBoundsRight = Math.Floor(containerBounds.Right);
        var elementBoundsLeft    = Math.Floor(elementBounds.Left);
        var elementBoundsRight   = Math.Floor(elementBounds.Right);

        // Check if in view
        var isTotallyInView   = elementBoundsLeft >= containerBoundsLeft && elementBoundsRight <= containerBoundsRight;
        var isPartiallyInView =
            (partial || (!strict && containerBounds.Width < elementBounds.Width))
                && ((elementBoundsLeft < containerBoundsLeft && elementBoundsRight > containerBoundsLeft)
                || (elementBoundsRight > containerBoundsRight && elementBoundsLeft < containerBoundsRight));

        // Return outcome
        return isTotallyInView || isPartiallyInView;
    }
}