namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Time
{
    public sealed class FixedUtcClockTests
    {
        [Fact]
        public void Constructor_PreservesUtcValue_WhenInputIsAlreadyUtc()
        {
            DateTime value = new(2025, 1, 15, 16, 30, 0, DateTimeKind.Utc);

            FixedUtcClock clock = new(value);

            Assert.Equal(value, clock.UtcNow);
            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
        }

        [Fact]
        public void Constructor_ChangesKindToUtc_WhenInputIsUnspecified()
        {
            DateTime value = new(2025, 1, 15, 16, 30, 0, DateTimeKind.Unspecified);

            FixedUtcClock clock = new(value);

            Assert.Equal(value.Ticks, clock.UtcNow.Ticks);
            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
        }

        [Fact]
        public void Constructor_ChangesKindToUtc_WhenInputIsLocal()
        {
            DateTime value = new(2025, 1, 15, 8, 30, 0, DateTimeKind.Local);

            FixedUtcClock clock = new(value);

            Assert.Equal(value.Ticks, clock.UtcNow.Ticks);
            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
        }
    }
}
