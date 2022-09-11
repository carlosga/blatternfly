namespace Blatternfly.Components;

public partial class DrawerPanelBody : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates if there should be no padding around the drawer panel body.</summary>
    [Parameter] public bool HasNoPadding { get; set; }

    private string CssClass => new CssBuilder("pf-c-drawer__body")
        .AddClass("pf-m-no-padding", HasNoPadding)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}