using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Startup;

/// <summary>
/// Provides logging methods for application startup guards.
/// </summary>
public static partial class StartupGuardLogs
{
    /// <summary>
    /// Logs that a required connection string is missing.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="connectionStringName">The missing connection string name.</param>
    [LoggerMessage(
        EventId = LoggingEventIds.StartupMinimum,
        Level = LogLevel.Critical,
        Message = "Missing connection string: '{connectionStringName}'. App cannot start safely.")]
    public static partial void MissingConnectionString(ILogger logger, string connectionStringName);

    /// <summary>
    /// Logs that a required connection string has been found.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="connectionStringName">The discovered connection string name.</param>
    [LoggerMessage(
        EventId = LoggingEventIds.StartupMinimum + 1,
        Level = LogLevel.Information,
        Message = "Configuration check passed: '{connectionStringName}' found.")]
    public static partial void ConnectionStringFound(ILogger logger, string connectionStringName);
}
