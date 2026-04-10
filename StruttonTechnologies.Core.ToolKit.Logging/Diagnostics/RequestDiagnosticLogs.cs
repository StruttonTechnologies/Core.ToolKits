using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Diagnostics
{
    /// <summary>
    /// Provides common request diagnostic log messages.
    /// </summary>
    public static partial class RequestDiagnosticLogs
    {
        /// <summary>
        /// Logs request processing start.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="requestName">The request name.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.ProcessingRequest,
            Level = LogLevel.Debug,
            Message = "Processing request '{requestName}'.")]
        public static partial void ProcessingRequest(ILogger logger, string requestName);

        /// <summary>
        /// Logs request processing completion.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="requestName">The request name.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.CompletedRequest,
            Level = LogLevel.Debug,
            Message = "Completed request '{requestName}'.")]
        public static partial void CompletedRequest(ILogger logger, string requestName);
    }
}
