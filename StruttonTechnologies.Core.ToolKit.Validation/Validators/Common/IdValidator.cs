using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Common
{
    /// <summary>
    /// Validates that an identifier value is not its default value.
    /// </summary>
    /// <typeparam name="TKey">The identifier type.</typeparam>
    public sealed class IdValidator<TKey> : IValidator<TKey>
    {
        /// <summary>
        /// Validates that the supplied identifier is non-default.
        /// </summary>
        /// <param name="input">The identifier value to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> describing the outcome.</returns>
        public ValidationResult Validate(TKey input)
        {
            if (EqualityComparer<TKey>.Default.Equals(input, default!))
            {
                return ValidationResult.Failure(
                    message: "ID must be set and non-default.",
                    code: "InvalidId",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }
    }
}
