using Microsoft.Extensions.Logging;

using StruttonTechnologies.Core.ToolKit.Logging.Helpers;
using StruttonTechnologies.Core.ToolKit.Logging.Services;
using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Logging.Extensions
{
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

            return logger.BeginScope(LogScopeBuilder.Create(
                (LogScopeKeys.OperationName, operationName),
                (LogScopeKeys.OperationId, Guid.NewGuid().ToString("N"))));
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

            return logger.BeginScope(LogScopeBuilder.Create(
                (LogScopeKeys.CorrelationId, correlationId)));
        }

        /// <summary>
        /// Begins a correlation scope using the registered accessor.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="correlationIdAccessor">The correlation accessor.</param>
        /// <returns>An active logging scope.</returns>
        public static IDisposable? BeginCorrelationScope(this ILogger logger, ICorrelationIdAccessor correlationIdAccessor)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(correlationIdAccessor);

            return logger.BeginCorrelationScope(correlationIdAccessor.GetOrCreate());
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

            return logger.BeginScope(LogScopeBuilder.Create(
                (LogScopeKeys.EntityName, entityName),
                (LogScopeKeys.EntityId, entityId)));
        }

        /// <summary>
        /// Begins a request scope.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns>An active logging scope.</returns>
        public static IDisposable? BeginRequestScope(this ILogger logger, string requestId, string? correlationId = null)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentException.ThrowIfNullOrWhiteSpace(requestId);

            return logger.BeginScope(LogScopeBuilder.Create(
                (LogScopeKeys.RequestId, requestId),
                (LogScopeKeys.CorrelationId, correlationId)));
        }

        /// <summary>
        /// Begins an environment scope.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="environmentName">The environment name.</param>
        /// <returns>An active logging scope.</returns>
        public static IDisposable? BeginEnvironmentScope(this ILogger logger, string environmentName)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentException.ThrowIfNullOrWhiteSpace(environmentName);

            return logger.BeginScope(LogScopeBuilder.Create(
                (LogScopeKeys.EnvironmentName, environmentName),
                (LogScopeKeys.MachineName, Environment.MachineName)));
        }
    }
}
