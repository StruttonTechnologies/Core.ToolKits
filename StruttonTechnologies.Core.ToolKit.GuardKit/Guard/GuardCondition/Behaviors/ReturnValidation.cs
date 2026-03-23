using ValidationResult = StruttonTechnologies.Core.ToolKit.Validation.Models.ValidationResult;

namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    /// <summary>
    /// Provides validation-specific continuation behaviors for <see cref="GuardCondition{T}"/>.
    /// </summary>
    public static class GuardConditionValidationBehaviors
    {
        public static ValidationResult ReturnValidation<T>(
            this GuardCondition<T> condition,
            string message,
            string code,
            string field,
            Func<T, ValidationResult> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(code);
            ArgumentNullException.ThrowIfNull(field);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.Return(
                ValidationResult.Failure(message: message, code: code, field: field),
                whenNotMatched);
        }

        public static ValidationResult ReturnValidation<T>(
            this GuardCondition<T> condition,
            string message,
            string code,
            string field,
            Func<ValidationResult> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(code);
            ArgumentNullException.ThrowIfNull(field);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.Return(
                ValidationResult.Failure(message: message, code: code, field: field),
                _ => whenNotMatched());
        }

        public static Task<ValidationResult> ReturnValidationAsync<T>(
            this GuardCondition<T> condition,
            string message,
            string code,
            string field,
            Func<T, Task<ValidationResult>> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(code);
            ArgumentNullException.ThrowIfNull(field);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.ReturnAsync(
                ValidationResult.Failure(message: message, code: code, field: field),
                whenNotMatched);
        }

        public static Task<ValidationResult> ReturnValidationAsync<T>(
            this GuardCondition<T> condition,
            string message,
            string code,
            string field,
            Func<Task<ValidationResult>> whenNotMatched)
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(code);
            ArgumentNullException.ThrowIfNull(field);
            ArgumentNullException.ThrowIfNull(whenNotMatched);

            return condition.ReturnAsync(
                ValidationResult.Failure(message: message, code: code, field: field),
                _ => whenNotMatched());
        }
    }
}
