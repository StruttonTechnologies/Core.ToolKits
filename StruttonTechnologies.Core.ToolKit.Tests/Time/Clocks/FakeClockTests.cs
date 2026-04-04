using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Clocks;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Clocks
{
    [ExcludeFromCodeCoverage]
    public class FakeClockTests
    {
        [Fact]
        public void Constructor_ShouldSetUtcNow_WhenCalledWithNoParameters()
        {
            var before = DateTime.UtcNow;
            var clock = new FakeClock();
            var after = DateTime.UtcNow;

            Assert.InRange(clock.UtcNow, before, after);
        }

        [Fact]
        public void Constructor_ShouldSetUtcTime_WhenCalledWithUtcDateTime()
        {
            var utcTime = new DateTime(2024, 1, 15, 10, 30, 0, DateTimeKind.Utc);

            var clock = new FakeClock(utcTime);

            Assert.Equal(utcTime, clock.UtcNow);
            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
        }

        [Fact]
        public void Constructor_ShouldConvertToUtc_WhenCalledWithLocalDateTime()
        {
            var localTime = new DateTime(2024, 1, 15, 10, 30, 0, DateTimeKind.Local);

            var clock = new FakeClock(localTime);

            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
            Assert.Equal(localTime.ToUniversalTime(), clock.UtcNow);
        }

        [Fact]
        public void Constructor_ShouldConvertToUtc_WhenCalledWithUnspecifiedDateTime()
        {
            var unspecifiedTime = new DateTime(2024, 1, 15, 10, 30, 0, DateTimeKind.Unspecified);

            var clock = new FakeClock(unspecifiedTime);

            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
        }

        [Fact]
        public void Set_ShouldUpdateUtcNow_WhenCalledWithUtcDateTime()
        {
            var clock = new FakeClock();
            var newTime = new DateTime(2025, 6, 1, 12, 0, 0, DateTimeKind.Utc);

            clock.Set(newTime);

            Assert.Equal(newTime, clock.UtcNow);
        }

        [Fact]
        public void Set_ShouldConvertToUtc_WhenCalledWithLocalDateTime()
        {
            var clock = new FakeClock();
            var localTime = new DateTime(2025, 6, 1, 12, 0, 0, DateTimeKind.Local);

            clock.Set(localTime);

            Assert.Equal(DateTimeKind.Utc, clock.UtcNow.Kind);
            Assert.Equal(localTime.ToUniversalTime(), clock.UtcNow);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(24)]
        public void Advance_ShouldIncrementTime_WhenCalledWithHours(int hours)
        {
            var initialTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var clock = new FakeClock(initialTime);

            clock.Advance(TimeSpan.FromHours(hours));

            Assert.Equal(initialTime.AddHours(hours), clock.UtcNow);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void Advance_ShouldIncrementTime_WhenCalledWithMinutes(int minutes)
        {
            var initialTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var clock = new FakeClock(initialTime);

            clock.Advance(TimeSpan.FromMinutes(minutes));

            Assert.Equal(initialTime.AddMinutes(minutes), clock.UtcNow);
        }

        [Fact]
        public void Advance_ShouldDecrementTime_WhenCalledWithNegativeTimeSpan()
        {
            var initialTime = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var clock = new FakeClock(initialTime);

            clock.Advance(TimeSpan.FromHours(-2));

            Assert.Equal(initialTime.AddHours(-2), clock.UtcNow);
        }

        [Fact]
        public void Advance_ShouldHandleMultipleCalls_WhenCalledSequentially()
        {
            var initialTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var clock = new FakeClock(initialTime);

            clock.Advance(TimeSpan.FromDays(1));
            clock.Advance(TimeSpan.FromHours(6));
            clock.Advance(TimeSpan.FromMinutes(30));

            var expected = initialTime.AddDays(1).AddHours(6).AddMinutes(30);
            Assert.Equal(expected, clock.UtcNow);
        }

        [Fact]
        public void Set_AndAdvance_ShouldWorkTogether()
        {
            var clock = new FakeClock();
            var baseTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            clock.Set(baseTime);
            clock.Advance(TimeSpan.FromDays(7));

            Assert.Equal(baseTime.AddDays(7), clock.UtcNow);
        }
    }
}
