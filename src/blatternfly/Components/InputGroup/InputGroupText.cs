namespace Blatternfly.Components;

public class InputGroupText : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Component that wraps the input group text.
    [Parameter] public string Component { get; set; } = "span";

    /// Input group text variant.
    [Parameter] public InputGroupTextVariant Variant { get; set; } = InputGroupTextVariant.Default;

    private string CssClass => new CssBuilder("pf-c-input-group__text")
        .AddClass("pf-m-plain", Variant is InputGroupTextVariant.Plain)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
