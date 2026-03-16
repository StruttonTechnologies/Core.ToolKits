using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Time
{
    /// <summary>
    /// Provides reusable fixed date and time values for tests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TimeValues
    {
        /// <summary>
        /// Gets a sample local date and time value.
        /// </summary>
        public static DateTime SampleLocal { get; } = new(2025, 1, 15, 8, 30, 0, DateTimeKind.Local);

        /// <summary>
        /// Gets a sample UTC date and time value.
        /// </summary>
        public static DateTime SampleUtc { get; } = new(2025, 1, 15, 16, 30, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets a sample date and time offset value.
        /// </summary>
        public static DateTimeOffset SampleOffset { get; } = new(2025, 1, 15, 8, 30, 0, TimeSpan.FromHours(-8));

        /// <summary>
        /// Gets a sample past UTC date and time value.
        /// </summary>
        public static DateTime PastUtc { get; } = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets a sample future UTC date and time value.
        /// </summary>
        public static DateTime FutureUtc { get; } = new(2030, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
