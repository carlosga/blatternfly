namespace Blatternfly.Components;

public partial class FormFieldGroupExpandable : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Form field group header.
    /// </summary>
    [Parameter]
    public RenderFragment Header { get; set; }

    /// <summary>
    /// Flag indicating if the form field group is initially expanded.
    /// </summary>
    [Parameter]
    public bool IsExpanded { get; set; }

    /// <summary>
    /// Aria-label to use on the form field group toggle button.
    /// </summary>
    [Parameter]
    public string ToggleAriaLabel { get; set; }

    private void OnToggle(MouseEventArgs _)
    {
        IsExpanded = !IsExpanded;
    }
}