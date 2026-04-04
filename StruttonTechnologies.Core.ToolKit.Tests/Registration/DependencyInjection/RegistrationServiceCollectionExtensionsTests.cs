using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Registration.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public class RegistrationServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddRegistration_ShouldThrowArgumentNullException_WhenServicesIsNull()
        {
            IServiceCollection services = null!;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                services.AddRegistration());

            Assert.Equal("services", exception.ParamName);
        }

        [Fact]
        public void AddRegistration_ShouldReturnSameInstance()
        {
            var services = new ServiceCollection();

            var result = services.AddRegistration();

            Assert.Same(services, result);
        }

        [Fact]
        public void ComposeFrom_WithDefaultOptions_ShouldThrowArgumentNullException_WhenTargetIsNull()
        {
            IServiceCollection target = null!;
            var source = new ServiceCollection();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                target.ComposeFrom(source));

            Assert.Equal("target", exception.ParamName);
        }

        [Fact]
        public void ComposeFrom_WithDefaultOptions_ShouldThrowArgumentNullException_WhenSourceIsNull()
        {
            var target = new ServiceCollection();
            IServiceCollection source = null!;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                target.ComposeFrom(source));

            Assert.Equal("source", exception.ParamName);
        }

        [Fact]
        public void ComposeFrom_WithDefaultOptions_ShouldReturnTarget()
        {
            var target = new ServiceCollection();
            var source = new ServiceCollection();

            var result = target.ComposeFrom(source);

            Assert.Same(target, result);
        }

        [Fact]
        public void ComposeFrom_WithDefaultOptions_ShouldCopyServicesFromSourceToTarget()
        {
            var target = new ServiceCollection();
            var source = new ServiceCollection();
            source.AddSingleton<ITestService, TestService>();

            target.ComposeFrom(source);

            Assert.Single(target);
            Assert.Equal(typeof(ITestService), target[0].ServiceType);
        }

        [Fact]
        public void ComposeFrom_WithOptions_ShouldThrowArgumentNullException_WhenTargetIsNull()
        {
            IServiceCollection target = null!;
            var source = new ServiceCollection();
            var options = new ServiceCompositionOptions();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                target.ComposeFrom(source, options));

            Assert.Equal("target", exception.ParamName);
        }

        [Fact]
        public void ComposeFrom_WithOptions_ShouldThrowArgumentNullException_WhenSourceIsNull()
        {
            var target = new ServiceCollection();
            IServiceCollection source = null!;
            var options = new ServiceCompositionOptions();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                target.ComposeFrom(source, options));

            Assert.Equal("source", exception.ParamName);
        }

        [Fact]
        public void ComposeFrom_WithOptions_ShouldThrowArgumentNullException_WhenOptionsIsNull()
        {
            var target = new ServiceCollection();
            var source = new ServiceCollection();
            ServiceCompositionOptions options = null!;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                target.ComposeFrom(source, options));

            Assert.Equal("options", exception.ParamName);
        }

        [Fact]
        public void ComposeFrom_WithOptions_ShouldReturnTarget()
        {
            var target = new ServiceCollection();
            var source = new ServiceCollection();
            var options = new ServiceCompositionOptions();

            var result = target.ComposeFrom(source, options);

            Assert.Same(target, result);
        }

        [Fact]
        public void ComposeFrom_WithOptions_ShouldCopyServicesFromSourceToTarget()
        {
            var target = new ServiceCollection();
            var source = new ServiceCollection();
            source.AddSingleton<ITestService, TestService>();
            var options = new ServiceCompositionOptions();

            target.ComposeFrom(source, options);

            Assert.Single(target);
            Assert.Equal(typeof(ITestService), target[0].ServiceType);
        }

        private interface ITestService
        {
        }

        private class TestService : ITestService
        {
        }
    }
}
