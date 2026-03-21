using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StruttonTechnologies.Core.ToolKit.Registration.Utilities
{
    /// <summary>
    /// Provides helper methods for composing one or more <see cref="IServiceCollection"/> instances into a target collection.
    /// </summary>
    public static class ServiceCollectionComposer
    {
        /// <summary>
        /// Adds all service descriptors from the source collection into the target collection using the supplied options.
        /// </summary>
        /// <param name="target">The target <see cref="IServiceCollection"/> that receives the composed services.</param>
        /// <param name="source">The source <see cref="IServiceCollection"/> to compose into the target collection.</param>
        /// <param name="options">Optional composition settings. When omitted, descriptors are appended.</param>
        /// <returns>The target <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="target"/> or <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when <see cref="ServiceCompositionBehavior.ThrowIfServiceTypeExists"/> is selected and a matching service type
        /// already exists in the target collection.
        /// </exception>
        public static IServiceCollection Compose(
            IServiceCollection target,
            IServiceCollection source,
            ServiceCompositionOptions? options = null)
        {
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(source);

            ServiceCompositionOptions resolvedOptions = options ?? new ServiceCompositionOptions();

            foreach (ServiceDescriptor descriptor in source)
            {
                ApplyDescriptor(target, descriptor, resolvedOptions);
            }

            return target;
        }

        /// <summary>
        /// Adds all service descriptors from the supplied source collections into the target collection using the supplied options.
        /// </summary>
        /// <param name="target">The target <see cref="IServiceCollection"/> that receives the composed services.</param>
        /// <param name="options">Optional composition settings. When omitted, descriptors are appended.</param>
        /// <param name="sources">The source collections to compose into the target collection.</param>
        /// <returns>The target <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="target"/> or <paramref name="sources"/> is <see langword="null"/>.
        /// </exception>
        public static IServiceCollection Compose(
            IServiceCollection target,
            ServiceCompositionOptions? options,
            params IServiceCollection[] sources)
        {
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(sources);

            foreach (IServiceCollection source in sources)
            {
                Compose(target, source, options);
            }

            return target;
        }

        private static void ApplyDescriptor(
            IServiceCollection target,
            ServiceDescriptor descriptor,
            ServiceCompositionOptions options)
        {
            bool serviceTypeExists = target.Any(existing => existing.ServiceType == descriptor.ServiceType);

            switch (options.Behavior)
            {
                case ServiceCompositionBehavior.Append:
                    target.Add(descriptor);
                    options.Logger?.Invoke(CreateLogMessage("Appended", descriptor));
                    break;

                case ServiceCompositionBehavior.SkipExistingServiceType:
                    if (serviceTypeExists)
                    {
                        options.Logger?.Invoke(CreateLogMessage("Skipped existing service type", descriptor));
                        return;
                    }

                    target.Add(descriptor);
                    options.Logger?.Invoke(CreateLogMessage("Added", descriptor));
                    break;

                case ServiceCompositionBehavior.ReplaceExistingServiceType:
                    RemoveExistingServiceType(target, descriptor.ServiceType);
                    target.Add(descriptor);
                    options.Logger?.Invoke(CreateLogMessage("Replaced service type", descriptor));
                    break;

                case ServiceCompositionBehavior.ThrowIfServiceTypeExists:
                    if (serviceTypeExists)
                    {
                        throw new InvalidOperationException(
                            $"A registration already exists for service type '{descriptor.ServiceType.FullName}'.");
                    }

                    target.Add(descriptor);
                    options.Logger?.Invoke(CreateLogMessage("Added", descriptor));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(options.Behavior), options.Behavior, "Unsupported composition behavior.");
            }
        }

        private static void RemoveExistingServiceType(IServiceCollection target, Type serviceType)
        {
            List<ServiceDescriptor> existingDescriptors = target
                .Where(existing => existing.ServiceType == serviceType)
                .ToList();

            foreach (ServiceDescriptor existingDescriptor in existingDescriptors)
            {
                target.Remove(existingDescriptor);
            }
        }

        private static string CreateLogMessage(string action, ServiceDescriptor descriptor)
        {
            string implementation = descriptor.ImplementationType?.FullName
                ?? descriptor.ImplementationInstance?.GetType().FullName
                ?? descriptor.ImplementationFactory?.GetType().FullName
                ?? "UnknownImplementation";

            return $"{action}: {descriptor.ServiceType.FullName} -> {implementation} [{descriptor.Lifetime}]";
        }
    }
}
