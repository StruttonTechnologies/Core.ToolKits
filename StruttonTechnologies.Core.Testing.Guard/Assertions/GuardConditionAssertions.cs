using StruttonTechnologies.Core.Toolkit.Testing.Guard.Conditions;
using StruttonTechnologies.Core.ToolKit.Guards;

namespace StruttonTechnologies.Core.Toolkit.Testing.Guard.Assertions
{
    /// <summary>
    /// Provides assertion helpers for validating <see cref="GuardCondition{T}"/> outcomes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class GuardConditionAssertions
    {
        /// <summary>
        /// Asserts that the specified guard condition matched.
        /// </summary>
        /// <typeparam name="T">
        /// The type carried by the guard condition.
        /// </typeparam>
        /// <param name="condition">
        /// The guard condition to validate.
        /// </param>
        public static void AssertMatched<T>(GuardCondition<T> condition)
        {
            bool matched = GuardConditionTestHelper.IsMatched(condition);

            Assert.True(matched);
        }

        /// <summary>
        /// Asserts that the specified guard condition did not match.
        /// </summary>
        /// <typeparam name="T">
        /// The type carried by the guard condition.
        /// </typeparam>
        /// <param name="condition">
        /// The guard condition to validate.
        /// </param>
        public static void AssertNotMatched<T>(GuardCondition<T> condition)
        {
            bool matched = GuardConditionTestHelper.IsMatched(condition);

            Assert.False(matched);
        }
    }
}
