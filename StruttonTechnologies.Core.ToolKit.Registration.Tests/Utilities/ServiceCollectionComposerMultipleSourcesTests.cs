using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains multiple-source composition test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerMultipleSourcesTests
    {
        /// <summary>
        /// Verifies that composing multiple sources adds descriptors from each source collection.
        /// </summary>
        [Fact]
        public void Compose_WithMultipleSources_AddsDescriptorsFromAllSources()
        {
            ServiceCollection target = new();

            ServiceCollection firstSource = new();
            firstSource.AddTransient<ISampleService, SampleService>();

            ServiceCollection secondSource = new();
            secondSource.AddSingleton<ISecondaryService, SecondaryService>();

            ServiceCollectionComposer.Compose(target, null, firstSource, secondSource);

            Assert.Equal(2, target.Count);
            Assert.Contains(target, descriptor => descriptor.ServiceType == typeof(ISampleService));
            Assert.Contains(target, descriptor => descriptor.ServiceType == typeof(ISecondaryService));
        }

        /// <summary>
        /// Verifies that composing multiple sources throws when the target is null.
        /// </summary>
        [Fact]
        public void Compose_WithMultipleSources_WhenTargetIsNull_ThrowsArgumentNullException()
        {
            IServiceCollection? target = null;
            ServiceCollection source = new();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ServiceCollectionComposer.Compose(target!, null, source));

            Assert.Equal("target", exception.ParamName);
        }

        /// <summary>
        /// Verifies that composing multiple sources throws when the sources array is null.
        /// </summary>
        [Fact]
        public void Compose_WithMultipleSources_WhenSourcesAreNull_ThrowsArgumentNullException()
        {
            ServiceCollection target = new();
            IServiceCollection[]? sources = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ServiceCollectionComposer.Compose(target, null, sources!));

            Assert.Equal("sources", exception.ParamName);
        }
    }
}
