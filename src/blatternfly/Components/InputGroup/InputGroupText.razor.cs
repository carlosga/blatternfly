namespace Blatternfly.Components;

public partial class InputGroupText : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Component that wraps the input group text.</summary>
    [Parameter] public string Component { get; set; } = "span";

    /// <summary>Input group text variant.</summary>
    [Parameter] public InputGroupTextVariant Variant { get; set; } = InputGroupTextVariant.Default;

    private string CssClass => new CssBuilder("pf-c-input-group__text")
        .AddClass("pf-m-plain", Variant is InputGroupTextVariant.Plain)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
