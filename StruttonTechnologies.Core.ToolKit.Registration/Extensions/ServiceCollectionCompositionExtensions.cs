using Microsoft.Extensions.DependencyInjection;

using StruttonTechnologies.Core.ToolKit.Registration.Models;
using StruttonTechnologies.Core.ToolKit.Registration.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Registration.Extensions
{
    /// <summary>
    /// Provides extension methods for composing service collections.
    /// </summary>
    public static class ServiceCollectionCompositionExtensions
    {
        /// <summary>
        /// Composes service descriptors from a source collection into the target collection
        /// using the specified composition options.
        /// </summary>
        /// <param name="target">The target service collection.</param>
        /// <param name="source">The source service collection.</param>
        /// <param name="options">The service composition options.</param>
        /// <returns>The target service collection.</returns>
        public static IServiceCollection ComposeServicesFrom(
            this IServiceCollection target,
            IServiceCollection source,
            ServiceCompositionOptions options)
        {
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(options);

            return ServiceCollectionComposer.Compose(target, source, options);
        }

        /// <summary>
        /// Composes service descriptors from multiple source collections into the target collection
        /// using the default composition options.
        /// </summary>
        /// <param name="target">The target service collection.</param>
        /// <param name="sources">The source service collections.</param>
        /// <returns>The target service collection.</returns>
        public static IServiceCollection ComposeServicesFrom(
            this IServiceCollection target,
            params IServiceCollection[] sources)
        {
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(sources);

            foreach (IServiceCollection source in sources)
            {
                ArgumentNullException.ThrowIfNull(source);

                target.ComposeServicesFrom(
                    source,
                    new ServiceCompositionOptions());
            }

            return target;
        }
    }
}
