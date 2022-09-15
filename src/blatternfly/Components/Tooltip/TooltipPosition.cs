using System.ComponentModel;
using System.Text.Json.Serialization;
using Blatternfly.Converters;

namespace Blatternfly.Components;

/// Tooltip positions.
[JsonConverter(typeof(EnumDescriptionConverter<TooltipPosition>))]
public enum TooltipPosition
{
    /// Auto.
    [Description("auto")] Auto,

    /// Top.
    [Description("top")] Top,

    /// Top-Start.
    [Description("top-start")] TopStart,

    /// Top-End.
    [Description("top-end")] TopEnd,

    /// Bottom.
    [Description("bottom")] Bottom,

    /// Bottom-Start.
    [Description("bottom-start")] BottomStart,

    /// Bottom-End.
    [Description("bottom-end")] BottomEnd,

    /// Right.
    [Description("right")] Right,

    /// Right-Star.
    [Description("right-start")] RightStart,

    /// Right-End.
    [Description("right-end")] RightEnd,

    /// Left.
    [Description("left")] Left,

    /// Left-Start.
    [Description("left-start")] LeftStart,

    /// Left-End.
    [Description("left-end")] LeftEnd
}
