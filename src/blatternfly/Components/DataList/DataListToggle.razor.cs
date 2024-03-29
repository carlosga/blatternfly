namespace Blatternfly.Components;

public partial class DataListToggle : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Flag to show if the expanded content of the DataList item is visible.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Identify the DataList toggle number.</summary>
    [Parameter] public string Id { get; set; }

    /// <summary>Id for the row.</summary>
    [Parameter] public string RowId { get; set; }

    /// <summary>Adds accessible text to the DataList toggle.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Adds accessible text to the DataList toggle.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Details";

    /// <summary>
    /// Allows users of some screen readers to shift focus to the controlled element.
    /// Should be used when the controlled contents are not adjacent to the toggle that controls them.
    /// </summary>
    [Parameter] public string AriaControls { get; set; }

    /// <summary>Callback called when toggle is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__item-control")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaLabelledByValue { get => AriaLabel != "Details" ? null : $"{RowId} {Id}"; }
    private string AriaExpandedValue   { get => IsExpanded ? "true" : "false"; }
    private string AriaControlsValue   { get => !string.IsNullOrEmpty(AriaControls) ? AriaControls : "false"; }
}
