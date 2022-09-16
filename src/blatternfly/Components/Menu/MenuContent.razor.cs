using System.Globalization;

namespace Blatternfly.Components;

public partial class MenuContent : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [Inject] private IDomUtils DomUtils { get; set; }

    [CascadingParameter] private Menu ParentMenu { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Height of the menu content.</summary>
    [Parameter] public string MenuHeight { get; set; }

    /// <summary>Maximum height of menu content</summary>
    [Parameter] public string MaxMenuHeight { get; set; }

    /// <summary>Callback to return the height of the menu content.</summary>
    [Parameter] public EventCallback<string> GetHeight { get; set; }

    private string CssClass => new CssBuilder("pf-c-menu__content")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-menu__content--Height"   , MenuHeight   , !string.IsNullOrEmpty(MenuHeight))
        .AddStyle("--pf-c-menu__content--MaxHeight", MaxMenuHeight, !string.IsNullOrEmpty(MaxMenuHeight))
        .Build();

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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var clientHeight = await DomUtils.CalculateMenuContentHeightAsync(Element);

            if (clientHeight > 0)
            {
                await RootMenu.GetMenuHeight(ParentMenu.InternalId, clientHeight);
                await GetHeight.InvokeAsync(clientHeight.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}