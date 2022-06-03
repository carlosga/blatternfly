using System.Text.Json.Serialization;

namespace Blatternfly.Components;

public sealed class TabbableOptions
{
    [JsonPropertyName("displayCheck")]
    public TabbableDisplayCheck? DisplayCheck { get; set; }
}
