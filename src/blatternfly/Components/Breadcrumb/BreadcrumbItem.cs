namespace Blatternfly.Components;

public class BreadcrumbItem : ComponentBase
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
    /// Flag indicating whether the item is active.
    /// </summary>
    [Parameter] 
    public bool IsActive { get; set; }

    /// <summary>
    /// Target for breadcrumb link.
    /// </summary>
    [Parameter] 
    public string Target { get; set; }

    /// <summary>
    /// Flag indicating whether the item contains a dropdown.
    /// </summary>
    [Parameter] 
    public bool IsDropdown { get; set; }

    /// <summary>
    /// Sets the base component to render. Defaults to null, rendering it as <NavLink />.
    /// </summary>
    [Parameter] 
    public string Component { get; set; }

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
        var ariaCurrent = IsActive ? "page" : null;

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
        if (Component == "button")
        {
            builder.OpenElement(6, "button");
            builder.AddAttribute(7, "class", LinkCssClass);
            builder.AddAttribute(8, "aria-current", ariaCurrent);
            builder.AddAttribute(9, "type", "button");
            builder.AddContent(10, ChildContent);
            builder.CloseElement();
        }
        else if (IsDropdown)
        {
            builder.OpenElement(11, "span");
            builder.AddAttribute(12, "class", "pf-c-breadcrumb__dropdown");
            builder.AddContent(13, ChildContent);
            builder.CloseElement();
        }
        else if (!string.IsNullOrEmpty(To))
        {
            if (string.IsNullOrEmpty(Component))
            {
                builder.OpenComponent<NavLink>(14);
            }
            else
            {
                builder.OpenElement(15, Component);

            }
            builder.AddAttribute(16, "href", To);
            builder.AddAttribute(17, "target", Target);
            builder.AddAttribute(18, "class", LinkCssClass);
            builder.AddAttribute(19, "ActiveClass", "pf-m-current");
            builder.AddAttribute(20, "aria-current", ariaCurrent);
            if (string.IsNullOrEmpty(Component))
            {
                builder.AddAttribute(21, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
                {
                    innerBuilder.AddContent(22, ChildContent);
                });
            }
            else
            {
                builder.AddContent(23, ChildContent);
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
            builder.AddContent(24, ChildContent);
        }

        builder.CloseElement();
    }
}
