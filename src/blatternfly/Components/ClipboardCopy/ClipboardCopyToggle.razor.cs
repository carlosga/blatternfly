namespace Blatternfly.Components;

public partial class ClipboardCopyToggle : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary></summary>
    [Parameter] public string id { get; set; }

    /// <summary></summary>
    [Parameter] public string TextId { get; set; }

    /// <summary></summary>
    [Parameter] public string ContentId { get; set; }

    /// <summary></summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary></summary>
    [Parameter] public bool IsExpanded { get; set; }

    private string AriaLabelledBy { get => $"{id} {TextId}"; }
    private string AriaControls   { get => $"{id} {ContentId}"; }
    private string AriaExpanded   { get => IsExpanded ? "true" : "false"; }
}
