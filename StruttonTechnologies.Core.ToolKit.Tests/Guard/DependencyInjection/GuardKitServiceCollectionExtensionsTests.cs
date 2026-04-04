using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.GuardKit.DependencyInjection;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public class GuardKitServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddGuardKit_ShouldThrowArgumentNullException_WhenServicesIsNull()
        {
            IServiceCollection? services = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                services!.AddGuardKit());

            Assert.Equal("services", exception.ParamName);
        }

        [Fact]
        public void AddGuardKit_ShouldReturnServiceCollection_WhenCalled()
        {
            var services = new ServiceCollection();

            var result = services.AddGuardKit();

            Assert.Same(services, result);
        }

        [Fact]
        public void AddGuardKit_ShouldNotAddAnyServices_WhenCalled()
        {
            var services = new ServiceCollection();
            var initialCount = services.Count;

            services.AddGuardKit();

            Assert.Equal(initialCount, services.Count);
        }
    }
}
