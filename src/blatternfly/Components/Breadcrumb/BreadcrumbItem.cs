namespace Blatternfly.Components;

public class BreadcrumbItem : BaseComponent
{
    [CascadingParameter] public Breadcrumb Parent { get; set; }

    /// HREF for breadcrumb link.
    [Parameter] public string To { get; set; }

    /// Flag indicating whether the item is active.
    [Parameter] public bool IsActive { get; set; }

    /// Target for breadcrumb link.
    [Parameter] public string Target { get; set; }

    /// Flag indicating whether the item contains a dropdown.
    [Parameter] public bool IsDropdown { get; set; }

    /// Sets the base component to render. Defaults to null, rendering it as <NavLink />.
    [Parameter] public string Component { get; set; }

    /// Internal prop set by Breadcrumb on all but the first crumb.
    internal bool ShowDivider { get; set; }

    private string CssClass => new CssBuilder("pf-c-breadcrumb__item")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string LinkCssClass => new CssBuilder("pf-c-breadcrumb__link")
        .AddClass("pf-m-current", IsActive)
        .Build();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent?.AddItem(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index       = 0;
        var ariaCurrent = IsActive ? "page" : null;

        builder.OpenElement(index++, "li");
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass);

        if (ShowDivider)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-breadcrumb__item-divider");
            builder.OpenComponent<AngleRightIcon>(index++);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (Component == "button")
        {
            builder.OpenElement(index++, "button");
            builder.AddAttribute(index++, "class", LinkCssClass);
            builder.AddAttribute(index++, "aria-current", ariaCurrent);
            builder.AddAttribute(index++, "type", "button");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
        else if (IsDropdown)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-breadcrumb__dropdown");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
        else if (!string.IsNullOrEmpty(To))
        {
            if (string.IsNullOrEmpty(Component))
            {
                builder.OpenComponent<NavLink>(index++);
            }
            else
            {
                builder.OpenElement(index++, Component);

            }
            builder.AddAttribute(index++, "href", To);
            builder.AddAttribute(index++, "target", Target);
            builder.AddAttribute(index++, "class", LinkCssClass);
            builder.AddAttribute(index++, "ActiveClass", "pf-m-current");
            builder.AddAttribute(index++, "aria-current", ariaCurrent);
            if (string.IsNullOrEmpty(Component))
            {
                builder.AddAttribute(index++, "ChildContent", ChildContent);
            }
            else
            {
                builder.AddContent(index++, ChildContent);
            }
            if (string.IsNullOrEmpty(Component))
            {
                builder.CloseComponent();
            }
            else
            {
                builder.CloseElement();
            }
        }
        if (string.IsNullOrEmpty(To) && Component != "button" && !IsDropdown)
        {
            builder.AddContent(index++, ChildContent);
        }

        builder.CloseElement();
    }
}
