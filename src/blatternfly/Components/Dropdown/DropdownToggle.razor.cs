namespace Blatternfly.Components;

public partial class DropdownToggle : ComponentBase
{
    [CascadingParameter] private Dropdown Parent { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag to indicate if menu is opened.
    /// </summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>
    /// Callback called when toggle is clicked.
    /// </summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>
    /// Callback called when the Enter key is pressed.
    /// </summary>
    [Parameter] public EventCallback OnEnter { get; set; }

    /// <summary>
    /// Forces active state.
    /// </summary>
    [Parameter] public bool IsActive { get; set; }

    /// <summary>
    /// Display the toggle with no border or background.
    /// </summary>
    [Parameter] public bool? IsPlain { get; set; }

    /// <summary>
    /// Display the toggle in text only mode.
    /// </summary>
    [Parameter] public bool? IsText { get; set; }

    /// <summary>
    /// Whether or not the dropdown toggle has a disabled state.
    /// </summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>
    /// Alternate styles for the dropdown toggle button.
    /// </summary>
    [Parameter] public ToggleVariant ToggleVariant { get; set; } = ToggleVariant.Default;

    /// <summary>
    /// An image to display within the dropdown toggle, appearing before any component children.
    /// </summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>
    /// Accessible label for the dropdown toggle button.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>
    /// Accessibility property to indicate correct has popup.
    /// </summary>
    [Parameter] public AriaPopupVariant? AriaHasPopup { get; set; }

    /// <summary>
    /// Type to put on the button.
    /// </summary>
    [Parameter] public ButtonType? Type { get; set; }

    /// <summary>
    /// </summary>
    [Parameter] public string ToggleIndicatorClass { get; set; }

    /// <summary>
    /// </summary>
    [Parameter] public string ToggleIconClass      { get; set; }

    /// <summary>
    /// </summary>
    [Parameter] public string ToggleTextClass      { get; set; }

    /// <summary>
    /// </summary>
    [Parameter] public string ToggleClass          { get; set; }

    private bool? IsPlainValue
    {
        get => IsPlain.HasValue ? IsPlain.Value : Parent?.IsPlain;
    }

    private bool? IsTextValue
    {
        get => IsText.HasValue ? IsText.Value : Parent?.IsText;
    }

    private string ToggleIconCssClass
    {
        get => string.IsNullOrEmpty(ToggleIconClass) ? "pf-c-dropdown__toggle-icon" : ToggleIconClass;
    }
    private string ToggleTextCssClass
    {
        get => string.IsNullOrEmpty(ToggleTextClass) ? "pf-c-dropdown__toggle-text" : ToggleTextClass;
    }
    private string ToggleIndicatorCssClass
    {
        get => string.IsNullOrEmpty(ToggleIndicatorClass) ? "pf-c-dropdown__toggle-icon" : ToggleIndicatorClass;
    }

    private async Task ToggleHandler(bool isOpen)
    {
        IsOpen = isOpen;
        await OnToggle.InvokeAsync(isOpen);
        Parent.OnToggle(isOpen);
        StateHasChanged();
    }

    private async Task OnEnterHandler()
    {
        IsOpen = !IsOpen;
        Parent.OnEnter();
        await OnEnter.InvokeAsync();
        await OnToggle.InvokeAsync(IsOpen);
        StateHasChanged();
    }
}