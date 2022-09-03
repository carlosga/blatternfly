namespace Blatternfly.Components;

public partial class KebabToggle : ComponentBase
{
    /// Parent Dropdown component.
    [CascadingParameter]
    private Dropdown Parent { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Flag to indicate if menu is opened.
    /// </summary>
    [Parameter]
    public bool IsOpen { get; set; }

    /// <summary>
    /// Label Toggle button.
    /// </summary>
    [Parameter]
    public string AriaLabel { get; set; }

    /// <summary>
    /// Callback called when toggle is clicked.
    /// </summary>
    [Parameter]
    public EventCallback<bool> OnToggle { get; set; }

    /// <summary>
    /// Forces active state.
    /// </summary>
    [Parameter]
    public bool IsActive { get; set; }

    /// <summary>
    /// Disables the dropdown toggle.
    /// </summary>
    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Display the toggle with no border or background.
    /// </summary>
    [Parameter]
    public bool? IsPlain { get; set; }

    /// <summary>
    /// Type to put on the button.
    /// </summary>
    [Parameter]
    public ButtonType? Type { get; set; }

    /// <summary>
    /// Allows selecting toggle to select parent.
    /// </summary>
    [Parameter]
    public bool BubbleEvent { get; set; }

    private async Task ToggleHandler(bool isOpen)
    {
        IsOpen = isOpen;
        Parent.OnToggle(isOpen);
        await OnToggle.InvokeAsync(IsOpen);
        StateHasChanged();
    }
}