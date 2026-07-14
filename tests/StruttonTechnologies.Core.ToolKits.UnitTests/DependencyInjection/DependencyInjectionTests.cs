using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Composition;
using StruttonTechnologies.Core.ToolKit.GuardKit.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Logging.Services;
using StruttonTechnologies.Core.ToolKit.Time.Utilities;
using StruttonTechnologies.Core.ToolKit.Time.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Time.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Format;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.DependencyInjection;

public sealed class DependencyInjectionTests
{
    [Fact]
    public void AddGuardKit_ReturnsSameCollection()
    {
        var services = new ServiceCollection();

        var result = services.AddGuardKit();

        Assert.Same(services, result);
    }

    [Fact]
    public void AddValidation_RegistersExpectedValidators()
    {
        var services = new ServiceCollection();

        services.AddValidation();
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<EmailFormatValidator>());
        Assert.NotNull(provider.GetService<PhoneNumberFormatValidator>());
        Assert.NotNull(provider.GetService<UsZipCodeFormatValidator>());
    }

    [Fact]
    public void AddToolkitLogging_RegistersCorrelationAccessor()
    {
        var services = new ServiceCollection();

        services.AddToolkitLogging();
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<ICorrelationIdAccessor>());
    }


    [Fact]
    public void AddTimeToolkit_RegistersExpectedTimeServices()
    {
        var services = new ServiceCollection();

        services.AddTimeToolkit();
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<IClock>());
        Assert.NotNull(provider.GetService<BusinessDayCalculator>());
        Assert.NotNull(provider.GetService<ScheduledTaskTracker>());
        Assert.NotNull(provider.GetService<TimeStateTracker>());
    }

    [Fact]
    public void AddStruttonTechnologiesToolKit_RegistersToolkitServices()
    {
        var services = new ServiceCollection();
        IConfiguration configuration = new ConfigurationBuilder().Build();

        services.AddStruttonTechnologiesToolKit(configuration);
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<ICorrelationIdAccessor>());
        Assert.NotNull(provider.GetService<EmailFormatValidator>());
        Assert.NotNull(provider.GetService<IClock>());
    }
}
