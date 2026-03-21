using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Extensions
{
    /// <summary>
    /// Contains test scenarios for composing multiple source collections through extension methods.
    /// </summary>
    public sealed class ComposeServicesFromMultipleSourcesTests
    {
        /// <summary>
        /// Verifies that the extension method returns the original target collection.
        /// </summary>
        [Fact]
        public void ComposeServicesFrom_WhenCalledWithMultipleSources_ReturnsTargetCollection()
        {
            ServiceCollection target = new();
            ServiceCollection firstSource = new();
            ServiceCollection secondSource = new();

            firstSource.AddTransient<ISampleService, SampleService>();
            secondSource.AddTransient<ISecondaryService, SecondaryService>();

            IServiceCollection result = target.ComposeServicesFrom(null, firstSource, secondSource);

            Assert.Same(target, result);
        }

        /// <summary>
        /// Verifies that the extension method throws when the target collection is null.
        /// </summary>
        [Fact]
        public void ComposeServicesFrom_WhenTargetIsNull_ThrowsArgumentNullException()
        {
            ServiceCollection source = new();
            IServiceCollection? target = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => target!.ComposeServicesFrom(null, source));

            Assert.Equal("services", exception.ParamName);
        }

        /// <summary>
        /// Verifies that the extension method throws when the sources array is null.
        /// </summary>
        [Fact]
        public void ComposeServicesFrom_WhenSourcesAreNull_ThrowsArgumentNullException()
        {
            ServiceCollection target = new();
            IServiceCollection[]? sources = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => target.ComposeServicesFrom(null, sources!));

            Assert.Equal("sources", exception.ParamName);
        }
    }
}
