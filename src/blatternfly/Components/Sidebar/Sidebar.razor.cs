namespace Blatternfly.Components;

public partial class Sidebar : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates the direction of the layout. Default orientation is stack on small screens, and split on medium screens and above.</summary>
    [Parameter] public SidebarOrientation? Orientation { get; set; }

    /// <summary>Indicates that the panel is displayed to the right of the content when the orientation is split.</summary>
    [Parameter] public bool IsPanelRight { get; set; }

    /// <summary>Adds space between the panel and content.</summary>
    [Parameter] public bool HasGutter { get; set; }

    /// <summary>Removes the background color.</summary>
    [Parameter] public bool HasNoBackground { get; set; }

    private string CssClass => new CssBuilder("pf-c-sidebar")
        .AddClass("pf-m-gutter"       , HasGutter)
        .AddClass("pf-m-no-background", HasNoBackground)
        .AddClass("pf-m-panel-right"  , IsPanelRight)
        .AddClass("pf-m-stack"        , Orientation is SidebarOrientation.Stack)
        .AddClass("pf-m-split"        , Orientation is SidebarOrientation.Split)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}