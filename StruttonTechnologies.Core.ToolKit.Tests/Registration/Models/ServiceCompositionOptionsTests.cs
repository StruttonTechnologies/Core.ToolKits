namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Models
{
    /// <summary>
    /// Contains test scenarios for <see cref="ServiceCompositionOptions"/>.
    /// </summary>
    public sealed class ServiceCompositionOptionsTests
    {
        /// <summary>
        /// Verifies that a new options instance defaults to append behavior.
        /// </summary>
        [Fact]
        public void Constructor_WhenCreated_DefaultsToAppendBehavior()
        {
            ServiceCompositionOptions options = new();

            Assert.Equal(ServiceCompositionBehavior.Append, options.Behavior);
        }

        /// <summary>
        /// Verifies that the logger property is <see langword="null"/> by default.
        /// </summary>
        [Fact]
        public void Constructor_WhenCreated_DefaultsLoggerToNull()
        {
            ServiceCompositionOptions options = new();

            Assert.Null(options.Logger);
        }

        /// <summary>
        /// Verifies that assigned property values are preserved.
        /// </summary>
        [Fact]
        public void Properties_WhenAssigned_RetainConfiguredValues()
        {
            Action<string> logger = _ => { };
            ServiceCompositionOptions options = new()
            {
                Behavior = ServiceCompositionBehavior.ReplaceExistingServiceType,
                Logger = logger
            };

            Assert.Equal(ServiceCompositionBehavior.ReplaceExistingServiceType, options.Behavior);
            Assert.Same(logger, options.Logger);
        }
    }
}
