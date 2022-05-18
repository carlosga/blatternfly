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

    private async Task HandleItemClick(MouseEventArgs args)
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
        var component = !string.IsNullOrEmpty(To) ? "a" : Component;

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
        builder.AddAttribute(12, "onclick"      , EventCallback.Factory.Create<MouseEventArgs>(this, HandleItemClick));

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
        builder.OpenElement(31, "span");
        builder.AddAttribute(32, "class", "pf-c-menu__item-text");
        builder.AddContent(33, ChildContent);
        builder.CloseElement();
        if (IsExternalLink)
        {
            builder.OpenElement(34, "span");
            builder.AddAttribute(35, "class", "pf-c-menu__item-external-icon");
            builder.OpenComponent<ExternalLinkAltIcon>(36);
            builder.AddAttribute(37, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (FlyoutMenu is not null || Direction is MenuItemDirection.Down)
        {
            builder.OpenElement(38, "span");
            builder.AddAttribute(39, "class", "pf-c-menu__item-toggle-icon");
            builder.OpenComponent<AngleRightIcon>(40);
            builder.AddAttribute(41, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (IsItemSelected)
        {
            builder.OpenElement(42, "span");
            builder.AddAttribute(43, "class", "pf-c-menu__item-select-icon");
            builder.OpenComponent<CheckIcon>(44);
            builder.AddAttribute(45, "aria-hidden", value: true);
            builder.CloseComponent();
            builder.CloseElement();
        }
        builder.CloseElement();
        if (Description is not null && Direction is not MenuItemDirection.Up)
        {
            builder.OpenElement(46, "span");
            builder.AddAttribute(47, "class", "pf-c-menu__item-description");
            builder.OpenElement(48, "span");
            builder.AddContent(49, Description);
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
            builder.OpenComponent<CascadingValue<MenuItem>>(50);
            builder.AddAttribute(51, "Value"        , this);
            builder.AddAttribute(52, "IsFixed"      , true);
            builder.AddAttribute(53, "ChildContent" , (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(54, FlyoutMenu);
            });
            builder.CloseComponent();
        }

        builder.OpenComponent<CascadingValue<MenuItem>>(55);
        builder.AddAttribute(56, "Value"        , this);
        builder.AddAttribute(57, "IsFixed"      , true);
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
