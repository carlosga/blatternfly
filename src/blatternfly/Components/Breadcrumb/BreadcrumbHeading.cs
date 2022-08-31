namespace Blatternfly.Components;

public class BreadcrumbHeading : ComponentBase
{
    /// <summary>
    /// Parent Breadcrumb component.
    /// </summary>
    [CascadingParameter] 
    private Breadcrumb Parent { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] 
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] 
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// HREF for breadcrumb link.
    /// </summary>
    [Parameter] 
    public string To { get; set; }

    /// <summary>
    /// Target for breadcrumb link.
    /// </summary>
    [Parameter] 
    public string Target { get; set; }

    /// <summary>
    /// Sets the base component to render. Defaults to <a>.
    /// </summary>
    [Parameter] 
    public string Component { get; set; } = "a";

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
        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);

        if (ShowDivider)
        {
            builder.OpenElement(3, "span");
            builder.AddAttribute(4, "class", "pf-c-breadcrumb__item-divider");
            builder.OpenComponent<AngleRightIcon>(5);
            builder.CloseComponent();
            builder.CloseElement();
        }

        builder.OpenElement(6, "h1");
        builder.AddAttribute(7, "class", "pf-c-breadcrumb__heading");

        if (string.IsNullOrEmpty(To) && Component == "button")
        {
            builder.OpenElement(8, "button");
            builder.AddAttribute(9, "class", "pf-c-breadcrumb__link pf-m-current");
            builder.AddAttribute(10, "aria-current");
            builder.AddAttribute(11, "type", "button");
            builder.AddContent(12, ChildContent);
            builder.CloseElement();
        }
        if (!string.IsNullOrEmpty(To))
        {
            if (Component == "NavLink")
            {
                builder.OpenComponent<NavLink>(13);
                builder.AddAttribute(14, "ActiveClass", "pf-m-current");
            }
            else
            {
                builder.OpenElement(15, Component);

            }
            builder.AddAttribute(16, "href", To);
            builder.AddAttribute(17, "target", Target);
            builder.AddAttribute(18, "class", "pf-c-breadcrumb__link pf-m-current");
            builder.AddAttribute(19, "aria-current", "page");
            if (string.IsNullOrEmpty(Component))
            {
                builder.AddAttribute(20, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
                {
                    innerBuilder.AddContent(21, ChildContent);
                });
            }
            else
            {
                builder.AddContent(22, ChildContent);
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
            builder.AddContent(23, ChildContent);
        }

        builder.CloseElement();
        builder.CloseElement();
    }
}
