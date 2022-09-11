namespace Blatternfly.Components;

public partial class FormFieldGroupToggle : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Flag indicating if the toggle is expanded.
    /// </summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>
    /// Aria label of the toggle button.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>
    /// Sets the aria-labelledby attribute on the toggle button element.
    /// </summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>
    /// The id applied to the toggle button.
    /// </summary>
    [Parameter] public string ToggleId { get; set; }

    /// <summary>
    /// Callback for onClick.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__field-group-toggle")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaExpanded { get => IsExpanded ? "true" : "false"; }
}