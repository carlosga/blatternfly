namespace Blatternfly.Components;

public class TextList : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// The text list component.
    [Parameter] public TextListVariants Component { get; set; } = TextListVariants.ul;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "data-pf-content", "true");
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
