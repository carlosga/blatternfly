using System.Globalization;

namespace Blatternfly.Components;

internal static class CalendarBuilder
{
    internal static IReadOnlyList<CalendarDay[]> Build(
        int                         year,
        int                         month,
        DayOfWeek?                  weekStart,
        CultureInfo                 locale,
        IEnumerable<IDateValidator> validators)
    {
        weekStart        ??= locale.DateTimeFormat.FirstDayOfWeek;
        var defaultDate    = new DateOnly(year, month, 1);
        var firstDayOfWeek = defaultDate.AddDays(-((int)defaultDate.DayOfWeek - (int)weekStart));

        // We will show a maximum of 6 weeks like Google calendar
        // Assume we just want the numbers for now...
        var calendarWeeks = new List<CalendarDay[]>(6);

        if (firstDayOfWeek.Month == defaultDate.Month && firstDayOfWeek.Day == 1)
        {
            firstDayOfWeek = firstDayOfWeek.AddDays(- 7);
        }

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
            if (firstDayOfWeek.Month != defaultDate.Month)
            {
                break;
            }
        }

        return calendarWeeks;
    }
}
