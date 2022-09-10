namespace Blatternfly.Components;

public partial class FormHelperText : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// Adds error styling to the Helper Text.
    [Parameter]
    public bool IsError { get; set; }

    /// Hides the helper text
    [Parameter]
    public bool IsHidden { get; set; } = true;

    /// Icon displayed to the left of the helper text.
    [Parameter]
    public RenderFragment Icon { get; set; }

    /// Component type of the form helper text.
    [Parameter]
    public FormHelperTextVariant Component { get; set; } = FormHelperTextVariant.p;

    private string CssClass => new CssBuilder("pf-c-form__helper-text")
        .AddClass("pf-m-hidden", IsHidden)
        .AddClass("pf-m-error" , IsError)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Container
    {
        get
        {
            return Component switch
            {
                FormHelperTextVariant.p   => "p",
                FormHelperTextVariant.div => "div",
                _                         => null
            };
        }
    }
}
