using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Clocks;
using StruttonTechnologies.Core.ToolKits.Time.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Utilities
{
    [ExcludeFromCodeCoverage]
    public class ScheduledTaskTrackerTests
    {
        [Fact]
        public void Constructor_ShouldUseSystemClock_WhenClockIsNull()
        {
            var tracker = new ScheduledTaskTracker(null);

            tracker.RegisterExecution("test");

            Assert.True(tracker.HasExecuted("test"));
        }

        [Fact]
        public void Constructor_ShouldUseFakeClock_WhenProvided()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new ScheduledTaskTracker(clock);

            tracker.RegisterExecution("test");
            clock.Advance(TimeSpan.FromHours(1));

            var timeSince = tracker.TimeSinceLastExecution("test");

            Assert.Equal(TimeSpan.FromHours(1), timeSince);
        }

        [Fact]
        public void RegisterExecution_ShouldThrowArgumentException_WhenTaskNameIsNull()
        {
            var tracker = new ScheduledTaskTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.RegisterExecution(null!));
        }

        [Fact]
        public void RegisterExecution_ShouldThrowArgumentException_WhenTaskNameIsEmpty()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.RegisterExecution(string.Empty));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void RegisterExecution_ShouldThrowArgumentException_WhenTaskNameIsWhitespace()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.RegisterExecution("   "));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void RegisterExecution_ShouldRecordExecution()
        {
            var tracker = new ScheduledTaskTracker();

            tracker.RegisterExecution("task1");

            Assert.True(tracker.HasExecuted("task1"));
        }

        [Fact]
        public void RegisterExecution_ShouldUpdateExistingTask()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new ScheduledTaskTracker(clock);

            tracker.RegisterExecution("task1");
            clock.Advance(TimeSpan.FromHours(1));
            tracker.RegisterExecution("task1");

            var timeSince = tracker.TimeSinceLastExecution("task1");

            Assert.True(timeSince < TimeSpan.FromMinutes(1));
        }

        [Fact]
        public void RegisterExecution_ShouldBeCaseInsensitive()
        {
            var tracker = new ScheduledTaskTracker();

            tracker.RegisterExecution("Task1");

            Assert.True(tracker.HasExecuted("task1"));
            Assert.True(tracker.HasExecuted("TASK1"));
        }

        [Fact]
        public void HasExecuted_ShouldThrowArgumentException_WhenTaskNameIsNull()
        {
            var tracker = new ScheduledTaskTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.HasExecuted(null!));
        }

        [Fact]
        public void HasExecuted_ShouldThrowArgumentException_WhenTaskNameIsEmpty()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.HasExecuted(string.Empty));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void HasExecuted_ShouldThrowArgumentException_WhenTaskNameIsWhitespace()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.HasExecuted("   "));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void HasExecuted_ShouldReturnFalse_WhenTaskNotRegistered()
        {
            var tracker = new ScheduledTaskTracker();

            Assert.False(tracker.HasExecuted("nonexistent"));
        }

        [Fact]
        public void HasExecuted_ShouldReturnTrue_WhenTaskRegistered()
        {
            var tracker = new ScheduledTaskTracker();

            tracker.RegisterExecution("task1");

            Assert.True(tracker.HasExecuted("task1"));
        }

        [Fact]
        public void TimeSinceLastExecution_ShouldThrowArgumentException_WhenTaskNameIsNull()
        {
            var tracker = new ScheduledTaskTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.TimeSinceLastExecution(null!));
        }

        [Fact]
        public void TimeSinceLastExecution_ShouldThrowArgumentException_WhenTaskNameIsEmpty()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.TimeSinceLastExecution(string.Empty));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void TimeSinceLastExecution_ShouldThrowArgumentException_WhenTaskNameIsWhitespace()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.TimeSinceLastExecution("   "));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void TimeSinceLastExecution_ShouldReturnZero_WhenTaskNotRegistered()
        {
            var tracker = new ScheduledTaskTracker();

            var timeSince = tracker.TimeSinceLastExecution("nonexistent");

            Assert.Equal(TimeSpan.Zero, timeSince);
        }

        [Fact]
        public void TimeSinceLastExecution_ShouldReturnCorrectTimeSpan()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new ScheduledTaskTracker(clock);

            tracker.RegisterExecution("task1");
            clock.Advance(TimeSpan.FromHours(2));

            var timeSince = tracker.TimeSinceLastExecution("task1");

            Assert.Equal(TimeSpan.FromHours(2), timeSince);
        }

        [Fact]
        public void ShouldRun_ShouldThrowArgumentException_WhenTaskNameIsNull()
        {
            var tracker = new ScheduledTaskTracker();

            Assert.Throws<ArgumentNullException>(() =>
                tracker.ShouldRun(null!, TimeSpan.FromHours(1)));
        }

        [Fact]
        public void ShouldRun_ShouldThrowArgumentException_WhenTaskNameIsEmpty()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.ShouldRun(string.Empty, TimeSpan.FromHours(1)));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void ShouldRun_ShouldThrowArgumentException_WhenTaskNameIsWhitespace()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentException>(() =>
                tracker.ShouldRun("   ", TimeSpan.FromHours(1)));

            Assert.Equal("taskName", exception.ParamName);
        }

        [Fact]
        public void ShouldRun_ShouldThrowArgumentOutOfRangeException_WhenIntervalIsNegative()
        {
            var tracker = new ScheduledTaskTracker();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                tracker.ShouldRun("task1", TimeSpan.FromHours(-1)));

            Assert.Equal("interval", exception.ParamName);
        }

        [Fact]
        public void ShouldRun_ShouldReturnTrue_WhenTaskNeverExecuted()
        {
            var tracker = new ScheduledTaskTracker();

            Assert.True(tracker.ShouldRun("task1", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void ShouldRun_ShouldReturnFalse_WhenIntervalNotElapsed()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new ScheduledTaskTracker(clock);

            tracker.RegisterExecution("task1");
            clock.Advance(TimeSpan.FromMinutes(30));

            Assert.False(tracker.ShouldRun("task1", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void ShouldRun_ShouldReturnTrue_WhenIntervalElapsed()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new ScheduledTaskTracker(clock);

            tracker.RegisterExecution("task1");
            clock.Advance(TimeSpan.FromHours(1));

            Assert.True(tracker.ShouldRun("task1", TimeSpan.FromHours(1)));
        }

        [Fact]
        public void ShouldRun_ShouldReturnTrue_WhenIntervalExceeded()
        {
            var clock = new FakeClock(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var tracker = new ScheduledTaskTracker(clock);

            tracker.RegisterExecution("task1");
            clock.Advance(TimeSpan.FromHours(2));

            Assert.True(tracker.ShouldRun("task1", TimeSpan.FromHours(1)));
        }
    }
}
