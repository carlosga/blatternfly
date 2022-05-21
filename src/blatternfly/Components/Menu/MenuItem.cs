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

    /// @beta Flyout menu.
    [Parameter] public RenderFragment FlyoutMenu { get; set; }

    /// @beta Callback function when mouse leaves trigger.
    [Parameter] public EventCallback OnShowFlyout { get; set; }

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
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ComponentCssClass => new CssBuilder("pf-c-menu__item")
        .AddClass("pf-m-selected", IsItemSelected)
        .Build();

    private string DrilldownMenuId { get; set; }

    private bool IsOnDrilldownItemPath
    {
        get
        {
            if (ParentMenu?.DrilldownItemPath is null)
            {
                return false;
            }
            return ParentMenu.DrilldownItemPath.Contains(ItemId);
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
                return ItemId == ParentMenu.ActiveItemId ? "true" : "false";
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
            else if (ParentMenu is not null && ParentMenu.HasSelection && !string.IsNullOrEmpty(ItemId))
            {
                return ParentMenu.IsSelected(ItemId);
            }
            return false;
        }
    }

    private string FavoritedAriaLabel { get => IsFavorited.GetValueOrDefault() ? "starred" : "not starred"; }

    // const flyoutVisible = ref === flyoutRef;
    private bool HasFlyout { get => FlyoutMenu is not null; }

    private bool FlyoutVisible { get => false; }

    private bool IsChecked
    {
        get => IsSelected ?? false;
        set => IsSelected = value;
    }

    internal void RegisterDrilldownMenuId(string drilldownMenuId)
    {
        DrilldownMenuId = drilldownMenuId;
    }

    private async Task ShowFlyout(bool show)
    {
        if (OnShowFlyout.HasDelegate && show)
        {
            await OnShowFlyout.InvokeAsync();
        }
    }

    private async Task OnMouseOver(MouseEventArgs args)
    {
        if (ParentMenu is not null && ParentMenu.DisableHover)
        {
            return;
        }
        if (HasFlyout)
        {
            await ShowFlyout(true);
        }
        else
        {
            // SetFlyoutRef(null);
        }
    }

    private void HandleFlyout(KeyboardEventArgs args)
    {
        if (FlyoutMenu is null)
        {
            return;
        }
    }

    private async Task OnItemChecked(bool _)
    {
        await OnItemSelect(null);
    }

    private async Task OnItemSelect(MouseEventArgs args)
    {
        if (ParentMenu is not null)
        {
            await ParentMenu.ItemSelected(args, ItemId);
        }

        await OnClick.InvokeAsync(args);

        if (Direction.HasValue)
        {
            await Drill();
        }
    }

    private async Task OnActionClick(MouseEventArgs args)
    {
        if (ParentMenu is not null)
        {
            await ParentMenu.ActionClicked(args, ItemId);
        }
    }

    private async Task Drill()
    {
        if (Direction.HasValue)
        {
            if (Direction is MenuItemDirection.Down)
            {
                await ParentMenu.DrillIn(ParentMenu.InternalId, DrilldownMenuId, ItemId);
            }
            else
            {
                await ParentMenu.DrillOut(ParentMenu.ParentMenu ?? ParentMenu.InternalId, ItemId);
            }
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = !string.IsNullOrEmpty(To) ? (HasCheck ? "label" : "a") : Component;
        var randomId  = ComponentIdGenerator.Generate("pf-random");

        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "onmouseover", EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseOver));
        if (FlyoutMenu is not null)
        {
            builder.AddAttribute(4, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>(this, HandleFlyout));
        }
        builder.AddAttribute(5, "role", "none");
        builder.AddElementReferenceCapture(6, __reference => Element = __reference);

        if (Component == "NavLink")
        {
            builder.OpenComponent<NavLink>(7);
        }
        else
        {
            builder.OpenElement(7, component);
        }

        builder.AddAttribute(8, "tabIndex"      , "-1");
        builder.AddAttribute(9, "class"         , ComponentCssClass);
        builder.AddAttribute(10, "aria-current" , AriaCurrent);
        builder.AddAttribute(11, "role"         , "menuitem");
        builder.AddAttribute(12, "onclick"      , EventCallback.Factory.Create<MouseEventArgs>(this, OnItemSelect));

        if (component == "NavLink")
        {
            builder.AddAttribute(13, "href", To);
            builder.AddAttribute(14, "Match", NavLinkMatch.All);
        }
        else if (component == "a")
        {
            builder.AddAttribute(15, "href", To);
            builder.AddAttribute(16, "aria-disabled", IsDisabled ? "true" : null);
        }
        else if (component == "button")
        {
            builder.AddAttribute(17, "type"     , "button");
            builder.AddAttribute(18, "disabled" , IsDisabled ? "true" : null);
        }

        if (IsOnPath.HasValue)
        {
            builder.AddAttribute(19, "aria-expanded", "true");
        }
        else if (HasFlyout)
        {
            builder.AddAttribute(20, "aria-haspopup", "true");
            builder.AddAttribute(21, "aria-expanded", FlyoutVisible ? "true" : null);
        }

        builder.OpenElement(22, "span");
        builder.AddAttribute(23, "class", "pf-c-menu__item-main");
        if (Direction is MenuItemDirection.Up)
        {
            builder.OpenElement(24, "span");
            builder.AddAttribute(25, "class", "pf-c-menu__item-toggle-icon");
            builder.OpenComponent<AngleLeftIcon>(26);
            builder.AddAttribute(27, "aria-hidden", true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (Icon is not null)
        {
            builder.OpenElement(28, "span");
            builder.AddAttribute(29, "class", "pf-c-menu__item-icon");
            builder.AddContent(30, Icon);
            builder.CloseElement();
        }
        if (HasCheck)
        {
            builder.OpenElement(31, "span");

            builder.AddAttribute(32, "class", "pf-c-menu__item-check");

            builder.OpenComponent<Checkbox>(33);
            builder.AddAttribute(33, "id", randomId);
            builder.AddAttribute(34, "Component", "span");
            builder.AddAttribute(35, "Value", IsChecked);
            builder.AddAttribute(36, "ValueChanged", EventCallback.Factory.Create<bool>(this, OnItemChecked));
            builder.AddAttribute(37, "IsDisabled", IsDisabled);
            builder.CloseComponent();

            builder.CloseComponent();
        }
        builder.OpenElement(38, "span");
        builder.AddAttribute(39, "class", "pf-c-menu__item-text");
        builder.AddContent(40, ChildContent);
        builder.CloseElement();
        if (IsExternalLink)
        {
            builder.OpenElement(41, "span");
            builder.AddAttribute(42, "class", "pf-c-menu__item-external-icon");
            builder.OpenComponent<ExternalLinkAltIcon>(43);
            builder.AddAttribute(44, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (FlyoutMenu is not null || Direction is MenuItemDirection.Down)
        {
            builder.OpenElement(45, "span");
            builder.AddAttribute(46, "class", "pf-c-menu__item-toggle-icon");
            builder.OpenComponent<AngleRightIcon>(47);
            builder.AddAttribute(48, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (IsItemSelected)
        {
            builder.OpenElement(49, "span");
            builder.AddAttribute(50, "class", "pf-c-menu__item-select-icon");
            builder.OpenComponent<CheckIcon>(51);
            builder.AddAttribute(52, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        builder.CloseElement();
        if (Description is not null && Direction is not MenuItemDirection.Up)
        {
            builder.OpenElement(53, "span");
            builder.AddAttribute(54, "class", "pf-c-menu__item-description");
            builder.OpenElement(55, "span");
            builder.AddContent(56, Description);
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
        if (FlyoutVisible)
        {
            builder.OpenComponent<CascadingValue<MenuItem>>(57);
            builder.AddAttribute(58, "Value"        , this);
            builder.AddAttribute(59, "IsFixed"      , true);
            builder.AddAttribute(60, "ChildContent" , (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(61, FlyoutMenu);
            });
            builder.CloseComponent();
        }

        builder.OpenComponent<CascadingValue<MenuItem>>(62);
        builder.AddAttribute(63, "Value"        , this);
        builder.AddAttribute(64, "IsFixed"      , true);
        builder.AddAttribute(65, "ChildContent" , (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.AddContent(66, DrilldownMenu);
            innerBuilder.AddContent(67, Actions);
            if (IsFavorited.HasValue)
            {
                innerBuilder.OpenComponent<MenuItemAction>(68);
                innerBuilder.AddAttribute(69, "IsFavorited", IsFavorited);
                innerBuilder.AddAttribute(70, "AriaLabel"  , FavoritedAriaLabel);
                innerBuilder.AddAttribute(71, "OnClick"    , EventCallback.Factory.Create<MouseEventArgs>(this, OnActionClick));
                innerBuilder.AddAttribute(72, "tabindex"   , "-1");
                innerBuilder.AddAttribute(73, "ActionId"   , "fav");
                innerBuilder.CloseComponent();
            }
        });
        builder.CloseComponent();

        builder.CloseElement();
    }
}
