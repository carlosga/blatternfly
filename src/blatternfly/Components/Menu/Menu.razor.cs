namespace Blatternfly.Components;

public partial class Menu : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [CascadingParameter] internal Menu ParentMenu { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Callback for updating when item selection changes. You can also specify onClick on the MenuItem.</summary>
    [Parameter] public EventCallback<(MouseEventArgs, string)> OnSelect { get; set; }

    /// <summary>
    /// Single itemId selection.
    /// You can also specify isSelected on the MenuItem.
    /// </summary>
    [Parameter] public string SelectedItem { get; set; }

    /// <summary>
    /// List of itemIds for multi select.
    /// You can also specify isSelected on the MenuItem.
    /// </summary>
    [Parameter] public IEnumerable<string> SelectedItems { get; set; }

    /// <summary>Callback called when an MenuItems's action button is clicked. You can also specify it within a MenuItemAction.</summary>
    [Parameter] public EventCallback<(MouseEventArgs, string, string)> OnActionClick { get; set; }

    /// <summary>Search input of menu.</summary>
    [Parameter] public bool HasSearchInput { get; set; }

    /// <summary>A callback for when the input value changes.</summary>
    [Parameter] public EventCallback<ChangeEventArgs> InSearchInputChange { get; set; }

    /// <summary>Accessibility label.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>@beta Indicates if menu contains a flyout menu.</summary>
    [Parameter] public bool ContainsFlyout { get; set; }

    /// <summary>@beta Indicating that the menu should have nav flyout styling.</summary>
    [Parameter] public bool IsNavFlyout { get; set; }

    /// <summary>@beta Indicates if menu contains a drilldown menu.</summary>
    [Parameter] public bool ContainsDrilldown { get; set; }

    /// <summary>@beta Indicates if a menu is drilled into */</summary>
    [Parameter] public bool IsMenuDrilledIn { get; set; }

    /// <summary>@beta Indicates the path of drilled in menu itemIds.</summary>
    [Parameter] public IEnumerable<string> DrilldownItemPath { get; set; }

    /// <summary>@beta Array of menus that are drilled in.</summary>
    [Parameter] public IEnumerable<string> DrilledInMenus { get; set; }

    /// <summary>
    /// @beta Callback for drilling into a submenu.
    /// (fromItemId: string, toItemId: string, itemId: string)
    /// </summary>
    [Parameter] public EventCallback<(string fromItemId, string toItemId, string itemId)> OnDrillIn { get; set; }

    /// <summary>
    /// @beta Callback for drilling out of a submenu.
    /// (toItemId: string, itemId: string)
    /// </summary>
    [Parameter] public EventCallback<(string toItemId, string itemId)> OnDrillOut { get; set; }

    /// <summary>
    /// @beta Callback for collecting menu heights.
    /// (menuId: string, height: number)
    /// </summary>
    [Parameter] public EventCallback<(string menuId, double height)> OnGetMenuHeight { get; set; }

    /// <summary>@beta ID of parent menu for drilldown menus.</summary>
    // [Parameter] public string ParentMenu { get; set; }

    /// <summary>@beta ID of the currently active menu for the drilldown variant.</summary>
    [Parameter] public string ActiveMenu { get; set; }

    /// <summary>@beta itemId of the currently active item. You can also specify isActive on the MenuItem.</summary>
    [Parameter] public string ActiveItemId { get; set; }

    /// <summary>Internal flag indicating if the Menu is the root of a menu tree.</summary>
    [Parameter] public bool IsRootMenu { get; set; } = true;

    /// <summary>Indicates if the menu should be without the outer box-shadow.</summary>
    [Parameter] public bool IsPlain { get; set; }

    /// <summary>Indicates if the menu should be srollable.</summary>
    [Parameter] public bool IsScrollable { get; set; }

    internal bool DisableHover { get; set; }

    private string CssClass => new CssBuilder("pf-c-menu")
        .AddClass("pf-m-plain"      , IsPlain)
        .AddClass("pf-m-scrollable" , IsScrollable)
        .AddClass("pf-m-flyout"     , ContainsFlyout)
        .AddClass("pf-m-nav"        , IsNavFlyout)
        .AddClass("pf-m-drilldown"  , ContainsDrilldown)
        .AddClass("pf-m-drilled-in" , IsMenuDrilledInValue)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private Menu RootMenu
    {
        get
        {
            var rootMenu = ParentMenu is not null ? ParentMenu : this;

            if (rootMenu.IsRootMenu)
            {
                return rootMenu;
            }

            rootMenu = rootMenu.ParentMenu;

            while (!rootMenu.IsRootMenu)
            {
                rootMenu = rootMenu.ParentMenu;
            }

            return rootMenu;
        }
    }

    private bool IsMenuDrilledInValue
    {
        get => IsMenuDrilledIn || (RootMenu.DrilledInMenus is not null && RootMenu.DrilledInMenus.Any(x => x == InternalId));
    }

    internal string InternalId   { get => AdditionalAttributes?.GetPropertyValue(HtmlElement.Id); }
    internal bool   HasSelection { get => !string.IsNullOrEmpty(SelectedItem) || (SelectedItems is not null && SelectedItems.Any()); }
    internal bool   IsSelected(string itemId)
    {
        if (!HasSelection || string.IsNullOrEmpty(itemId))
        {
            return false;
        }

        return SelectedItem == itemId || (SelectedItems is not null && SelectedItems.Contains(itemId));
    }

    internal async Task DrillIn(string fromItemId, string toItemId, string itemId)
    {
        await OnDrillIn.InvokeAsync((fromItemId, toItemId, itemId));
    }

    internal async Task DrillOut(string toItemId, string itemId)
    {
        await OnDrillOut.InvokeAsync((toItemId, itemId));
    }

    internal async Task OnSelected(MouseEventArgs args, string itemId)
    {
        await OnSelect.InvokeAsync((args, itemId));
    }

    internal async Task ActionClicked(MouseEventArgs args, string itemId, string actionId = null)
    {
        await OnActionClick.InvokeAsync((args, itemId, actionId));
    }

    internal async Task GetMenuHeight(string menu, double clientHeight)
    {
        await OnGetMenuHeight.InvokeAsync((menu, clientHeight));
    }
}