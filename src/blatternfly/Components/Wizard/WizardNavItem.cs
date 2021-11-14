using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public class WizardNavItem : BaseComponent
{
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

    private CssBuilder NavCssClass => new CssBuilder("pf-c-wizard__nav-item")
        .AddClass("pf-m-expandable", IsExpandable)
        .AddClass("pf-m-expanded"  , IsExpandable && IsExpanded);

    private CssBuilder NavLinkCssClass => new CssBuilder("pf-c-wizard__nav-link")
        .AddClass("pf-m-current"  , IsCurrent)
        .AddClass("pf-m-disabled" , IsDisabled);

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (NavItemComponent == WizardNavItemComponent.Link && string.IsNullOrEmpty(Href))
        {
            throw new Exception("WizardNavItem: When using an anchor, please provide an href.");
        }
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        IsExpanded = IsCurrent;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index     = 0;
        var component = NavItemComponent == WizardNavItemComponent.Button ? "button" : "a";
        int? tabIndex = IsDisabled ? -1 : null;

        builder.OpenElement(index++, "li");
        builder.AddAttribute(index++, "class", NavCssClass);

        builder.OpenElement(index++, component);
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", NavLinkCssClass);
        builder.AddAttribute(index++, "aria-disabled", IsDisabled ? "true" : null);
        builder.AddAttribute(index++, "aria-current", IsCurrent && ChildContent is null ? "step" : "false");
        builder.AddAttribute(index++, "aria-expanded", IsExpandable && IsExpanded ? "true" : null);

        if (NavItemComponent == WizardNavItemComponent.Button)
        {
            builder.AddAttribute(index++, "disabled", IsDisabled ? "true" : null);
        }
        else
        {
            builder.AddAttribute(index++, "tabindex", tabIndex);
            builder.AddAttribute(index++, "href", "Href");
        }

        if (IsExpandable)
        {
            builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, SetIsExpanded));
        }
        else
        {
            builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnNavItemClickHandler));
        }

        if (IsExpandable)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-wizard__nav-link-text");
            builder.AddContent(index++, Content);
            builder.CloseElement();
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-wizard__nav-link-toggle");
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-wizard__nav-link-toggle-icon");
            builder.OpenComponent<AngleRightIcon>(index++);
            builder.CloseComponent();
            builder.CloseElement();
            builder.CloseElement();
        }
        else
        {
            builder.AddContent(index++, Content);
        }

        builder.CloseElement();

        builder.AddContent(index++, ChildContent);

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
