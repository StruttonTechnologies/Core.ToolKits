using System.Diagnostics.CodeAnalysis;

using StruttonTechnologies.Core.ToolKit.Registration.Extensions;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Extensions
{
    /// <summary>
    /// Contains test scenarios for composing services from multiple source collections.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ComposeServicesFromMultipleSourcesTests
    {
        [Fact]
        public void ComposeServicesFrom_WhenCalledWithMultipleSources_ReturnsTargetCollection()
        {
            ServiceCollection target = new();
            ServiceCollection firstSource = new();
            ServiceCollection secondSource = new();

            firstSource.AddTransient<ISampleService, SampleService>();
            secondSource.AddTransient<ISecondaryService, SecondaryService>();

            IServiceCollection result = target.ComposeServicesFrom(firstSource, secondSource);

            Assert.Same(target, result);
        }

        [Fact]
        public void ComposeServicesFrom_WhenTargetIsNull_ThrowsArgumentNullException()
        {
            IServiceCollection? target = null;
            ServiceCollection source = new();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                target!.ComposeServicesFrom(source));

            Assert.Equal("target", exception.ParamName);
        }

        [Fact]
        public void ComposeServicesFrom_WhenSourcesAreNull_ThrowsArgumentNullException()
        {
            ServiceCollection target = new();
            IServiceCollection[]? sources = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                target.ComposeServicesFrom(sources!));

            Assert.Equal("sources", exception.ParamName);
        }

        private interface ISampleService;
        private sealed class SampleService : ISampleService;

        private interface ISecondaryService;
        private sealed class SecondaryService : ISecondaryService;
    }
}
