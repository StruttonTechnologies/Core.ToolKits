using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Validation
{
    /// <summary>
    /// Provides common validation log messages.
    /// </summary>
    public static partial class ValidationLogs
    {
        /// <summary>
        /// Logs validation failure for a target.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="targetName">The target name.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.ValidationFailed,
            Level = LogLevel.Warning,
            Message = "Validation failed for '{targetName}'.")]
        public static partial void ValidationFailed(ILogger logger, string targetName);

        /// <summary>
        /// Logs successful validation for a target.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="targetName">The target name.</param>
        [LoggerMessage(
            EventId = LoggingEventIds.ValidationPassed,
            Level = LogLevel.Debug,
            Message = "Validation passed for '{targetName}'.")]
        public static partial void ValidationPassed(ILogger logger, string targetName);
    }
}
