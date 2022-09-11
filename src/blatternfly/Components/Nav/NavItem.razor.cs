namespace Blatternfly.Components;

public partial class NavItem : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [CascadingParameter] private Nav ParentNav { get; set; }
    [CascadingParameter] private NavList ParentNavList { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Target navigation link.
    /// </summary>
    [Parameter] public string To { get; set; }

    /// <summary>
    /// Group identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
    /// </summary>
    [Parameter] public string GroupId { get; set; }

    /// <summary>
    /// Item identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
    /// </summary>
    [Parameter] public string ItemId { get; set; }

    /// <summary>
    /// Component used to render NavItems.
    /// </summary>
    [Parameter] public string Component { get; set; } = "a";

    private string CssClass => new CssBuilder("pf-c-nav__item")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string NavLinkCssClass => new CssBuilder("pf-c-nav__link")
        .AddClass("pf-m-current", Component != "NavLink" && IsActive)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaCurrent { get => IsActive ? "page" : null; }
    // TODO: IsNavOpen
    private string TabIndex    { get => null; }
    private bool IsActive
    {
        get => !string.IsNullOrEmpty(ParentNav.ActiveItemId) && ItemId == ParentNav.ActiveItemId;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ParentNavList?.RegisterItem(this);
    }

    private async Task OnClick(MouseEventArgs args)
    {
        await ParentNav.Select(this);
    }
}
