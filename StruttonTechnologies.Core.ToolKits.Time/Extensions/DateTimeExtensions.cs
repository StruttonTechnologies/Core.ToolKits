namespace StruttonTechnologies.Core.ToolKits.Time.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date, IReadOnlyCollection<DayOfWeek>? weekendDays = null)
        {
            weekendDays ??= DefaultWeekendDays;
            return weekendDays.Contains(date.DayOfWeek);
        }

        public static bool IsWeekday(this DateTime date, IReadOnlyCollection<DayOfWeek>? weekendDays = null) =>
            !date.IsWeekend(weekendDays);

        public static DateTime StartOfDayUtc(this DateTime date) =>
            new(DateTime.SpecifyKind(date.Date, DateTimeKind.Utc).Ticks, DateTimeKind.Utc);

        public static DateTime EndOfDayUtc(this DateTime date) =>
            date.StartOfDayUtc().AddDays(1).AddTicks(-1);

        public static DateTime StartOfMonth(this DateTime date) =>
            new(date.Year, date.Month, 1, 0, 0, 0, date.Kind);

        public static DateTime EndOfMonth(this DateTime date) =>
            date.StartOfMonth().AddMonths(1).AddTicks(-1);

        public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            var diff = (7 + (date.DayOfWeek - firstDayOfWeek)) % 7;
            return date.Date.AddDays(-diff);
        }

        public static DateTime EndOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday) =>
            date.StartOfWeek(firstDayOfWeek).AddDays(7).AddTicks(-1);

        public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        {
            var days = ((int)dayOfWeek - (int)date.DayOfWeek + 7) % 7;
            days = days == 0 ? 7 : days;
            return date.Date.AddDays(days);
        }

        public static DateTime Previous(this DateTime date, DayOfWeek dayOfWeek)
        {
            var days = ((int)date.DayOfWeek - (int)dayOfWeek + 7) % 7;
            days = days == 0 ? 7 : days;
            return date.Date.AddDays(-days);
        }

        public static IEnumerable<DateTime> EachDay(this DateTime startInclusive, DateTime endInclusive)
        {
            if (endInclusive < startInclusive)
            {
                yield break;
            }

            for (var current = startInclusive.Date; current <= endInclusive.Date; current = current.AddDays(1))
            {
                yield return current;
            }
        }

        private static readonly DayOfWeek[] DefaultWeekendDays = [DayOfWeek.Saturday, DayOfWeek.Sunday];
    }
}
