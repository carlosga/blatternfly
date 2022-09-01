namespace Blatternfly.Components;

public partial class DataListCheck : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Flag to show if the DataList checkbox selection is valid or invalid.
    /// </summary>
    [Parameter]
    public bool IsValid { get; set; } = true;

    /// <summary>
    /// Flag to show if the DataList checkbox is disabled.
    /// </summary>
    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Flag to show if the DataList checkbox is checked.
    /// </summary>
    [Parameter]
    public bool IsChecked { get; set; }

    /// <summary>
    /// A callback for when the DataList checkbox selection changes.
    /// </summary>
    [Parameter]
    public EventCallback<bool> OnChange { get; set; }

    /// <summary>
    /// Aria-labelledby of the DataList checkbox.
    /// </summary>
    [Parameter]
    public string AriaLabelledBy { get; set; }

    /// <summary>
    /// Flag to indicate if other controls are used in the DataListItem.
    /// </summary>
    [Parameter]
    public bool OtherControls { get; set; }

    private string AriaInvalid { get => !IsValid ? "true" : "false"; }

    private async Task ChangeHandler()
    {
        IsChecked = !IsChecked;
        await OnChange.InvokeAsync(IsChecked);
    }
}
