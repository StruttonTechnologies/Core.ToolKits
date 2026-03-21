using Microsoft.Extensions.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.DependencyInjection
{
    /// <summary>
    /// Provides dependency injection registration methods for TestingKit.
    /// </summary>
    public static class TestingKitServiceCollectionExtensions
    {
        /// <summary>
        /// Registers TestingKit services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="services"/> is <see langword="null"/>.
        /// </exception>
        public static IServiceCollection AddTestingKit(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            // TestingKit currently provides reusable testing helpers and does not
            // require runtime service registrations.

            return services;
        }
    }
}
