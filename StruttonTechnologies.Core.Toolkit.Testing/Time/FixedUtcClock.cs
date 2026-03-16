using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Time
{
    /// <summary>
    /// Represents a clock that always returns the same UTC date and time.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class FixedUtcClock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedUtcClock"/> class.
        /// </summary>
        /// <param name="utcNow">
        /// The fixed UTC date and time value.
        /// </param>
        public FixedUtcClock(DateTime utcNow)
        {
            this.UtcNow = utcNow.Kind == DateTimeKind.Utc
                ? utcNow
                : DateTime.SpecifyKind(utcNow, DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets the fixed UTC date and time value.
        /// </summary>
        public DateTime UtcNow { get; }
    }
}
