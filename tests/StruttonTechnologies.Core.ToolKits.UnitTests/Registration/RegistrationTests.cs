using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.Models;
using StruttonTechnologies.Core.ToolKit.Registration.Utilities;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Registration;

public sealed class RegistrationTests
{
    [Fact]
    public void AddRegistration_ReturnsSameServiceCollection()
    {
        var services = new ServiceCollection();

        var result = services.AddRegistration();

        Assert.Same(services, result);
    }

    [Fact]
    public void ServiceCompositionOptions_DefaultsToTryAddBehavior()
    {
        var options = new ServiceCompositionOptions();

        Assert.Equal(ServiceCompositionBehavior.TryAdd, options.Behavior);
    }

    [Fact]
    public void ServiceCollectionComposer_AddsServiceDescriptor()
    {
        var services = new ServiceCollection();
        var composer = new ServiceCollectionComposer(services);

        composer.AddSingleton<ITestService, TestService>();

        Assert.Contains(services, d => d.ServiceType == typeof(ITestService) && d.ImplementationType == typeof(TestService));
    }

    private interface ITestService;
    private sealed class TestService : ITestService;
}
