using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains throw-behavior test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerThrowBehaviorTests
    {
        /// <summary>
        /// Verifies that throw behavior adds a descriptor when the service type does not already exist.
        /// </summary>
        [Fact]
        public void Compose_WithThrowIfServiceTypeExists_WhenServiceTypeDoesNotExist_AddsDescriptor()
        {
            ServiceCollection target = new();
            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.ThrowIfServiceTypeExists
            });

            ServiceDescriptor descriptor = Assert.Single(target);
            Assert.Equal(typeof(SampleService), descriptor.ImplementationType);
        }

        /// <summary>
        /// Verifies that throw behavior raises an exception when the target already contains the same service type.
        /// </summary>
        [Fact]
        public void Compose_WithThrowIfServiceTypeExists_WhenServiceTypeExists_ThrowsInvalidOperationException()
        {
            ServiceCollection target = new();
            target.AddTransient<ISampleService, ReplacementSampleService>();

            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
                {
                    Behavior = ServiceCompositionBehavior.ThrowIfServiceTypeExists
                }));

            Assert.Contains(typeof(ISampleService).FullName!, exception.Message);
        }
    }
}
