using System.ComponentModel;
using System.Text.Json.Serialization;
using Blatternfly.Converters;

namespace Blatternfly.Components
{
    [JsonConverter(typeof(EnumDescriptionConverter<PopoverPosition>))]
    public enum PopoverPosition
    {
        [Description("auto")] Auto,
        [Description("top")] Top,
        [Description("top-start")] TopStart,
        [Description("top-end")] TopEnd,
        [Description("bottom")] Bottom,
        [Description("bottom-start")] BottomStart,
        [Description("bottom-end")] BottomEnd,
        [Description("right")] Right,
        [Description("right-start")] RightStart,
        [Description("right-end")] RightEnd,
        [Description("left")] Left,
        [Description("left-start")] LeftStart,
        [Description("left-end")] LeftEnd
    }
}
