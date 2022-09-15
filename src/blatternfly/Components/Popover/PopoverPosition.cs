using System.ComponentModel;
using System.Text.Json.Serialization;
using Blatternfly.Converters;

namespace Blatternfly.Components;

/// <summary>Popover positions.</summary>
[JsonConverter(typeof(EnumDescriptionConverter<PopoverPosition>))]
public enum PopoverPosition
{
    /// <summary>Auto.</summary>
    [Description("auto")] Auto,

    /// <summary>Top.</summary>
    [Description("top")] Top,

    /// <summary>Top-Start.</summary>
    [Description("top-start")] TopStart,

    /// <summary>Top-End.</summary>
    [Description("top-end")] TopEnd,

    /// <summary>Bottom.</summary>
    [Description("bottom")] Bottom,

    /// <summary>Bottom-Start.</summary>
    [Description("bottom-start")] BottomStart,

    /// <summary>Bottom-End.</summary>
    [Description("bottom-end")] BottomEnd,

    /// <summary>Right.</summary>
    [Description("right")] Right,

    /// <summary>Right-Start.</summary>
    [Description("right-start")] RightStart,

    /// <summary>Right-End.</summary>
    [Description("right-end")] RightEnd,

    /// <summary>Left.</summary>
    [Description("left")] Left,

    /// <summary>Left-Start.</summary>
    [Description("left-start")] LeftStart,

    /// <summary>Left-End.</summary>
    [Description("left-end")] LeftEnd
}
