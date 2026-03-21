using Microsoft.Extensions.DependencyInjection;

using StruttonTechnologies.Core.ToolKit.Validation.Validators.Common;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Composite;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Format;

namespace StruttonTechnologies.Core.ToolKit.Validation.DependencyInjection;

/// <summary>
/// Provides dependency injection registration methods for Validation.
/// </summary>
public static class ValidationServiceCollectionExtensions
{
    /// <summary>
    /// Registers Validation services.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="services"/> is <see langword="null"/>.
    /// </exception>
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddValidationCommonValidators()
            .AddValidationFormatValidators()
            .AddValidationCompositeValidators();

        return services;
    }

    /// <summary>
    /// Registers common reusable validators.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    private static IServiceCollection AddValidationCommonValidators(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // Open generic validators
        services.AddTransient(typeof(NotDefaultValidator<>));
        services.AddTransient(typeof(IdValidator<>));

        return services;
    }

    /// <summary>
    /// Registers format validators that can be constructed without external runtime data.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    private static IServiceCollection AddValidationFormatValidators(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient<EmailFormatValidator>();
        services.AddTransient<PhoneNumberFormatValidator>();
        services.AddTransient<UsZipCodeFormatValidator>();

        // Intentionally not registering RegexValidator here because it typically
        // requires a pattern and optional custom message supplied by the consumer.

        return services;
    }

    /// <summary>
    /// Registers composite validators.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    private static IServiceCollection AddValidationCompositeValidators(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient(typeof(CompositeValidator<>));

        return services;
    }
}
