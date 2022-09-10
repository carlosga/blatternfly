namespace Blatternfly.Components;

public partial class FormSelectOption : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// The value for the option.
    /// </summary>
    [Parameter]
    public string Value { get; set; }

    /// <summary>
    /// The label for the option.
    /// </summary>
    [Parameter]
    public string Label { get; set; }

    /// <summary>
    /// Flag indicating if the option is disabled.
    /// </summary>
    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>
    /// flag indicating if option will have placeholder styling applied when selected.
    /// </summary>
    [Parameter]
    public bool IsPlaceholder { get; set; }
}