using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Extensions;

/// <summary>
/// Provides reusable scope helpers for structured logging.
/// </summary>
public static class LoggerExtensions
{
    /// <summary>
    /// Begins an operation scope.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="operationName">The operation name.</param>
    /// <returns>An active logging scope.</returns>
    public static IDisposable? BeginOperationScope(this ILogger logger, string operationName)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentException.ThrowIfNullOrWhiteSpace(operationName);

        return logger.BeginScope(new Dictionary<string, object?>
        {
            [LogScopeKeys.OperationName] = operationName,
        });
    }

    /// <summary>
    /// Begins a correlation scope.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="correlationId">The correlation identifier.</param>
    /// <returns>An active logging scope.</returns>
    public static IDisposable? BeginCorrelationScope(this ILogger logger, string correlationId)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentException.ThrowIfNullOrWhiteSpace(correlationId);

        return logger.BeginScope(new Dictionary<string, object?>
        {
            [LogScopeKeys.CorrelationId] = correlationId,
        });
    }

    /// <summary>
    /// Begins an entity scope.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="entityName">The entity name.</param>
    /// <param name="entityId">The entity identifier.</param>
    /// <returns>An active logging scope.</returns>
    public static IDisposable? BeginEntityScope(this ILogger logger, string entityName, object entityId)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentException.ThrowIfNullOrWhiteSpace(entityName);
        ArgumentNullException.ThrowIfNull(entityId);

        return logger.BeginScope(new Dictionary<string, object?>
        {
            [LogScopeKeys.EntityName] = entityName,
            [LogScopeKeys.EntityId] = entityId,
        });
    }
}
