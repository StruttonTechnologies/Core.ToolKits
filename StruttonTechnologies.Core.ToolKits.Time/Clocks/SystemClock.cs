using StruttonTechnologies.Core.ToolKit.Time.Abstractions;

namespace StruttonTechnologies.Core.ToolKit.Time.Clocks
{
    /// <summary>
    /// Production clock implementation.
    /// </summary>
    public sealed class SystemClock : IClock
    {
        public static SystemClock Instance { get; } = new();

        private SystemClock()
        {
        }

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
