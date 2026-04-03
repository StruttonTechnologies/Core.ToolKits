namespace StruttonTechnologies.Core.ToolKits.Time.Extensions
{
    public static class TimeZoneExtensions
    {
        public static DateTime ConvertTo(this DateTime value, TimeZoneInfo sourceTimeZone, TimeZoneInfo targetTimeZone)
        {
            ArgumentNullException.ThrowIfNull(sourceTimeZone);
            ArgumentNullException.ThrowIfNull(targetTimeZone);

            return TimeZoneInfo.ConvertTime(value, sourceTimeZone, targetTimeZone);
        }

        public static DateTime ConvertUtcTo(this DateTime utcValue, TimeZoneInfo targetTimeZone)
        {
            ArgumentNullException.ThrowIfNull(targetTimeZone);

            var normalized = utcValue.Kind == DateTimeKind.Utc
                ? utcValue
                : DateTime.SpecifyKind(utcValue, DateTimeKind.Utc);

            return TimeZoneInfo.ConvertTimeFromUtc(normalized, targetTimeZone);
        }

        public static DateTime ConvertToUtc(this DateTime localValue, TimeZoneInfo sourceTimeZone)
        {
            ArgumentNullException.ThrowIfNull(sourceTimeZone);
            return TimeZoneInfo.ConvertTimeToUtc(localValue, sourceTimeZone);
        }
    }
}
