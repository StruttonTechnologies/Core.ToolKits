using Microsoft.Extensions.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.Guardkit
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGuardKit(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            // register internal services
            return services;
        }
    }
}
