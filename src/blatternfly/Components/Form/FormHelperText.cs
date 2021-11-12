using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

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
    
    private CssBuilder CssClass => new CssBuilder("pf-c-form__helper-text")
        .AddClass("pf-m-hidden", IsHidden)
        .AddClass("pf-m-error" , IsError)
        .AddClassFromAttributes(AdditionalAttributes);

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index     = 0;
        var component = Component switch
        {
            FormHelperTextVariant.p   => "p",
            FormHelperTextVariant.div => "div",
            _                         => null
        };
        
        builder.OpenElement(index++, component);
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass);

        if (Icon is not null)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-form__helper-text-icon");
            builder.AddContent(index++, Icon);
            builder.CloseElement();
        }
        
        builder.AddContent(index++, ChildContent);

        builder.CloseElement();
    }
}
