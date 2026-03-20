namespace StruttonTechnologies.Core.ToolKit.Validation.DependencyInjection;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;

/// <summary>
/// Provides dependency injection registration helpers for validators.
/// </summary>
public static class ValidationServiceCollectionExtensions
{
    /// <summary>
    /// Registers discovered validator implementations from the supplied assemblies.
    /// </summary>
    /// <param name="services">The service collection to update.</param>
    /// <param name="assembliesToScan">The assemblies to scan for validator implementations.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> is null.</exception>
    public static IServiceCollection AddValidators(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        ArgumentNullException.ThrowIfNull(services);

        var assemblies = assembliesToScan is { Length: > 0 }
            ? assembliesToScan
            : new[] { Assembly.GetExecutingAssembly() };

        foreach (var assembly in assemblies)
        {
            foreach (var implementationType in GetLoadableTypes(assembly).Where(IsConcreteValidatorType))
            {
                var validatorInterfaces = implementationType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));

                foreach (var validatorInterface in validatorInterfaces)
                {
                    services.AddScoped(validatorInterface, implementationType);
                }
            }
        }

        return services;
    }

    /// <summary>
    /// Returns all loadable types from the specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to inspect.</param>
    /// <returns>A sequence of loadable <see cref="Type"/> instances.</returns>
    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types.Where(type => type is not null)!;
        }
    }

    /// <summary>
    /// Determines whether the specified type is a concrete validator implementation.
    /// </summary>
    /// <param name="type">The type to evaluate.</param>
    /// <returns><see langword="true"/> when the type is a concrete validator; otherwise, <see langword="false"/>.</returns>
    private static bool IsConcreteValidatorType(Type type)
        => type is { IsClass: true, IsAbstract: false }
            && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));
}
