using System.ComponentModel;
using System.Text.Json.Serialization;
using Blatternfly.Converters;

namespace Blatternfly.Components;

[JsonConverter(typeof(EnumDescriptionConverter<PopoverPosition>))]
public enum PopoverPosition
{
  [Description("top")] Top,
  [Description("bottom")] Bottom,
  [Description("left")] Left,
  [Description("right")] Right,
};
