namespace Blatternfly.Layouts;

public class Split : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public virtual RenderFragment ChildContent { get; set; }

    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    /// Allows children to wrap.
    [Parameter] public bool IsWrappable { get; set; }

    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-l-split")
        .AddClass("pf-m-gutter", HasGutter)
        .AddClass("pf-m-wrap"  , IsWrappable)
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
