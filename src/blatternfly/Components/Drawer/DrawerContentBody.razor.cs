namespace Blatternfly.Components;

public partial class DrawerContentBody : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates if there should be padding around the drawer content body.</summary>
    [Parameter] public bool HasPadding { get; set; }

    private string CssClass => new CssBuilder("pf-c-drawer__body")
        .AddClass("pf-m-padding", HasPadding)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}