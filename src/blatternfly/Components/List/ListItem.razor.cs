namespace Blatternfly.Components;

public partial class ListItem : ComponentBase
{
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
    /// Icon for the list item.
    /// </summary>
    [Parameter]
    public RenderFragment Icon { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-list__item", Icon is not null)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}