using Microsoft.Extensions.DependencyInjection;

using StruttonTechnologies.Core.ToolKit.Time.Abstractions;
using StruttonTechnologies.Core.ToolKit.Time.Clocks;
using StruttonTechnologies.Core.ToolKit.Time.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Time.DependencyInjection;

/// <summary>
/// Provides dependency injection registration methods for the Time toolkit.
/// </summary>
public static class TimeServiceCollectionExtensions
{
    /// <summary>
    /// Registers runtime services provided by the Time toolkit.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="services"/> is <see langword="null"/>.
    /// </exception>
    public static IServiceCollection AddTimeToolkit(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IClock>(_ => SystemClock.Instance);
        services.AddTransient<BusinessDayCalculator>();
        services.AddTransient<ScheduledTaskTracker>();
        services.AddTransient<TimeStateTracker>();

        return services;
    }
}
