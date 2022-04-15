namespace Blatternfly.Layouts;

public class SplitItem : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public virtual RenderFragment ChildContent { get; set; }

    /// Flag indicating if this Split Layout item should fill the available horizontal space.
    [Parameter] public bool IsFilled { get; set; }

    private string CssClass => new CssBuilder("pf-l-split__item")
        .AddClass("pf-m-fill", IsFilled)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
