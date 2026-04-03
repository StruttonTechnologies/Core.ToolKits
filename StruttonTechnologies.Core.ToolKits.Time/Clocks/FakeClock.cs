using StruttonTechnologies.Core.ToolKits.Time.Abstractions;

namespace StruttonTechnologies.Core.ToolKits.Time.Clocks
{
    /// <summary>
    /// Mutable clock for tests and deterministic time-dependent workflows.
    /// </summary>
    public sealed class FakeClock : IClock
    {
        public FakeClock()
            : this(DateTime.UtcNow)
        {
        }

        public FakeClock(DateTime utcNow)
        {
            UtcNow = EnsureUtc(utcNow);
        }

        public DateTime UtcNow { get; private set; }

        public void Set(DateTime utcNow) => UtcNow = EnsureUtc(utcNow);

        public void Advance(TimeSpan by) => UtcNow = UtcNow.Add(by);

        private static DateTime EnsureUtc(DateTime value) =>
            value.Kind switch
            {
                DateTimeKind.Utc => value,
                DateTimeKind.Local => value.ToUniversalTime(),
                _ => DateTime.SpecifyKind(value, DateTimeKind.Utc),
            };
    }
}
