namespace Blatternfly.Components;

public class BreadcrumbHeading : BaseComponent
{
    [CascadingParameter] public Breadcrumb Parent { get; set; }

    /// HREF for breadcrumb link.
    [Parameter] public string To { get; set; }

    /// Target for breadcrumb link.
    [Parameter] public string Target { get; set; }

    [Parameter] public string Component { get; set; } = "a";

    /// Internal prop set by Breadcrumb on all but the first crumb.
    internal bool ShowDivider { get; set; }

    private string CssClass => new CssBuilder("pf-c-breadcrumb__item")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent?.AddHeading(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index = 0;

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

        builder.OpenElement(index++, "h1");
        builder.AddAttribute(index++, "class", "pf-c-breadcrumb__heading");

        if (string.IsNullOrEmpty(To) && Component == "button")
        {
            builder.OpenElement(index++, "button");
            builder.AddAttribute(index++, "class", "pf-c-breadcrumb__link pf-m-current");
            builder.AddAttribute(index++, "aria-current");
            builder.AddAttribute(index++, "type", "button");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
        if (!string.IsNullOrEmpty(To))
        {
            if (Component == "NavLink")
            {
                builder.OpenComponent<NavLink>(index++);
                builder.AddAttribute(index++, "ActiveClass", "pf-m-current");
            }
            else
            {
                builder.OpenElement(index++, Component);

            }
            builder.AddAttribute(index++, "href", To);
            builder.AddAttribute(index++, "target", Target);
            builder.AddAttribute(index++, "class", "pf-c-breadcrumb__link pf-m-current");
            builder.AddAttribute(index++, "aria-current", "page");
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
        if (string.IsNullOrEmpty(To) && Component != "button")
        {
            builder.AddContent(index++, ChildContent);
        }

        builder.CloseElement();
        builder.CloseElement();
    }
}
