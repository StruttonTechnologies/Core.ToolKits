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
    public void ServiceCompositionOptions_DefaultsToAppendBehavior()
    {
        var options = new ServiceCompositionOptions();

        Assert.Equal(ServiceCompositionBehavior.Append, options.Behavior);
    }

    [Fact]
    public void ServiceCollectionComposer_AppendsServiceDescriptor()
    {
        var target = new ServiceCollection();
        var source = new ServiceCollection();

        source.AddSingleton<ITestService, TestService>();

        ServiceCollectionComposer.Compose(target, source);

        Assert.Contains(target, d => d.ServiceType == typeof(ITestService) && d.ImplementationType == typeof(TestService));
    }

    private interface ITestService;
    private sealed class TestService : ITestService;
}
