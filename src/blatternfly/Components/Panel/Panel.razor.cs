namespace Blatternfly.Components;

public partial class Panel : ComponentBase
{
    public ElementReference Element { get; protected set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds panel variant styles.</summary>
    [Parameter] public PanelVariant? Variant { get; set; }

    /// <summary>Flag to add scrollable styling to the panel.</summary>
    [Parameter] public bool IsScrollable { get; set; }

    private string CssClass => new CssBuilder("pf-c-panel")
        .AddClass("pf-m-raised"    , Variant is PanelVariant.Raised)
        .AddClass("pf-m-bordered"  , Variant is PanelVariant.Bordered)
        .AddClass("pf-m-scrollable", IsScrollable)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}