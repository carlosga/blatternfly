namespace Blatternfly.Components;

public partial class DrawerPanelContent : ComponentBase
{
    [CascadingParameter] private Drawer Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating that the drawer panel should have a border.</summary>
    [Parameter] public bool HasNoBorder { get; set; }

    /// <summary>Color variant of the background of the drawer panel.</summary>
    [Parameter] public DrawerColorVariant ColorVariant { get; set; } = DrawerColorVariant.Default;

    /// <summary>Width for drawer panel at various breakpoints. Overriden by resizable drawer minSize and defaultSize.</summary>
    [Parameter] public DrawerWidthModifiers Widths { get; set; }

    private string CssClass => new CssBuilder("pf-c-drawer__panel")
        .AddClass(Widths?.WidthClass)
        .AddClass("pf-m-light-200", ColorVariant is DrawerColorVariant.Light200)
        .AddClass("pf-m-no-border", HasNoBorder)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool IsHidden { get => !Parent.IsStatic && !Parent.IsExpanded; }
}