namespace Blatternfly.Components;

public partial class PanelMain : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Max height of the panel main div as a string with the value and unit.</summary>
    [Parameter] public string MaxHeight { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-panel__main--MaxHeight", MaxHeight, !string.IsNullOrEmpty(MaxHeight))
        .Build();

    private string CssClass => new CssBuilder("pf-c-panel__main")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}