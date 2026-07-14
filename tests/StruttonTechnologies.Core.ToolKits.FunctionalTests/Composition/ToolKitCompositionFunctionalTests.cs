using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Composition;
using StruttonTechnologies.Core.ToolKit.Logging.Services;
using StruttonTechnologies.Core.ToolKit.Time.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Format;

namespace StruttonTechnologies.Core.ToolKits.FunctionalTests.Composition;

public sealed class ToolKitCompositionFunctionalTests
{
    [Fact]
    public void AddStruttonTechnologiesToolKit_ComposesMultipleToolkitPackages()
    {
        var services = new ServiceCollection();
        IConfiguration configuration = new ConfigurationBuilder().Build();

        services.AddStruttonTechnologiesToolKit(configuration);
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetRequiredService<ICorrelationIdAccessor>());
        Assert.NotNull(provider.GetRequiredService<EmailFormatValidator>());
        Assert.NotNull(provider.GetRequiredService<IClock>());
    }
}
