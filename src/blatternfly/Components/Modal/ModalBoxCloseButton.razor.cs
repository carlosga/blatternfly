namespace Blatternfly.Components;

public partial class ModalBoxCloseButton : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// A callback for when the close button is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }
}