namespace Blatternfly.Components;

public partial class DrawerContent : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Content rendered in the drawer panel.</summary>
    [Parameter] public RenderFragment PanelContent { get; set; }

    /// <summary>Color variant of the background of the drawer panel.</summary>
    [Parameter] public DrawerColorVariant ColorVariant { get; set; } = DrawerColorVariant.Default;

    private string CssClass => new CssBuilder("pf-c-drawer__content")
        .AddClass("pf-m-light-200", ColorVariant is DrawerColorVariant.Light200)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}