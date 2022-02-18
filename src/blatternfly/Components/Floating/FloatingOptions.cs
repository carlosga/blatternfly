using System.Text.Json.Serialization;

namespace Blatternfly.Components;

public sealed class FloatingOptions
{
    [JsonPropertyName("placement")]
    public TooltipPosition Placement { get; set; }

    [JsonPropertyName("distance")]
    public int Distance { get; set; }

    [JsonPropertyName("enableFlip")]
    public bool EnableFlip { get; set; }

    [JsonPropertyName("fallbackPlacements")]
    public TooltipPosition[] FallbackPlacements { get; set; }
}
