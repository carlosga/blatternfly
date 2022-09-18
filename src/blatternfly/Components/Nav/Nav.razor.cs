namespace Blatternfly.Components;

public partial class Nav : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Accessible label for the nav when there are multiple navs on the page.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Indicates which theme color to use.</summary>
    [Parameter] public ThemeVariant Theme { get; set; } = ThemeVariant.Dark;

    /// <summary>For horizontal navs.</summary>
    [Parameter] public NavVariant Variant { get; set; } = NavVariant.Default;

    /// <summary>Callback for updating when item selection changes.</summary>
    [Parameter] public EventCallback<NavItem> OnSelect { get; set; }

    /// <summary>Callback for when a list is expanded or collapsed.</summary>
    [Parameter] public EventCallback<NavExpandable> OnToggle { get; set; }

    private string CssClass => new CssBuilder("pf-c-nav")
        .AddClass("pf-m-light"             , Theme is ThemeVariant.Light)
        .AddClass("pf-m-scrollable"        , IsScrollable)
        .AddClass("pf-m-horizontal"        , IsHorizontal)
        .AddClass("pf-m-tertiary"          , Variant is NavVariant.Tertiary)
        .AddClass("pf-m-horizontal-subnav" , Variant is NavVariant.HorizontalSubNav)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    internal string ActiveGroupId { get; private set; }
    internal string ActiveItemId  { get; private set; }
    internal bool   IsHorizontal
    {
        get => Variant is NavVariant.Horizontal or NavVariant.Tertiary or NavVariant.HorizontalSubNav;
    }

    private bool   IsScrollable      { get; set; }
    private string InternalAriaLabel { get => AriaLabel ?? (Variant is NavVariant.Tertiary ? "Local" : "Global"); }

    internal async Task Select(NavItem item)
    {
        ActiveGroupId = item.GroupId;
        ActiveItemId  = item.ItemId;

        await OnSelect.InvokeAsync(item);
    }

    internal async Task Expand(NavExpandable expandable)
    {
        await OnToggle.InvokeAsync(expandable);
    }

    internal void UpdateIsScrollableState(bool isScrollable)
    {
        if (IsScrollable != isScrollable)
        {
            IsScrollable = isScrollable;
            StateHasChanged();
        }
    }
}