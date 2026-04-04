using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Testing.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Utilities
{
    [ExcludeFromCodeCoverage]
    public class TestClockFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnFakeClock_WhenUtcNowIsNull()
        {
            var clock = TestClockFactory.Create();

            Assert.NotNull(clock);
            Assert.True(clock.UtcNow.Year > 0);
        }

        [Fact]
        public void Create_ShouldReturnFakeClockWithSpecifiedTime_WhenUtcNowProvided()
        {
            var expectedTime = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);

            var clock = TestClockFactory.Create(expectedTime);

            Assert.Equal(expectedTime, clock.UtcNow);
        }

        [Fact]
        public void Create_ShouldReturnMutableClock()
        {
            var clock = TestClockFactory.Create(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            clock.Advance(TimeSpan.FromHours(1));

            Assert.Equal(new DateTime(2024, 1, 1, 1, 0, 0, DateTimeKind.Utc), clock.UtcNow);
        }
    }
}
