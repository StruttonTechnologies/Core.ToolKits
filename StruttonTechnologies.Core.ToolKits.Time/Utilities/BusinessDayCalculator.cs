namespace StruttonTechnologies.Core.ToolKit.Time.Utilities
{
    /// <summary>
    /// Provides business-day calculations with configurable weekends and holidays.
    /// </summary>
    public sealed class BusinessDayCalculator
    {
        private readonly HashSet<DayOfWeek> _weekendDays;
        private readonly HashSet<DateOnly> _holidays;

        public BusinessDayCalculator(
            IEnumerable<DayOfWeek>? weekendDays = null,
            IEnumerable<DateOnly>? holidays = null)
        {
            _weekendDays = new HashSet<DayOfWeek>(weekendDays ?? [DayOfWeek.Saturday, DayOfWeek.Sunday]);
            _holidays = new HashSet<DateOnly>(holidays ?? Array.Empty<DateOnly>());
        }

        public bool IsBusinessDay(DateTime date)
        {
            var day = DateOnly.FromDateTime(date);
            return !_weekendDays.Contains(date.DayOfWeek) && !_holidays.Contains(day);
        }

        public DateTime NextBusinessDay(DateTime date)
        {
            var current = date.Date.AddDays(1);

            while (!IsBusinessDay(current))
            {
                current = current.AddDays(1);
            }

            return current;
        }

        public DateTime PreviousBusinessDay(DateTime date)
        {
            var current = date.Date.AddDays(-1);

            while (!IsBusinessDay(current))
            {
                current = current.AddDays(-1);
            }

            return current;
        }

        public int CountBusinessDays(DateTime startInclusive, DateTime endInclusive)
        {
            if (endInclusive < startInclusive)
            {
                return 0;
            }

            var count = 0;
            for (var current = startInclusive.Date; current <= endInclusive.Date; current = current.AddDays(1))
            {
                if (IsBusinessDay(current))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
