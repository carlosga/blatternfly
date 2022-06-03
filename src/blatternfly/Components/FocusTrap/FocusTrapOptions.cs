using System.Text.Json.Serialization;

namespace Blatternfly.Components;

public sealed class FocusTrapOptions
{
    [JsonPropertyName("returnFocusOnDeactivatewidth")]
    public bool ReturnFocusOnDeactivate { get; set; } = true;

    [JsonPropertyName("escapeDeactivates")]
    public bool EscapeDeactivates { get; set; }

    [JsonPropertyName("clickOutsideDeactivates")]
    public bool ClickOutsideDeactivates { get; set; }

    [JsonPropertyName("allowOutsideClick")]
    public bool AllowOutsideClick { get; set; }

    [JsonPropertyName("preventScroll")]
    public bool PreventScroll { get; set; }

    [JsonPropertyName("delayInitialFocus")]
    public bool DelayInitialFocus { get; set; }

    [JsonPropertyName("tabbableOptions")]
    public TabbableOptions TabbableOptions { get; set; }
}
