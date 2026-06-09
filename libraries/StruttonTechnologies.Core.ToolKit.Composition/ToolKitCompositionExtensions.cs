using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using StruttonTechnologies.Core.ToolKit.GuardKit.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Logging.Services;
using StruttonTechnologies.Core.ToolKit.Registration.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.Composition;

/// <summary>
/// Public composition facade for Strutton Technologies ToolKit.
/// Consumers should call this method instead of registering individual toolkit packages directly.
/// </summary>
public static class ToolKitCompositionExtensions
{
    public static IServiceCollection AddStruttonTechnologiesToolKit(
        this IServiceCollection services,
        IConfiguration? configuration = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddGuardKit();
        services.AddToolkitLogging();
        services.AddRegistration();

        return services;
    }
}
