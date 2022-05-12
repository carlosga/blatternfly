namespace Blatternfly.Components;

public class CardTitle : ComponentBase
{
    [CascadingParameter] public Card Parent { get; set; }

    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-c-card__title")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TitleId { get => Parent?.CardId is not null ? $"{Parent?.CardId}-title" : null; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent?.RegisterTitleId(TitleId);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "id", TitleId);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
