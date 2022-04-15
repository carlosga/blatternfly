namespace Blatternfly.Components;

public class NavItem : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    public ElementReference Element { get; protected set; }

    /// Parent Nav control
    [CascadingParameter] public Nav ParentNav { get; set; }

    /// Parent NavList control
    [CascadingParameter] public NavList ParentNavList { get; set; }

    /// Target navigation link.
    [Parameter] public string To { get; set; }

    /// Group identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
    [Parameter] public string GroupId { get; set; }

    /// Item identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
    [Parameter] public string ItemId { get; set; }

    /// Component used to render NavItems.
    [Parameter] public string Component { get; set; } = "a";

    private string CssClass => new CssBuilder("pf-c-nav__item")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string NavLinkCssClass => new CssBuilder("pf-c-nav__link")
        .AddClass("pf-m-current", Component != "NavLink" && IsActive)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool IsActive
    {
        get => !string.IsNullOrEmpty(ParentNav.ActiveItemId) && ItemId == ParentNav.ActiveItemId;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var ariaCurrent = IsActive ? "page" : null;

        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnClick));

        if (Component == "NavLink")
        {
            builder.OpenComponent<NavLink>(4);
            builder.AddAttribute(5, "class", NavLinkCssClass);
            builder.AddAttribute(6, "ActiveClass", "pf-m-current");
            builder.AddAttribute(7, "href", To);
            builder.AddAttribute(8, "aria-current", ariaCurrent);
            builder.AddAttribute(9, "Match", NavLinkMatch.All);
            builder.AddAttribute(10, "ChildContent", ChildContent);
            builder.CloseComponent();
        }
        else
        {
            builder.OpenElement(11, Component);
            builder.AddAttribute(12, "class", NavLinkCssClass);
            builder.AddAttribute(13, "href", To);
            builder.AddAttribute(14, "aria-current", ariaCurrent);
            builder.AddContent(15, ChildContent);
            builder.CloseElement();
        }

        builder.AddElementReferenceCapture(16, __inputReference => Element = __inputReference);
        builder.CloseElement();
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
