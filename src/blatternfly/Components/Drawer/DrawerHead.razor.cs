namespace Blatternfly.Components;

public partial class DrawerHead : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Indicates if there should be no padding around the drawer panel body of the head.
    /// </summary>
    [Parameter] public bool HasNoPadding { get; set; }

    private string CssClass => new CssBuilder("pf-c-drawer__head")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}