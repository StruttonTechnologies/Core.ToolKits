using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.TestingKit.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public class TestingKitServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddTestingKit_ShouldThrowArgumentNullException_WhenServicesIsNull()
        {
            IServiceCollection services = null!;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                services.AddTestingKit());

            Assert.Equal("services", exception.ParamName);
        }

        [Fact]
        public void AddTestingKit_ShouldReturnSameInstance()
        {
            var services = new ServiceCollection();

            var result = services.AddTestingKit();

            Assert.Same(services, result);
        }
    }
}
