namespace StruttonTechnologies.Core.ToolKits.Time.Utilities
{
    /// <summary>
    /// Generates recurring timestamps at a fixed interval.
    /// </summary>
    public static class RecurrenceGenerator
    {
        public static IEnumerable<DateTime> Generate(DateTime startInclusive, TimeSpan interval, DateTime endInclusive)
        {
            if (interval <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(interval), "Interval must be greater than zero.");
            }

            for (var current = startInclusive; current <= endInclusive; current = current.Add(interval))
            {
                yield return current;
            }
        }

        public static bool Matches(DateTime value, DateTime origin, TimeSpan interval)
        {
            if (interval <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(interval), "Interval must be greater than zero.");
            }

            if (value < origin)
            {
                return false;
            }

            return (value - origin).Ticks % interval.Ticks == 0;
        }
    }
}
