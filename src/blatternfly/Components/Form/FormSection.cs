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

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__section")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var sectionId = !string.IsNullOrEmpty(Title) ? ComponentIdGenerator.Generate("pf-form-section-title") : null;

        builder.OpenElement(0, "section");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "role", "group");
        builder.AddAttribute(4, "aria-labelledby", sectionId);

        if (!string.IsNullOrEmpty(Title))
        {
            builder.OpenElement(5, TitleElement.ToString());
            builder.AddAttribute(6, "id", sectionId);
            builder.AddAttribute(7, "class", "pf-c-form__section-title");
            builder.AddContent(8, Title);
            builder.CloseElement();
        }

        builder.AddContent(9, ChildContent);

        builder.CloseElement();
    }
}
