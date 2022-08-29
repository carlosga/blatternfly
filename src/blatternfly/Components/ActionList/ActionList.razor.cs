namespace Blatternfly.Components;

public partial class ActionList
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
    /// Flag indicating the action list contains multiple icons and item padding should be removed.
    /// </summary>
    [Parameter]
    public bool IsIconList { get; set; }

    private string CssClass => new CssBuilder("pf-c-action-list")
        .AddClass("pf-m-icons", IsIconList)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
