using Microsoft.Extensions.Logging;

namespace StruttonTechnologies.Core.ToolKit.Logging.Utilities
{
    /// <summary>
    /// Creates event identifiers with consistent naming.
    /// </summary>
    public static class LoggingEventId
    {
        /// <summary>
        /// Creates an event identifier.
        /// </summary>
        /// <param name="id">The numeric event identifier.</param>
        /// <param name="name">The event name.</param>
        /// <returns>A configured <see cref="EventId"/>.</returns>
        public static EventId Create(int id, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            return new EventId(id, name);
        }
    }
}
