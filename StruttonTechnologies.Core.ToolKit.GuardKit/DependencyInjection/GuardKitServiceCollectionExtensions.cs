using Microsoft.Extensions.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.GuardKit.DependencyInjection
{
    /// <summary>
    /// Provides dependency injection registration methods for GuardKit.
    /// </summary>
    public static class GuardKitServiceCollectionExtensions
    {
        /// <summary>
        /// Registers GuardKit services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddGuardKit(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            // No runtime services currently required

            return services;
        }
    }
}
