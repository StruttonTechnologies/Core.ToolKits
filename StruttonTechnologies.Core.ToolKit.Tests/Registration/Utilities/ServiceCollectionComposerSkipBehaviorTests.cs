using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains skip-behavior test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerSkipBehaviorTests
    {
        /// <summary>
        /// Verifies that skip behavior adds a descriptor when the service type does not already exist.
        /// </summary>
        [Fact]
        public void Compose_WithSkipExistingServiceType_WhenServiceTypeDoesNotExist_AddsDescriptor()
        {
            ServiceCollection target = new();
            ServiceCollection source = new();
            source.AddSingleton<ISampleService, SampleService>();

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.SkipExistingServiceType
            });

            ServiceDescriptor descriptor = Assert.Single(target);
            Assert.Equal(typeof(SampleService), descriptor.ImplementationType);
        }

        /// <summary>
        /// Verifies that skip behavior does not add a duplicate service type.
        /// </summary>
        [Fact]
        public void Compose_WithSkipExistingServiceType_WhenServiceTypeExists_SkipsDescriptor()
        {
            ServiceCollection target = new();
            target.AddSingleton<ISampleService, ReplacementSampleService>();

            ServiceCollection source = new();
            source.AddSingleton<ISampleService, SampleService>();

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.SkipExistingServiceType
            });

            ServiceDescriptor descriptor = Assert.Single(target);
            Assert.Equal(typeof(ReplacementSampleService), descriptor.ImplementationType);
        }

        /// <summary>
        /// Verifies that skip behavior writes the expected skip log message.
        /// </summary>
        [Fact]
        public void Compose_WithSkipExistingServiceType_WhenServiceTypeExists_LogsSkipMessage()
        {
            ServiceCollection target = new();
            target.AddSingleton<ISampleService, ReplacementSampleService>();

            ServiceCollection source = new();
            source.AddSingleton<ISampleService, SampleService>();
            List<string> messages = [];

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.SkipExistingServiceType,
                Logger = messages.Add
            });

            string message = Assert.Single(messages);
            Assert.Contains("Skipped existing service type:", message);
        }
    }
}
