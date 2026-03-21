namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Utilities
{
    /// <summary>
    /// Contains guard-clause test scenarios for <see cref="ServiceCollectionComposer"/>.
    /// </summary>
    public sealed class ServiceCollectionComposerGuardClauseTests
    {
        /// <summary>
        /// Verifies that composing a single source throws when the target collection is null.
        /// </summary>
        [Fact]
        public void Compose_WhenTargetIsNull_ThrowsArgumentNullException()
        {
            IServiceCollection? target = null;
            ServiceCollection source = new();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ServiceCollectionComposer.Compose(target!, source));

            Assert.Equal("target", exception.ParamName);
        }

        /// <summary>
        /// Verifies that composing a single source throws when the source collection is null.
        /// </summary>
        [Fact]
        public void Compose_WhenSourceIsNull_ThrowsArgumentNullException()
        {
            ServiceCollection target = new();
            IServiceCollection? source = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ServiceCollectionComposer.Compose(target, source!));

            Assert.Equal("source", exception.ParamName);
        }
    }
}
