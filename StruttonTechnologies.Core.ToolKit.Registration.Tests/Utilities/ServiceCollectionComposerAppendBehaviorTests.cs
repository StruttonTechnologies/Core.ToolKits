using StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles;

namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains append-behavior test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerAppendBehaviorTests
    {
        /// <summary>
        /// Verifies that append behavior adds descriptors from the source to the target.
        /// </summary>
        [Fact]
        public void Compose_WithAppendBehavior_AddsSourceDescriptors()
        {
            ServiceCollection target = new();
            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.Append
            });

            ServiceDescriptor descriptor = Assert.Single(target);
            Assert.Equal(typeof(ISampleService), descriptor.ServiceType);
            Assert.Equal(typeof(SampleService), descriptor.ImplementationType);
            Assert.Equal(ServiceLifetime.Transient, descriptor.Lifetime);
        }

        /// <summary>
        /// Verifies that append behavior preserves existing descriptors and allows duplicates by service type.
        /// </summary>
        [Fact]
        public void Compose_WithAppendBehavior_PreservesExistingDescriptors()
        {
            ServiceCollection target = new();
            target.AddTransient<ISampleService, ReplacementSampleService>();

            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.Append
            });

            Assert.Equal(2, target.Count(descriptor => descriptor.ServiceType == typeof(ISampleService)));
        }

        /// <summary>
        /// Verifies that append behavior writes a log message when a logger is supplied.
        /// </summary>
        [Fact]
        public void Compose_WithAppendBehavior_LogsAppendAction()
        {
            ServiceCollection target = new();
            ServiceCollection source = new();
            source.AddTransient<ISampleService, SampleService>();
            List<string> messages = [];

            ServiceCollectionComposer.Compose(target, source, new ServiceCompositionOptions
            {
                Behavior = ServiceCompositionBehavior.Append,
                Logger = messages.Add
            });

            string message = Assert.Single(messages);
            Assert.Contains("Appended:", message);
            Assert.Contains(typeof(ISampleService).FullName!, message);
            Assert.Contains(typeof(SampleService).FullName!, message);
        }
    }
}
