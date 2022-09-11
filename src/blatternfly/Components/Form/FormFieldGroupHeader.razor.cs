namespace Blatternfly.Components;

public partial class FormFieldGroupHeader : ComponentBase
{
    [CascadingParameter] private InternalFormFieldGroup FormFieldGroup { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Title text.
    /// </summary>
    [Parameter] public string TitleText { get; set; }

    /// <summary>
    /// The applied to the title div for accessibility.
    /// </summary>
    [Parameter] public string TitleTextId { get; set; }

    /// <summary>
    /// Field group header title description.
    /// </summary>
    [Parameter] public string TitleDescription { get; set; }

    /// <summary>
    /// Field group header actions.
    /// </summary>
    [Parameter] public RenderFragment Actions { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__field-group-header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        FormFieldGroup.SetHeader(this);
    }
}