using StruttonTechnologies.Core.ToolKits.Time.Abstractions;
using StruttonTechnologies.Core.ToolKits.Time.Clocks;

namespace StruttonTechnologies.Core.ToolKits.Time.Utilities
{
    /// <summary>
    /// Tracks state timestamps to support expiry and cooldown logic.
    /// </summary>
    public sealed class TimeStateTracker
    {
        private readonly Dictionary<string, DateTime> _stateTimestamps = new(StringComparer.OrdinalIgnoreCase);
        private readonly IClock _clock;

        public TimeStateTracker(IClock? clock = null)
        {
            _clock = clock ?? SystemClock.Instance;
        }

        public void Touch(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            _stateTimestamps[key] = _clock.UtcNow;
        }

        public bool Exists(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return _stateTimestamps.ContainsKey(key);
        }

        public bool HasExpired(string key, TimeSpan expiration)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);

            if (expiration < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(expiration));
            }

            return !Exists(key) || (_clock.UtcNow - _stateTimestamps[key]) >= expiration;
        }

        public TimeSpan Age(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);

            return _stateTimestamps.TryGetValue(key, out var timestamp)
                ? _clock.UtcNow - timestamp
                : TimeSpan.Zero;
        }
    }
}
