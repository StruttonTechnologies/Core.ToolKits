using StruttonTechnologies.Core.Rules;
using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format
{
    /// <summary>
    /// Validates that a United States ZIP code satisfies the shared ZIP code rules.
    /// </summary>
    public sealed class UsZipCodeFormatValidator : IValidator<string>
    {
        /// <summary>
        /// Validates the supplied ZIP code.
        /// </summary>
        /// <param name="input">The ZIP code to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> describing the outcome.</returns>
        public ValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return ValidationResult.Failure(
                    message: "ZIP code is required.",
                    code: "Required",
                    field: nameof(input));
            }

            if (!UsZipCodeRules.IsValid(input))
            {
                return ValidationResult.Failure(
                    message: "Invalid ZIP code format.",
                    code: "InvalidFormat",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }
    }
}
