using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Common
{
    /// <summary>
    /// Validates that a value is not equal to the default value for its type.
    /// </summary>
    /// <typeparam name="T">The value type to validate.</typeparam>
    public sealed class NotDefaultValidator<T> : IValidator<T>
    {
        /// <summary>
        /// Validates that the supplied value is not the default for its type.
        /// </summary>
        /// <param name="input">The value to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> describing the outcome.</returns>
        public ValidationResult Validate(T input)
        {
            if (EqualityComparer<T>.Default.Equals(input, default!))
            {
                return ValidationResult.Failure(
                    message: "Value must not be the default for its type.",
                    code: "NotDefault",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }
    }
}
