using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Diagnostics
{
    /// <summary>
    /// Provides shared exception logging messages.
    /// </summary>
    public static partial class ExceptionLogs
    {
        /// <summary>
        /// Logs an exception with a supplied context.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The exception context.</param>
        /// <param name="exception">The exception being logged.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.ExceptionLogged,
            Level = LogLevel.Error,
            Message = "An exception occurred during '{context}'.")]
        public static partial void ExceptionOccurred(ILogger logger, string context, Exception exception);
    }
}
