namespace Blatternfly.Components;

/// <summary>Renders a close button for a dismissable alert when this sub-component is passed into the alert's <see cref="Alert.ActionClose" /> property.</summary>
public partial class AlertActionCloseButton
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Accessible label for the close button.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>A callback for when the close button is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// <summary>Title Label for the Close button.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>Variant Label for the Close button.</summary>
    [Parameter] public string VariantLabel { get; set; }

    private string AriaLabelValue
    {
        get => string.IsNullOrEmpty(AriaLabel) ? $"Close {VariantLabel} alert: {Title}" : AriaLabel;
    }
}
