namespace Blatternfly.Components;

public class MenuItem : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [CascadingParameter] public Menu ParentMenu { get; set; }

    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Identifies the component in the Menu onSelect or onActionClick callback.
    [Parameter] public string ItemId { get; set; }

    /// Target navigation link.
    [Parameter] public string To { get; set; }

    /// @beta Flag indicating the item has a checkbox.
    [Parameter] public bool HasCheck { get; set; }

    /// Flag indicating whether the item is active.
    [Parameter] public bool? IsActive { get; set; }

    /// Flag indicating if the item is favorited.
    [Parameter] public bool? IsFavorited { get; set; }

    /// Flag indicating if the item causes a load.
    [Parameter] public bool IsLoadButton { get; set; }

    /// Flag indicating a loading state.
    [Parameter] public bool IsLoading { get; set; }

    /// Callback for item click.
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// Component used to render the menu item.
    [Parameter] public string Component { get; set; } = "button";

    /// Render item as disabled option.
    [Parameter] public bool IsDisabled { get; set; }

    /// Render item with icon.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Render item with one or more actions.
    [Parameter] public RenderFragment Actions { get; set; }

    /// Description of the menu item.
    [Parameter] public RenderFragment Description { get; set; }

    /// Render external link icon.
    [Parameter] public bool IsExternalLink { get; set; }

    /// Flag indicating if the option is selected.
    [Parameter] public bool? IsSelected { get; set; }

    /// Flag indicating the item is focused.
    [Parameter] public bool IsFocused { get; set; }

    /// @beta Drilldown menu of the item. Should be a Menu or DrilldownMenu type.
    [Parameter] public RenderFragment DrilldownMenu { get; set; }

    /// @beta Sub menu direction.
    [Parameter] public MenuItemDirection? Direction { get; set; }

    /// @beta True if item is on current selection path.
    [Parameter] public bool? IsOnPath { get; set; }

    /// Accessibility label.
    [Parameter] public string AriaLabel { get; set; }

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    private string CssClass => new CssBuilder("pf-c-menu__list-item")
        .AddClass("pf-m-disabled"     , IsDisabled)
        .AddClass("pf-m-current-path" , (IsOnPath.HasValue && IsOnPath.Value) || IsOnDrilldownItemPath)
        .AddClass("pf-m-load"         , IsLoadButton)
        .AddClass("pf-m-loading"      , IsLoading)
        .AddClass("pf-m-focused"      , IsFocused)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ComponentCssClass => new CssBuilder("pf-c-menu__item")
        .AddClass("pf-m-selected", IsItemSelected)
        .Build();

    private Menu   RootMenu        { get; set; }
    private string DrilldownMenuId { get; set; }

    private bool IsOnDrilldownItemPath
    {
        get
        {
            if (RootMenu.DrilldownItemPath is null)
            {
                return false;
            }
            return RootMenu.DrilldownItemPath.Contains(ItemId);
            // var isOnPath = RootMenu.DrilldownItemPath.Contains(ItemId);

            // if (isOnPath)
            // {
            //     Console.WriteLine($"IsOnDrilldownItemPath({ItemId}) = {isOnPath}");
            // }

            // return isOnPath;
        }
    }

    private string AriaCurrent
    {
        get
        {
            if (IsActive.HasValue)
            {
                return IsActive.Value ? "page" : null;
            }
            else if (!string.IsNullOrEmpty(ItemId) && ParentMenu?.ActiveItemId is not null)
            {
                return ItemId == RootMenu.ActiveItemId ? "true" : "false";
            }
            return null;
        }
    }

    private bool IsItemSelected
    {
        get
        {
            if (IsSelected.HasValue)
            {
                return IsSelected.Value;
            }
            else if (RootMenu is not null && RootMenu.HasSelection && !string.IsNullOrEmpty(ItemId))
            {
                return RootMenu.IsSelected(ItemId);
            }
            return false;
        }
    }

    private string FavoritedAriaLabel { get => IsFavorited.GetValueOrDefault() ? "starred" : "not starred"; }

    private bool IsChecked
    {
        get => IsSelected ?? false;
        set => IsSelected = value;
    }

    internal void RegisterDrilldownMenuId(string drilldownMenuId)
    {
        DrilldownMenuId = drilldownMenuId;
    }

    private async Task OnItemChecked(bool _)
    {
        await OnItemSelect(null);
    }

    private async Task OnItemSelect(MouseEventArgs args)
    {
        if (RootMenu is not null)
        {
            await RootMenu.OnSelected(args, ItemId);
        }

        await OnClick.InvokeAsync(args);

        if (Direction.HasValue)
        {
            await Drill();
        }
    }

    private async Task OnActionClick(MouseEventArgs args)
    {
        if (RootMenu is not null)
        {
            await RootMenu.ActionClicked(args, ItemId);
        }
    }

    private async Task Drill()
    {
        if (Direction.HasValue)
        {
            if (Direction is MenuItemDirection.Down)
            {
                await RootMenu.DrillIn(ParentMenu.InternalId, DrilldownMenuId, ItemId);
            }
            else
            {
                await RootMenu.DrillOut(ParentMenu.ParentMenu.InternalId, ItemId);
            }
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var rootMenu = ParentMenu;

        if (rootMenu.IsRootMenu)
        {
            RootMenu = rootMenu;
        }
        else
        {
            rootMenu = rootMenu.ParentMenu;

            while (!rootMenu.IsRootMenu)
            {
                rootMenu = rootMenu.ParentMenu;
            }

            RootMenu = rootMenu;
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = !string.IsNullOrEmpty(To) ? (HasCheck ? "label" : "a") : Component;
        var randomId  = ComponentIdGenerator.Generate("pf-random");

        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "role", "none");
        builder.AddElementReferenceCapture(4, __reference => Element = __reference);

        if (Component == "NavLink")
        {
            builder.OpenComponent<NavLink>(5);
        }
        else
        {
            builder.OpenElement(6, component);
        }

        builder.AddAttribute(7, "tabIndex"     , "-1");
        builder.AddAttribute(8, "class"        , ComponentCssClass);
        builder.AddAttribute(9, "aria-current" , AriaCurrent);
        builder.AddAttribute(10, "role"        , "menuitem");
        builder.AddAttribute(11, "onclick"     , EventCallback.Factory.Create<MouseEventArgs>(this, OnItemSelect));

        if (component == "NavLink")
        {
            builder.AddAttribute(12, "href", To);
            builder.AddAttribute(13, "Match", NavLinkMatch.All);
        }
        else if (component == "a")
        {
            builder.AddAttribute(14, "href", To);
            builder.AddAttribute(15, "aria-disabled", IsDisabled ? "true" : null);
        }
        else if (component == "button")
        {
            builder.AddAttribute(16, "type"     , "button");
            builder.AddAttribute(17, "disabled" , IsDisabled ? "true" : null);
        }

        if (IsOnPath.HasValue)
        {
            builder.AddAttribute(18, "aria-expanded", "true");
        }

        builder.OpenElement(19, "span");
        builder.AddAttribute(20, "class", "pf-c-menu__item-main");
        if (Direction is MenuItemDirection.Up)
        {
            builder.OpenElement(21, "span");
            builder.AddAttribute(22, "class", "pf-c-menu__item-toggle-icon");
            builder.OpenComponent<AngleLeftIcon>(23);
            builder.AddAttribute(24, "aria-hidden", true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (Icon is not null)
        {
            builder.OpenElement(25, "span");
            builder.AddAttribute(26, "class", "pf-c-menu__item-icon");
            builder.AddContent(27, Icon);
            builder.CloseElement();
        }
        if (HasCheck)
        {
            builder.OpenElement(28, "span");

            builder.AddAttribute(29, "class", "pf-c-menu__item-check");

            builder.OpenComponent<Checkbox>(30);
            builder.AddAttribute(31, "id", randomId);
            builder.AddAttribute(32, "Component", "span");
            builder.AddAttribute(33, "Value", IsChecked);
            builder.AddAttribute(34, "ValueChanged", EventCallback.Factory.Create<bool>(this, OnItemChecked));
            builder.AddAttribute(35, "IsDisabled", IsDisabled);
            builder.CloseComponent();

            builder.CloseComponent();
        }
        builder.OpenElement(36, "span");
        builder.AddAttribute(37, "class", "pf-c-menu__item-text");
        builder.AddContent(38, ChildContent);
        builder.CloseElement();

        if (IsExternalLink)
        {
            builder.OpenElement(39, "span");
            builder.AddAttribute(40, "class", "pf-c-menu__item-external-icon");
            builder.OpenComponent<ExternalLinkAltIcon>(41);
            builder.AddAttribute(42, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (Direction is MenuItemDirection.Down)
        {
            builder.OpenElement(43, "span");
            builder.AddAttribute(44, "class", "pf-c-menu__item-toggle-icon");
            builder.OpenComponent<AngleRightIcon>(45);
            builder.AddAttribute(46, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (IsItemSelected)
        {
            builder.OpenElement(47, "span");
            builder.AddAttribute(48, "class", "pf-c-menu__item-select-icon");
            builder.OpenComponent<CheckIcon>(49);
            builder.AddAttribute(50, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        builder.CloseElement();
        if (Description is not null && Direction is not MenuItemDirection.Up)
        {
            builder.OpenElement(51, "span");
            builder.AddAttribute(52, "class", "pf-c-menu__item-description");
            builder.OpenElement(53, "span");
            builder.AddContent(54, Description);
            builder.CloseElement();
            builder.CloseElement();
        }
        if (Component == "NavLink")
        {
            builder.CloseComponent();
        }
        else
        {
            builder.CloseElement();
        }

        builder.OpenComponent<CascadingValue<MenuItem>>(55);
        builder.AddAttribute(56, "Value"        , this);
        builder.AddAttribute(56, "IsFixed"      , true);
        builder.AddAttribute(58, "ChildContent" , (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.AddContent(59, DrilldownMenu);
            innerBuilder.AddContent(60, Actions);
            if (IsFavorited.HasValue)
            {
                innerBuilder.OpenComponent<MenuItemAction>(61);
                innerBuilder.AddAttribute(62, "IsFavorited", IsFavorited);
                innerBuilder.AddAttribute(63, "AriaLabel"  , FavoritedAriaLabel);
                innerBuilder.AddAttribute(64, "OnClick"    , EventCallback.Factory.Create<MouseEventArgs>(this, OnActionClick));
                innerBuilder.AddAttribute(65, "tabindex"   , "-1");
                innerBuilder.AddAttribute(66, "ActionId"   , "fav");
                innerBuilder.CloseComponent();
            }
        });
        builder.CloseComponent();

        builder.CloseElement();
    }
}
