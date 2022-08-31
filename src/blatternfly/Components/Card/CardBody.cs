namespace Blatternfly.Components;

public class CardBody : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Sets the base component to render. defaults to div.
    /// </summary>
    [Parameter]
    public string Component { get; set; } = "div";

    /// <summary>
    /// Enables the body Content to fill the height of the card.
    /// </summary>
    [Parameter]
    public bool IsFilled { get; set; } = true;

    private string CssClass => new CssBuilder("pf-c-card__body")
        .AddClass("pf-m-no-fill", !IsFilled)
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
