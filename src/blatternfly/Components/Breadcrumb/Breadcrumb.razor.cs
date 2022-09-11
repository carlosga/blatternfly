namespace Blatternfly.Components;

public partial class Breadcrumb : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Aria label added to the breadcrumb nav.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Breadcrumb";

    private string CssClass => new CssBuilder("pf-c-breadcrumb")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private int _itemCount = 0;

    internal void AddItem(BreadcrumbItem item)
    {
        if (_itemCount++ > 0)
        {
            item.ShowDivider = true;
        }
    }

    internal void AddHeading(BreadcrumbHeading heading)
    {
        if (_itemCount++ > 0)
        {
            heading.ShowDivider = true;
        }
    }
}