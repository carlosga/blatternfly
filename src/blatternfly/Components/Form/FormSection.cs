namespace Blatternfly.Components;

public class FormSection : BaseComponent
{
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
