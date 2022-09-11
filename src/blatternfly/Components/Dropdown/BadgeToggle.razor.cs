namespace Blatternfly.Components;

public partial class BadgeToggle : ComponentBase
{
    [CascadingParameter] private Dropdown Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag to indicate if menu is opened.</summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>Label Toggle button.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Actions";

    /// <summary>Callback called when toggle is clicked.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>Forces active state.</summary>
    [Parameter] public bool IsActive { get; set; }

    /// <summary>Disables the dropdown toggle.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Display the toggle with no border or background.</summary>
    [Parameter] public bool IsPlain { get; set; } = true;

    /// <summary>Type to put on the button.</summary>
    [Parameter] public ButtonType? Type { get; set; }

    /// <summary>Allows selecting toggle to select parent.</summary>
    [Parameter] public bool BubbleEvent { get; set; }

    /// <summary>Display the toggle with no border or background.</summary>
    [Parameter] public bool IsRead { get; set; } = true;

    private async Task ToggleHandler(bool isOpen)
    {
        IsOpen = isOpen;
        Parent?.OnToggle(isOpen);
        await OnToggle.InvokeAsync(isOpen);
        StateHasChanged();
    }
}