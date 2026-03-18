using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Time
{
    /// <summary>
    /// Represents a clock that always returns the same local date and time.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class FixedClock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedClock"/> class.
        /// </summary>
        /// <param name="now">
        /// The fixed local date and time value.
        /// </param>
        public FixedClock(DateTime now)
        {
            this.Now = now;
        }

        /// <summary>
        /// Gets the fixed local date and time value.
        /// </summary>
        public DateTime Now { get; }
    }
}
