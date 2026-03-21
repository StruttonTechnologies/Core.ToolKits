using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains invalid behavior test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerInvalidBehaviorTests
    {
        /// <summary>
        /// Verifies that an unsupported composition behavior throws <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        [Fact]
        public void Compose_WithUnsupportedBehavior_ThrowsArgumentOutOfRangeException()
        {
            ServiceCollection target = new();
            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();

            ServiceCompositionOptions options = new()
            {
                Behavior = (ServiceCompositionBehavior)999
            };

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                ServiceCollectionComposer.Compose(target, source, options));

            Assert.Equal("Behavior", exception.ParamName);
        }
    }
}
