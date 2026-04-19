using StruttonTechnologies.Core.ToolKit.Time.Abstractions;
using StruttonTechnologies.Core.ToolKit.Time.Clocks;

namespace StruttonTechnologies.Core.ToolKit.Time.Utilities
{
    /// <summary>
    /// Tracks last-run timestamps for lightweight scheduled operations.
    /// </summary>
    public sealed class ScheduledTaskTracker
    {
        private readonly Dictionary<string, DateTime> _taskHistory = new(StringComparer.OrdinalIgnoreCase);
        private readonly IClock _clock;

        public ScheduledTaskTracker(IClock? clock = null)
        {
            _clock = clock ?? SystemClock.Instance;
        }

        public void RegisterExecution(string taskName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(taskName);
            _taskHistory[taskName] = _clock.UtcNow;
        }

        public bool HasExecuted(string taskName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(taskName);
            return _taskHistory.ContainsKey(taskName);
        }

        public TimeSpan TimeSinceLastExecution(string taskName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(taskName);

            return _taskHistory.TryGetValue(taskName, out var lastExecution)
                ? _clock.UtcNow - lastExecution
                : TimeSpan.Zero;
        }

        public bool ShouldRun(string taskName, TimeSpan interval)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(taskName);

            if (interval < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(interval));
            }

            return !HasExecuted(taskName) || TimeSinceLastExecution(taskName) >= interval;
        }
    }
}
