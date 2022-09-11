namespace Blatternfly.Components;

public partial class SidebarPanel : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates whether the panel is positioned statically or sticky to the top. Default is sticky on small screens when the orientation is stack, and static on medium and above screens when the orientation is split.</summary>
    [Parameter] public SidebarVariant Variant { get; set; } = SidebarVariant.Default;

    /// <summary>Removes the background color.</summary>
    [Parameter] public bool HasNoBackground { get; set; }

    /// <summary>Sets the panel width at various breakpoints. Default is 250px when the orientation is split.</summary>
    [Parameter] public SidebarWidthModifiers Width { get; set; }

    private string CssClass => new CssBuilder("pf-c-sidebar__panel")
        .AddClass("pf-m-sticky"       , Variant is SidebarVariant.Sticky)
        .AddClass("pf-m-static"       , Variant is SidebarVariant.Static)
        .AddClass("pf-m-no-background", HasNoBackground)
        .AddClass(Width?.CssClass())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}