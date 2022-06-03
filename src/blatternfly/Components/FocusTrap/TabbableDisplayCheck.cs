using System.ComponentModel;
using System.Text.Json.Serialization;
using Blatternfly.Converters;

namespace Blatternfly.Components;

[JsonConverter(typeof(EnumDescriptionConverter<TabbableDisplayCheck>))]
public enum TabbableDisplayCheck
{
    [Description("full")] Full,
    [Description("non-zero-area")] NonZeroArea,
    [Description("none")] None,
}
