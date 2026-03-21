using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.Models;
using StruttonTechnologies.Core.ToolKit.Registration.Utilities;
using System;

namespace StruttonTechnologies.Core.ToolKit.Registration.Extensions
{
    /// <summary>
    /// Provides extension methods for composing service collections.
    /// </summary>
    public static class ServiceCollectionCompositionExtensions
    {
        /// <summary>
        /// Composes the descriptors from the source collection into the target collection.
        /// </summary>
        /// <param name="services">The target service collection.</param>
        /// <param name="source">The source service collection.</param>
        /// <param name="options">Optional composition settings. When omitted, descriptors are appended.</param>
        /// <returns>The target <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ComposeServicesFrom(
            this IServiceCollection services,
            IServiceCollection source,
            ServiceCompositionOptions? options = null)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(source);

            return ServiceCollectionComposer.Compose(services, source, options);
        }

        /// <summary>
        /// Composes the descriptors from the supplied source collections into the target collection.
        /// </summary>
        /// <param name="services">The target service collection.</param>
        /// <param name="options">Optional composition settings. When omitted, descriptors are appended.</param>
        /// <param name="sources">The source collections to compose into the target collection.</param>
        /// <returns>The target <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ComposeServicesFrom(
            this IServiceCollection services,
            ServiceCompositionOptions? options,
            params IServiceCollection[] sources)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(sources);

            return ServiceCollectionComposer.Compose(services, options, sources);
        }
    }
}
