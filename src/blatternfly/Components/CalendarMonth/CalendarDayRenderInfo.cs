using System;

namespace Blatternfly.Components;

internal sealed class CalendarDayRenderInfo
{
    internal int Index                { get; set; }
    internal DateOnly Date            { get; set; }
    internal string DayFormatted      { get; set; }
    internal int TabIndex             { get; set; }
    internal bool IsDisabled          { get; set; }
    internal bool IsToday             { get; set; }
    internal bool IsSelected          { get; set; }
    internal bool IsFocused           { get; set; }
    internal bool IsAdjacentMonth     { get; set; }
    internal bool IsInRange           { get; set; }
    internal bool IsRangeStart        { get; set; }
    internal bool IsRangeEnd          { get; set; }
    internal string CellCssClass      { get; set; }
    internal string MonthDateCssClass { get; set; } 
}
