using System;
using System.Collections.Generic;
using System.Globalization;

namespace Blatternfly.Components;

internal static class CalendarBuilder
{
    internal static IReadOnlyList<CalendarDay[]> Build(
        int year,
        int month,
        DayOfWeek? weekStart,
        CultureInfo locale,
        IEnumerable<IDateValidator> validators)
    {
        weekStart        ??= locale.DateTimeFormat.FirstDayOfWeek;
        var selectedDate   = new DateOnly(year, month, 1);
        var firstDayOfWeek = selectedDate.AddDays(-((int)selectedDate.DayOfWeek - (int)weekStart));

        // We will always show 6 weeks like google calendar
        // Assume we just want the numbers for now...
        var calendarWeeks = new List<CalendarDay[]>(6);
        for (var i = 0; i < 6; i++)
        {
            var week = new CalendarDay[7];
            for (var j = 0; j < 7; j++)
            {
                var date    = firstDayOfWeek;
                var isValid = true;

                if (validators is not null)
                {
                    foreach (var validator in validators)
                    {
                        isValid = validator.Validate(date);
                        if (!isValid)
                        {
                            break;
                        }
                    }
                }

                week[j] = new CalendarDay(j, date, isValid);
                firstDayOfWeek = firstDayOfWeek.AddDays(1);
            }
            calendarWeeks.Add(week);
        }

        return calendarWeeks;
    }
}
