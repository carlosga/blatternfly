using System;

namespace Blatternfly.Components;

internal readonly struct CalendarDay
{
    internal int Index { get; }
    internal DateOnly Date { get; }
    internal bool IsValid { get; }

    internal CalendarDay(int index, DateOnly date, bool isValid)
    {
        Index   = index;
        Date    = date;
        IsValid = isValid;
    }
}
