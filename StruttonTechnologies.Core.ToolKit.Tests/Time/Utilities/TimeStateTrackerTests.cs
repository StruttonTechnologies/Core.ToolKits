using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Clocks;
using StruttonTechnologies.Core.ToolKits.Time.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Utilities
{
    [ExcludeFromCodeCoverage]
    public class TimeStateTrackerTests
    {
        [Fact]
        public void Constructor_ShouldUseSystemClock_WhenClockIsNull()
        {
            var tracker = new TimeStateTracker(null);

            tracker.Touch("test");

            Assert.True(tracker.Exists("test"));
        }

        [Fact]
        public void Constructor_ShouldUseFakeClock_WhenProvided()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new TimeStateTracker(clock);

            tracker.Touch("test");
            clock.Advance(TimeSpan.FromHours(1));

            var age = tracker.Age("test");

            Assert.Equal(TimeSpan.FromHours(1), age);
        }

        [Fact]
        public void Touch_ShouldThrowArgumentException_WhenKeyIsNull()
        {
            var tracker = new TimeStateTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.Touch(null!));
        }

        [Fact]
        public void Touch_ShouldThrowArgumentException_WhenKeyIsEmpty()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.Touch(string.Empty));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void Touch_ShouldThrowArgumentException_WhenKeyIsWhitespace()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.Touch("   "));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void Touch_ShouldRecordTimestamp()
        {
            var tracker = new TimeStateTracker();

            tracker.Touch("key1");

            Assert.True(tracker.Exists("key1"));
        }

        [Fact]
        public void Touch_ShouldUpdateExistingKey()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new TimeStateTracker(clock);

            tracker.Touch("key1");
            clock.Advance(TimeSpan.FromHours(1));
            tracker.Touch("key1");

            var age = tracker.Age("key1");

            Assert.True(age < TimeSpan.FromMinutes(1));
        }

        [Fact]
        public void Touch_ShouldBeCaseInsensitive()
        {
            var tracker = new TimeStateTracker();

            tracker.Touch("Key1");

            Assert.True(tracker.Exists("key1"));
            Assert.True(tracker.Exists("KEY1"));
        }

        [Fact]
        public void Exists_ShouldThrowArgumentException_WhenKeyIsNull()
        {
            var tracker = new TimeStateTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.Exists(null!));
        }

        [Fact]
        public void Exists_ShouldThrowArgumentException_WhenKeyIsEmpty()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.Exists(string.Empty));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void Exists_ShouldThrowArgumentException_WhenKeyIsWhitespace()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.Exists("   "));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void Exists_ShouldReturnFalse_WhenKeyNotTracked()
        {
            var tracker = new TimeStateTracker();

            Assert.False(tracker.Exists("nonexistent"));
        }

        [Fact]
        public void Exists_ShouldReturnTrue_WhenKeyTracked()
        {
            var tracker = new TimeStateTracker();

            tracker.Touch("key1");

            Assert.True(tracker.Exists("key1"));
        }

        [Fact]
        public void HasExpired_ShouldThrowArgumentException_WhenKeyIsNull()
        {
            var tracker = new TimeStateTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.HasExpired(null!, TimeSpan.FromHours(1)));
        }

        [Fact]
        public void HasExpired_ShouldThrowArgumentException_WhenKeyIsEmpty()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.HasExpired(string.Empty, TimeSpan.FromHours(1)));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void HasExpired_ShouldThrowArgumentException_WhenKeyIsWhitespace()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.HasExpired("   ", TimeSpan.FromHours(1)));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void HasExpired_ShouldThrowArgumentOutOfRangeException_WhenExpirationIsNegative()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                tracker.HasExpired("key1", TimeSpan.FromHours(-1)));

            Assert.Equal("expiration", exception.ParamName);
        }

        [Fact]
        public void HasExpired_ShouldReturnTrue_WhenKeyNotTracked()
        {
            var tracker = new TimeStateTracker();

            Assert.True(tracker.HasExpired("nonexistent", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void HasExpired_ShouldReturnFalse_WhenNotExpired()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new TimeStateTracker(clock);

            tracker.Touch("key1");
            clock.Advance(TimeSpan.FromMinutes(30));

            Assert.False(tracker.HasExpired("key1", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void HasExpired_ShouldReturnTrue_WhenExpired()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new TimeStateTracker(clock);

            tracker.Touch("key1");
            clock.Advance(TimeSpan.FromHours(1));

            Assert.True(tracker.HasExpired("key1", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void HasExpired_ShouldReturnTrue_WhenExpiredBeyondExpiration()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new TimeStateTracker(clock);

            tracker.Touch("key1");
            clock.Advance(TimeSpan.FromHours(2));

            Assert.True(tracker.HasExpired("key1", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void Age_ShouldThrowArgumentException_WhenKeyIsNull()
        {
            var tracker = new TimeStateTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.Age(null!));
        }

        [Fact]
        public void Age_ShouldThrowArgumentException_WhenKeyIsEmpty()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.Age(string.Empty));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void Age_ShouldThrowArgumentException_WhenKeyIsWhitespace()
        {
            var tracker = new TimeStateTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.Age("   "));

            Assert.Equal("key", exception.ParamName);
        }

        [Fact]
        public void Age_ShouldReturnZero_WhenKeyNotTracked()
        {
            var tracker = new TimeStateTracker();

            var age = tracker.Age("nonexistent");

            Assert.Equal(TimeSpan.Zero, age);
        }

        [Fact]
        public void Age_ShouldReturnCorrectAge()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new TimeStateTracker(clock);

            tracker.Touch("key1");
            clock.Advance(TimeSpan.FromHours(3));

            var age = tracker.Age("key1");

            Assert.Equal(TimeSpan.FromHours(3), age);
        }
    }
}
