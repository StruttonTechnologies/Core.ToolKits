using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains replace-behavior test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerReplaceBehaviorTests
    {
        /// <summary>
        /// Verifies that replace behavior removes existing descriptors for the same service type before adding the new descriptor.
        /// </summary>
        [Fact]
        public void Compose_WithReplaceExistingServiceType_ReplacesMatchingDescriptors()
        {
            ServiceCollection target = new();
            target.AddScoped<ISampleService, ReplacementSampleService>();
            target.AddTransient<ISampleService, ReplacementSampleService>();

            ServiceCollection source = new();
            source.AddSingleton<ISampleService, SampleService>();

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.ReplaceExistingServiceType
            });

            ServiceDescriptor descriptor = Assert.Single(target);
            Assert.Equal(typeof(SampleService), descriptor.ImplementationType);
            Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
        }

        /// <summary>
        /// Verifies that replace behavior writes a replacement log message.
        /// </summary>
        [Fact]
        public void Compose_WithReplaceExistingServiceType_LogsReplaceMessage()
        {
            ServiceCollection target = new();
            target.AddSingleton<ISampleService, ReplacementSampleService>();

            ServiceCollection source = new();
            source.AddSingleton<ISampleService, SampleService>();
            List<string> messages = [];

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.ReplaceExistingServiceType,
                Logger = messages.Add
            });

            string message = Assert.Single(messages);
            Assert.Contains("Replaced service type:", message);
        }
    }
}
