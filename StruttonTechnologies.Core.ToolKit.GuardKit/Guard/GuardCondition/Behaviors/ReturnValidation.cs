using System.ComponentModel.DataAnnotations;

using StruttonTechnologies.Core.ToolKit.GuardKit;

namespace StruttonTechnologies.Core.ToolKit.Guardkit.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Provides validation-specific continuation behaviors for <see cref="GuardCondition{T}"/>.
    /// </summary>
    public static class GuardConditionValidationBehaviors
    {
        /// <summary>
        /// Returns the specified validation result when the guard condition is matched;
        /// otherwise executes the provided continuation.
        /// </summary>
        /// <typeparam name="T">The type of the guarded value.</typeparam>
        /// <param name="condition">The guard condition.</param>
        /// <param name="whenMatched">
        /// The validation result to return when the condition is matched.
        /// </param>
        /// <param name="whenNotMatched">
        /// The continuation to execute when the condition is not matched.
        /// </param>
        /// <returns>
        /// The matched validation result when the condition is matched;
        /// otherwise the result of the continuation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="condition"/> or <paramref name="whenNotMatched"/> is <see langword="null"/>.
        /// </exception>
        public static ValidationResult ReturnValidation<T>(
            this GuardCondition<T> condition,
            ValidationResult whenMatched,
            Func<T, ValidationResult> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(whenMatched);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.Return(whenMatched, whenNotMatched);
        }

        /// <summary>
        /// Returns the specified validation result when the guard condition is matched;
        /// otherwise executes the provided parameterless continuation.
        /// </summary>
        /// <typeparam name="T">The type of the guarded value.</typeparam>
        /// <param name="condition">The guard condition.</param>
        /// <param name="whenMatched">
        /// The validation result to return when the condition is matched.
        /// </param>
        /// <param name="whenNotMatched">
        /// The continuation to execute when the condition is not matched.
        /// </param>
        /// <returns>
        /// The matched validation result when the condition is matched;
        /// otherwise the result of the continuation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="condition"/> or <paramref name="whenNotMatched"/> is <see langword="null"/>.
        /// </exception>
        public static ValidationResult ReturnValidation<T>(
            this GuardCondition<T> condition,
            ValidationResult whenMatched,
            Func<ValidationResult> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(whenMatched);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.Return(whenMatched, _ => whenNotMatched());
        }

        /// <summary>
        /// Returns the specified validation result when the guard condition is matched;
        /// otherwise executes the provided asynchronous continuation.
        /// </summary>
        /// <typeparam name="T">The type of the guarded value.</typeparam>
        /// <param name="condition">The guard condition.</param>
        /// <param name="whenMatched">
        /// The validation result to return when the condition is matched.
        /// </param>
        /// <param name="whenNotMatched">
        /// The asynchronous continuation to execute when the condition is not matched.
        /// </param>
        /// <returns>
        /// A task that returns the matched validation result when the condition is matched;
        /// otherwise the result of the continuation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="condition"/> or <paramref name="whenNotMatched"/> is <see langword="null"/>.
        /// </exception>
        public static Task<ValidationResult> ReturnValidationAsync<T>(
            this GuardCondition<T> condition,
            ValidationResult whenMatched,
            Func<T, Task<ValidationResult>> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(whenMatched);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.ReturnAsync(whenMatched, whenNotMatched);
        }

        /// <summary>
        /// Returns the specified validation result when the guard condition is matched;
        /// otherwise executes the provided parameterless asynchronous continuation.
        /// </summary>
        /// <typeparam name="T">The type of the guarded value.</typeparam>
        /// <param name="condition">The guard condition.</param>
        /// <param name="whenMatched">
        /// The validation result to return when the condition is matched.
        /// </param>
        /// <param name="whenNotMatched">
        /// The asynchronous continuation to execute when the condition is not matched.
        /// </param>
        /// <returns>
        /// A task that returns the matched validation result when the condition is matched;
        /// otherwise the result of the continuation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="condition"/> or <paramref name="whenNotMatched"/> is <see langword="null"/>.
        /// </exception>
        public static Task<ValidationResult> ReturnValidationAsync<T>(
            this GuardCondition<T> condition,
            ValidationResult whenMatched,
            Func<Task<ValidationResult>> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(whenMatched);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.ReturnAsync(whenMatched, _ => whenNotMatched());
        }
    }
}
