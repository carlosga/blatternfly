namespace Blatternfly.Components;

public partial class AlertToggleExpandButton
{
    [CascadingParameter] private Alert Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Accessible label for the toggle button.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Flag to indicate if the content is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>A callback for when the toggle button is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggleExpand { get; set; }

    /// <summary>Variant label for the toggle button.</summary>
    [Parameter] public string VariantLabel { get; set; }

    private string AriaLabelValue
    {
        get => string.IsNullOrEmpty(AriaLabel)
            ? $"Toggle {VariantLabel ?? Parent.VariantLabel} alert: {Parent.Title}"
                : AriaLabel;
    }
}
