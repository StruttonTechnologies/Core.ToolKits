namespace StruttonTechnologies.Core.Toolkit.Testing.Gaurd.Conditions
{
    /// <summary>
    /// Provides helper methods for evaluating <see cref="GuardCondition{T}"/> results in tests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class GuardConditionTestHelper
    {
        /// <summary>
        /// Determines whether the specified guard condition matched.
        /// </summary>
        /// <typeparam name="T">
        /// The type carried by the guard condition.
        /// </typeparam>
        /// <param name="condition">
        /// The guard condition to evaluate.
        /// </param>
        /// <returns>
        /// <see langword="true"/> when the condition matched; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsMatched<T>(GuardCondition<T> condition)
        {
            return condition.Return(true, _ => false);
        }

        /// <summary>
        /// Determines whether the specified guard condition did not match.
        /// </summary>
        /// <typeparam name="T">
        /// The type carried by the guard condition.
        /// </typeparam>
        /// <param name="condition">
        /// The guard condition to evaluate.
        /// </param>
        /// <returns>
        /// <see langword="true"/> when the condition did not match; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNotMatched<T>(GuardCondition<T> condition)
        {
            return condition.Return(false, _ => true);
        }
    }
}
