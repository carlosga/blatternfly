namespace Blatternfly.Components;

public partial class JumpLinks : ComponentBase, IAsyncDisposable
{
    public ElementReference Element { get; protected set; }

    [Inject] private IJumpLinksInteropModule JumpLinksInterop { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Whether to center children.</summary>
    [Parameter] public bool IsCentered { get; set; }

    /// <summary>Whether the layout of children is vertical or horizontal.</summary>
    [Parameter] public bool IsVertical { get; set; }

    /// <summary>Label to add to nav element.</summary>
    [Parameter] public string Label { get; set; }

    /// <summary>Flag to always show the label when using `expandable`</summary>
    [Parameter] public bool AlwaysShowLabel { get; set; } = true;

    /// <summary>Aria-label to add to nav element. Defaults to label.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Selector for the scrollable element to spy on. Not passing a selector disables spying.</summary>
    [Parameter] public string ScrollableSelector { get; set; }

    /// <summary>The index of the child Jump link to make active.</summary>
    [Parameter] public int ActiveIndex { get; set; } = 0;

    /// <summary>
    /// Selector of an element that shoule be used as Offset to add to `scrollPosition`,
    /// potentially for a masthead which content scrolls under.
    /// </summary>
    [Parameter] public string OffsetSelector { get; set; }

    /// <summary>When to collapse/expand at different breakpoints</summary>
    [Parameter] public ExpandableModifiers Expandable { get; set; }

    /// <summary>On mobile whether or not the JumpLinks starts out expanded</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Aria label for expandable toggle</summary>
    [Parameter] public string ToggleAriaLabel { get; set; } = "Toggle jump links";

    private string CssClass => new CssBuilder("pf-c-jump-links")
        .AddClass("pf-m-center"   , IsCentered)
        .AddClass("pf-m-vertical" , IsVertical)
        .AddClass(Expandable?.CssClass())
        .AddClass("pf-m-expanded" , IsExpanded)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private IDisposable _activeIndexSubscription;

    public async ValueTask DisposeAsync()
    {
        _activeIndexSubscription?.Dispose();
        if (HasScrollSpy)
        {
            await JumpLinksInterop.UnobserveAsync(ScrollableSelector);
        }
        await JumpLinksInterop.DisposeAsync();
    }

    private string AriaLabelValue { get => AriaLabel ?? Label; }
    private string AriaExpanded   { get => IsExpanded ? "true" : "false"; }
    private bool   HasScrollSpy   { get => !string.IsNullOrEmpty(ScrollableSelector); }

    private List<JumpLinksItem>     Items     { get; set; }
    private List<JumpLinksItemNode> Hierarchy { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (HasScrollSpy)
        {
            Hierarchy                = new List<JumpLinksItemNode>();
            _activeIndexSubscription = JumpLinksInterop.OnSetActiveIndex.Subscribe(e => OnSetActiveIndex(e));
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (HasScrollSpy)
            {
                FlattenHierarchy();
                ActivateItem(ActiveIndex);
                await JumpLinksInterop.ObserveAsync(Element, ScrollableSelector, OffsetSelector);
            }
        }
    }

    internal void RegisterItem(JumpLinksItem item)
    {
        if (HasScrollSpy)
        {
            if (item.ParentItem is null)
            {
                Hierarchy.Add(new JumpLinksItemNode { JumpLink = item });
            }
            else
            {
                var parent = Hierarchy.SingleOrDefault(x => x.JumpLink == item.ParentItem);
                if (parent is not null)
                {
                if (parent.Children is null)
                {
                    parent.Children = new List<JumpLinksItem>();
                }
                parent.Children.Add(item);
                }
            }
        }
    }

    internal async ValueTask LockScrollAsync()
    {
        await JumpLinksInterop.LockScrollAsync(ScrollableSelector);
    }

    internal async ValueTask UnlockScrollAsync()
    {
        await JumpLinksInterop.UnlockScrollAsync(ScrollableSelector);
    }

    internal void ActivateItem(JumpLinksItem item)
    {
        if (item is not null)
        {
            ActivateItem(Items.IndexOf(item));
        }
    }

    private void FlattenHierarchy()
    {
        Items = new List<JumpLinksItem>(Hierarchy.Count);

        foreach (var jumpLink in Hierarchy)
        {
            Items.Add(jumpLink.JumpLink);
            if (jumpLink.Children.Count > 0)
            {
                Items.AddRange(jumpLink.Children);
            }
        }

        Hierarchy.Clear();
    }

    private void OnSetActiveIndex(int activeIndex)
    {
        if (HasScrollSpy)
        {
            if (activeIndex != ActiveIndex)
            {
                ActivateItem(activeIndex);
            }
        }
    }

    private void ActivateItem(int activeIndex)
    {
        // Deactive the currently active item
        Items[ActiveIndex].Deactivate();
        // Active the new active item
        Items[activeIndex].Activate();
        // Update active index
        ActiveIndex = activeIndex;
    }

    private void OnToggle(MouseEventArgs _)
    {
        IsExpanded = !IsExpanded;
    }
}