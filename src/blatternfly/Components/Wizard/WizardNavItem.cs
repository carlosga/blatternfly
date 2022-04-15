namespace Blatternfly.Components;

public class WizardNavItem : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// The content to display in the nav item.
    [Parameter] public RenderFragment Content { get; set; }

    /// Whether the nav item is the currently active item.
    [Parameter] public bool IsCurrent { get; set; }

    /// Whether the nav item is disabled.
    [Parameter] public bool IsDisabled { get; set; }

    /// The step passed into the onNavItemClick callback.
    [Parameter] public int Step { get; set; }

    /// Callback for when the nav item is clicked.
    [Parameter] public EventCallback<int> OnNavItemClick { get; set; }

    /// Component used to render WizardNavItem.
    [Parameter] public WizardNavItemComponent NavItemComponent { get; set; } = WizardNavItemComponent.Button;

    /// An optional url to use for when using an anchor component.
    [Parameter] public string Href { get; set; }

    /// Flag indicating that this NavItem has child steps and is expandable.
    [Parameter] public bool IsExpandable { get; set; }

    private bool IsExpanded { get; set; }

    private string CssClass => new CssBuilder("pf-c-wizard__nav-item")
        .AddClass("pf-m-expandable", IsExpandable)
        .AddClass("pf-m-expanded"  , IsExpandable && IsExpanded)
        .Build();

    private string NavLinkCssClass => new CssBuilder("pf-c-wizard__nav-link")
        .AddClass("pf-m-current"  , IsCurrent)
        .AddClass("pf-m-disabled" , IsDisabled)
        .Build();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        IsExpanded = IsCurrent;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (NavItemComponent == WizardNavItemComponent.Link && string.IsNullOrEmpty(Href))
        {
            throw new Exception("WizardNavItem: When using an anchor, please provide an href.");
        }

        var component = NavItemComponent is WizardNavItemComponent.Button ? "button" : "a";
        int? tabIndex = IsDisabled ? -1 : null;

        builder.OpenElement(0, "li");
        builder.AddAttribute(1, "class", CssClass);

        builder.OpenElement(2, component);
        builder.AddMultipleAttributes(3, AdditionalAttributes);
        builder.AddAttribute(4, "class", NavLinkCssClass);
        builder.AddAttribute(5, "aria-disabled", IsDisabled ? "true" : null);
        builder.AddAttribute(6, "aria-current", IsCurrent && ChildContent is null ? "step" : "false");
        builder.AddAttribute(7, "aria-expanded", IsExpandable && IsExpanded ? "true" : null);

        if (NavItemComponent is WizardNavItemComponent.Button)
        {
            builder.AddAttribute(8, "disabled", IsDisabled ? "true" : null);
        }
        else
        {
            builder.AddAttribute(9, "tabindex", tabIndex);
            builder.AddAttribute(10, "href", "Href");
        }

        if (IsExpandable)
        {
            builder.AddAttribute(11, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, SetIsExpanded));
        }
        else
        {
            builder.AddAttribute(12, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnNavItemClickHandler));
        }

        if (IsExpandable)
        {
            builder.OpenElement(13, "span");
            builder.AddAttribute(14, "class", "pf-c-wizard__nav-link-text");
            builder.AddContent(15, Content);
            builder.CloseElement();
            builder.OpenElement(16, "span");
            builder.AddAttribute(17, "class", "pf-c-wizard__nav-link-toggle");
            builder.OpenElement(18, "span");
            builder.AddAttribute(19, "class", "pf-c-wizard__nav-link-toggle-icon");
            builder.OpenComponent<AngleRightIcon>(20);
            builder.CloseComponent();
            builder.CloseElement();
            builder.CloseElement();
        }
        else
        {
            builder.AddContent(21, Content);
        }

        builder.CloseElement();

        builder.AddContent(22, ChildContent);

        builder.CloseElement();
    }

    private void SetIsExpanded(MouseEventArgs _)
    {
        IsExpanded = !IsExpanded || IsCurrent;
    }

    private async Task OnNavItemClickHandler(MouseEventArgs _)
    {
        if (IsExpandable)
        {
            IsExpanded = !IsExpanded || IsCurrent;
        }
        else
        {
            await OnNavItemClick.InvokeAsync(Step);
        }
    }
}
