using Microsoft.Extensions.Logging;

namespace StruttonTechnologies.Core.ToolKit.Logging.Extensions;

/// <summary>
/// Provides convenience methods for creating loggers from shared categories.
/// </summary>
public static class LoggerFactoryExtensions
{
    /// <summary>
    /// Creates a logger for the supplied category name.
    /// </summary>
    /// <param name="loggerFactory">The logger factory.</param>
    /// <param name="categoryName">The category name.</param>
    /// <returns>A configured logger.</returns>
    public static ILogger CreateToolkitLogger(this ILoggerFactory loggerFactory, string categoryName)
    {
        ArgumentNullException.ThrowIfNull(loggerFactory);
        ArgumentException.ThrowIfNullOrWhiteSpace(categoryName);

        return loggerFactory.CreateLogger(categoryName);
    }
}
