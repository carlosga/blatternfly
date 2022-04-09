namespace Blatternfly.Components;

public class FormHelperText : BaseComponent
{
    /// Adds error styling to the Helper Text.
    [Parameter] public bool IsError { get; set; }

    /// Hides the helper text
    [Parameter] public bool IsHidden { get; set; } = true;

    /// Icon displayed to the left of the helper text.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Component type of the form helper text.
    [Parameter] public FormHelperTextVariant Component { get; set; } = FormHelperTextVariant.p;

    private string CssClass => new CssBuilder("pf-c-form__helper-text")
        .AddClass("pf-m-hidden", IsHidden)
        .AddClass("pf-m-error" , IsError)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = Component switch
        {
            FormHelperTextVariant.p   => "p",
            FormHelperTextVariant.div => "div",
            _                         => null
        };

        builder.OpenElement(0, component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);

        if (Icon is not null)
        {
            builder.OpenElement(3, "span");
            builder.AddAttribute(4, "class", "pf-c-form__helper-text-icon");
            builder.AddContent(5, Icon);
            builder.CloseElement();
        }

        builder.AddContent(6, ChildContent);

        builder.CloseElement();
    }
}
