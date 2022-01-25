using System.Text.Json.Serialization;

namespace Blatternfly.Components;

public sealed class PopperOptions
{
    [JsonPropertyName("placement")]
    public TooltipPosition Placement { get; set; }

    [JsonPropertyName("distance")]
    public int Distance { get; set; }

    [JsonPropertyName("enableFlip")]
    public bool EnableFlip { get; set; }

    [JsonPropertyName("fallbackPlacements")]
    public TooltipPosition[] FlipBehavior { get; set; }
}
