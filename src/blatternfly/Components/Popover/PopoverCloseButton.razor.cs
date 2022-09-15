namespace Blatternfly.Components;

public partial class PopoverCloseButton : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>PopoverCloseButton onClose function.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// <summary>Aria label for the Close button.</summary>
    [Parameter] public string AriaLabel { get; set; }
}