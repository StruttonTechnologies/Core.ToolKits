namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.Models
{
    /// <summary>
    /// Contains test scenarios for <see cref="ServiceCompositionBehavior"/>.
    /// </summary>
    public sealed class ServiceCompositionBehaviorTests
    {
        /// <summary>
        /// Verifies that each enum member has the expected underlying integer value.
        /// </summary>
        /// <param name="behavior">The enum value under test.</param>
        /// <param name="expected">The expected numeric value.</param>
        [Theory]
        [InlineData(ServiceCompositionBehavior.Append, 0)]
        [InlineData(ServiceCompositionBehavior.SkipExistingServiceType, 1)]
        [InlineData(ServiceCompositionBehavior.ReplaceExistingServiceType, 2)]
        [InlineData(ServiceCompositionBehavior.ThrowIfServiceTypeExists, 3)]
        public void EnumValues_AreExpected(ServiceCompositionBehavior behavior, int expected)
        {
            Assert.Equal(expected, (int)behavior);
        }
    }
}
