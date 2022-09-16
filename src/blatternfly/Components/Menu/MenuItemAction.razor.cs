namespace Blatternfly.Components;

public partial class MenuItemAction : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [CascadingParameter] private Menu     ParentMenu     { get; set; }
    [CascadingParameter] private MenuItem ParentMenuItem { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The action icon to use.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>Callback on action click, can also specify onActionClick on the Menu instead.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>Accessibility label.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Flag indicating if the item is favorited.</summary>
    [Parameter] public bool? IsFavorited { get; set; }

    /// <summary>Disables action, can also be specified on the MenuItem instead.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Identifies the action item in the onActionClick on the Menu.</summary>
    [Parameter] public string ActionId { get; set; }

    private string CssClass => new CssBuilder("pf-c-menu__item-action")
        .AddClass("pf-m-favorite" , IsFavorited.HasValue)
        .AddClass("pf-m-favorited", IsFavorited.GetValueOrDefault())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool IsDisabledContext { get => ParentMenuItem?.IsDisabled ?? false; }

    private string DisabledValue { get => IsDisabled || IsDisabledContext ? "true" : null; }

    private Menu RootMenu { get; set; }

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

    private async Task OnClickButton(MouseEventArgs args)
    {
        // event specified on the MenuItemAction
        await OnClick.InvokeAsync(args);

        // event specified on the Menu
        if (RootMenu is not null)
        {
            await RootMenu.ActionClicked(args, ParentMenuItem.ItemId, ActionId);
        }
    }
}