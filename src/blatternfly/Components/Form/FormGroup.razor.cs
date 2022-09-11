namespace Blatternfly.Components;

public partial class FormGroup : ComponentBase
{
    [Inject]
    private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Label text before the field.</summary>
    [Parameter] public string Label { get; set; }

    /// <summary>Additional label information displayed after the label.</summary>
    [Parameter] public string LabelInfo { get; set; }

    /// <summary>Sets an icon for the label.</summary>
    [Parameter] public RenderFragment LabelIcon { get; set; }

    /// <summary>Sets the FormGroup required.</summary>
    [Parameter] public bool IsRequired { get; set; }

    /// <summary>
    /// Sets the FormGroup validated. If you set to success, text color of helper text will be modified to indicate valid state.
    /// If set to error,  text color of helper text will be modified to indicate error state.
    /// </summary>
    [Parameter] public ValidatedOptions? Validated { get; set; }

    /// <summary>Sets the FormGroup isInline.</summary>
    [Parameter] public bool IsInline { get; set; }

    /// <summary>Sets the FormGroupControl to be stacked.</summary>
    [Parameter] public bool IsStack { get; set; }

    /// <summary>Removes top spacer from label.</summary>
    [Parameter] public bool HasNoPaddingTop { get; set; }

    /// <summary>Helper text after the field. It can be a simple text or an object.</summary>
    [Parameter] public string HelperText { get; set; }

    /// <summary>Hides the helper text</summary>
    [Parameter] public bool HelperTextHidden { get; set; }

    /// <summary>Flag to position the helper text before the field. False by default.</summary>
    [Parameter] public bool IsHelperTextBeforeField { get; set; }

    /// <summary>Helper text after the field when the field is isValid. It can be a simple text or an object.</summary>
    [Parameter] public string HelperTextInvalid { get; set; }

    /// <summary>Icon displayed to the left of the helper text.</summary>
    [Parameter] public RenderFragment HelperTextIcon { get; set; }

    /// <summary>Icon displayed to the left of the helper text when the field is invalid. */</summary>
    [Parameter] public RenderFragment HelperTextInvalidIcon { get; set; }

    /// <summary>ID of the included field. It has to be the same for proper working.</summary>
    [Parameter] public string FieldId { get; set; }

    /// <summary>
    /// Sets the role of the form group. Pass in "radiogroup" when the form group contains multiple
    /// radio inputs, or pass in "group" when the form group contains multiple of any other input type.
    /// </summary>
    [Parameter] public string Role { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__group")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string FormGroupLabelCssClass => new CssBuilder("pf-c-form__group-label")
        .AddClass("pf-m-info"           , !string.IsNullOrEmpty(LabelInfo))
        .AddClass("pf-m-no-padding-top" , HasNoPaddingTop)
        .Build();

    private string FormGroupControlCssClass => new CssBuilder("pf-c-form__group-control")
        .AddClass("pf-m-inline", IsInline)
        .AddClass("pf-m-stack" , IsStack)
        .Build();

    private string HelperTextCssClass => new CssBuilder("pf-c-form__helper-text")
        .AddClass("pf-m-success", IsValid)
        .AddClass("pf-m-error"  , HasErrors)
        .AddClass("pf-m-warning", HasWarnings)
        .Build();

    private string RandomId { get; set; }

    private bool   IsValid             { get => Validated is ValidatedOptions.Success; }
    private bool   HasErrors           { get => Validated is ValidatedOptions.Error; }
    private bool   HasWarnings         { get => Validated is ValidatedOptions.Warning; }
    private bool   IsGroupOrRadioGroup { get => Role == "group" || Role == "radiogroup"; }
    private string HelperTextId        { get => $"{FieldId}-helper"; }
    private string AriaLabelledBy      { get => IsGroupOrRadioGroup ? LegendId : null; }
    private string LegendId            { get => IsGroupOrRadioGroup ? $"{FieldId ?? RandomId}-legend" : null; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (string.IsNullOrEmpty(FieldId))
        {
           RandomId = ComponentIdGenerator.Generate("pf-c-form__group");
        }
    }

    internal void UpdateValidationState(ValidatedOptions? validated, string helperTextInvalid)
    {
        Validated         = validated;
        HelperTextInvalid = helperTextInvalid;
    }
}