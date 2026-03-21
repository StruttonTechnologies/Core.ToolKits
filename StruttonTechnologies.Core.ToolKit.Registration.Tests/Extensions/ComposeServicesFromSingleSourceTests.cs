using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Extensions
{
    /// <summary>
    /// Contains test scenarios for composing a single source collection through extension methods.
    /// </summary>
    public sealed class ComposeServicesFromSingleSourceTests
    {
        /// <summary>
        /// Verifies that the extension method returns the original target collection.
        /// </summary>
        [Fact]
        public void ComposeServicesFrom_WhenCalled_ReturnsTargetCollection()
        {
            ServiceCollection target = new();
            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();

            IServiceCollection result = target.ComposeServicesFrom(source);

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

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => target!.ComposeServicesFrom(source));

            Assert.Equal("services", exception.ParamName);
        }

        /// <summary>
        /// Verifies that the extension method throws when the source collection is null.
        /// </summary>
        [Fact]
        public void ComposeServicesFrom_WhenSourceIsNull_ThrowsArgumentNullException()
        {
            ServiceCollection target = new();
            IServiceCollection? source = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => target.ComposeServicesFrom(source!));

            Assert.Equal("source", exception.ParamName);
        }
    }
}
