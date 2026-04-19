using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Time.Clocks;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Clocks
{
    [ExcludeFromCodeCoverage]
    public class SystemClockTests
    {
        [Fact]
        public void Instance_ShouldReturnSingletonInstance()
        {
            var instance1 = SystemClock.Instance;
            var instance2 = SystemClock.Instance;

            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void UtcNow_ShouldReturnUtcTime()
        {
            var clock = SystemClock.Instance;

            var result = clock.UtcNow;

            Assert.Equal(DateTimeKind.Utc, result.Kind);
        }

        [Fact]
        public void UtcNow_ShouldReturnCurrentTime()
        {
            var before = DateTime.UtcNow;
            var clock = SystemClock.Instance;
            var clockTime = clock.UtcNow;
            var after = DateTime.UtcNow;

            Assert.InRange(clockTime, before, after);
        }

        [Fact]
        public void UtcNow_ShouldProgressOverTime()
        {
            var clock = SystemClock.Instance;

            var time1 = clock.UtcNow;
            Thread.Sleep(10);
            var time2 = clock.UtcNow;

            Assert.True(time2 > time1);
        }
    }
}
