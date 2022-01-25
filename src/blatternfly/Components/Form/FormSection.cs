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
        var index = 0;

        builder.OpenElement(index++, "section");
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass);

        if (!string.IsNullOrEmpty(Title))
        {
            builder.OpenElement(index++, TitleElement.ToString());
            builder.AddAttribute(index++, "class", "pf-c-form__section-title");
            builder.AddContent(index++, Title);
            builder.CloseElement();
        }

        builder.AddContent(index++, ChildContent);

        builder.CloseElement();
    }
}
