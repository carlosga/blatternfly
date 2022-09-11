namespace Blatternfly.Components;

public partial class AlertActionCloseButton
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Aria Label for the Close button.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Variant Label for the Close button.</summary>
    [Parameter] public string VariantLabel { get; set; }

    /// <summary>Title Label for the Close button.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>A callback for when the close button is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    private string AriaLabelValue
    {
        get => string.IsNullOrEmpty(AriaLabel) ? $"Close {VariantLabel} alert: {Title}" : AriaLabel;
    }
}
