using System;

namespace Blatternfly.Components
{
    internal readonly struct CalendarDay
    {
        internal int Index { get; }
        internal DateTime Date { get; }
        internal bool IsValid { get; }

        internal CalendarDay(int index, DateTime date, bool isValid)
        {
            Index   = index;
            Date    = date;
            IsValid = isValid;
        }
    }
}
