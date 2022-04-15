namespace Blatternfly.Components;

public class FormSection : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Title for the section.
    [Parameter] public string Title { get; set; }

    /// Element to wrap the section title.
    [Parameter] public TitleElement TitleElement { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__section")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "section");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);

        if (!string.IsNullOrEmpty(Title))
        {
            builder.OpenElement(3, TitleElement.ToString());
            builder.AddAttribute(4, "class", "pf-c-form__section-title");
            builder.AddContent(5, Title);
            builder.CloseElement();
        }

        builder.AddContent(6, ChildContent);

        builder.CloseElement();
    }
}
