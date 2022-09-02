namespace Blatternfly.Components;

public partial class Drawer : ComponentBase
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
    /// Indicate if the drawer is expanded.
    /// </summary>
    [Parameter]
    public bool IsExpanded { get; set; }

    /// <summary>
    /// Indicates if the content element and panel element are displayed side by side.
    /// </summary>
    [Parameter]
    public bool IsInline { get; set; }

    /// <summary>
    /// Indicates if the drawer will always show both content and panel.
    /// </summary>
    [Parameter]
    public bool IsStatic { get; set; }

    /// <summary>
    /// Position of the drawer panel.
    /// </summary>
    [Parameter]
    public DrawerPosition Position { get; set; } = DrawerPosition.Right;

    /// <summary>
    /// Callback when drawer panel is expanded.
    /// </summary>
    [Parameter]
    public EventCallback OnExpand { get; set; }

    private string CssClass => new CssBuilder("pf-c-drawer")
        .AddClass("pf-m-expanded"     , IsExpanded)
        .AddClass("pf-m-inline"       , IsInline)
        .AddClass("pf-m-static"       , IsStatic)
        .AddClass("pf-m-panel-left"   , Position is DrawerPosition.Left)
        .AddClass("pf-m-panel-bottom" , Position is DrawerPosition.Bottom)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}