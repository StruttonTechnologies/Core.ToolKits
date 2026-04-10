using Microsoft.Extensions.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.Logging.Services
{
    /// <summary>
    /// Provides service registration helpers for toolkit logging services.
    /// </summary>
    public static class LoggingServiceCollectionExtensions
    {
        /// <summary>
        /// Registers toolkit logging services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddToolkitLogging(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddSingleton<ICorrelationIdAccessor, CorrelationIdAccessor>();
            return services;
        }
    }
}
