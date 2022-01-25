using System.Text.Json.Serialization;

namespace Blatternfly.Components;

public sealed class PopperOptions
{
    [JsonConverter(typeof(EnumDescriptionConverter<TooltipPosition>))]
    [JsonPropertyName("placement")]
    public TooltipPosition Placement { get; set; }

    [JsonPropertyName("distance")]
    public int Distance { get; set; }
}
