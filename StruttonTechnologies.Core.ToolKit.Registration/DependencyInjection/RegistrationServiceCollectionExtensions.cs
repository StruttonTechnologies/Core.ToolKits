using Microsoft.Extensions.DependencyInjection;

using StruttonTechnologies.Core.ToolKit.Registration.Models;
using StruttonTechnologies.Core.ToolKit.Registration.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Registration.DependencyInjection
{
    /// <summary>
    /// Provides dependency injection registration methods for Registration.
    /// </summary>
    public static class RegistrationServiceCollectionExtensions
    {
        /// <summary>
        /// Registers Registration services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="services"/> is <see langword="null"/>.
        /// </exception>
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            // Registration currently provides composition utilities and does not
            // require runtime service registrations.

            return services;
        }

        /// <summary>
        /// Composes service descriptors from a source collection into the target collection
        /// using the default composition options.
        /// </summary>
        /// <param name="target">The target service collection.</param>
        /// <param name="source">The source service collection.</param>
        /// <returns>The target service collection.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="target"/> or <paramref name="source"/> is <see langword="null"/>.
        /// </exception>
        public static IServiceCollection ComposeFrom(
            this IServiceCollection target,
            IServiceCollection source)
        {
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(source);

            return ServiceCollectionComposer.Compose(
                target,
                source,
                new ServiceCompositionOptions());
        }

        /// <summary>
        /// Composes service descriptors from a source collection into the target collection
        /// using the specified composition options.
        /// </summary>
        /// <param name="target">The target service collection.</param>
        /// <param name="source">The source service collection.</param>
        /// <param name="options">The composition options.</param>
        /// <returns>The target service collection.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="target"/>, <paramref name="source"/>, or <paramref name="options"/> is <see langword="null"/>.
        /// </exception>
        public static IServiceCollection ComposeFrom(
            this IServiceCollection target,
            IServiceCollection source,
            ServiceCompositionOptions options)
        {
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(options);

            return ServiceCollectionComposer.Compose(target, source, options);
        }
    }
}
