namespace Blatternfly.Components;

public class CardBody : BaseComponent
{
    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    /// Enables the body Content to fill the height of the card.
    [Parameter] public bool IsFilled { get; set; } = true;

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
