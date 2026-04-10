using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Diagnostics
{
    /// <summary>
    /// Provides correlation and operation diagnostic log messages.
    /// </summary>
    public static partial class CorrelationDiagnosticLogs
    {
        /// <summary>
        /// Logs assignment of a correlation identifier.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.CorrelationAssigned,
            Level = LogLevel.Debug,
            Message = "Assigned correlation identifier '{correlationId}'.")]
        public static partial void CorrelationAssigned(ILogger logger, string correlationId);

        /// <summary>
        /// Logs the start of an operation.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="operationName">The operation name.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.OperationStarted,
            Level = LogLevel.Debug,
            Message = "Started operation '{operationName}'.")]
        public static partial void OperationStarted(ILogger logger, string operationName);

        /// <summary>
        /// Logs the completion of an operation.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="operationName">The operation name.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.OperationCompleted,
            Level = LogLevel.Debug,
            Message = "Completed operation '{operationName}'.")]
        public static partial void OperationCompleted(ILogger logger, string operationName);
    }
}
