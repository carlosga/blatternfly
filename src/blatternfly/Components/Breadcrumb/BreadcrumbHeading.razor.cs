namespace Blatternfly.Components;

public partial class BreadcrumbHeading : ComponentBase
{
    [CascadingParameter] private Breadcrumb Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>HREF for breadcrumb link.</summary>
    [Parameter] public string To { get; set; }

    /// <summary>Target for breadcrumb link.</summary>
    [Parameter] public string Target { get; set; }

    /// <summary>Sets the base component to render. Defaults to 'a'.</summary>
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
}
