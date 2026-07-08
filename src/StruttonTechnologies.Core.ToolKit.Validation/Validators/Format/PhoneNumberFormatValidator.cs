using StruttonTechnologies.Core.Rules;
using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format
{
    /// <summary>
    /// Validates that a phone number satisfies the shared phone number rules.
    /// </summary>
    public sealed class PhoneNumberFormatValidator : IValidator<string>
    {
        /// <summary>
        /// Validates the supplied phone number.
        /// </summary>
        /// <param name="input">The phone number to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> describing the outcome.</returns>
        public ValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return ValidationResult.Failure(
                    message: "Phone number is required.",
                    code: "Required",
                    field: nameof(input));
            }

            if (!PhoneNumberRules.IsValid(input))
            {
                return ValidationResult.Failure(
                    message: "Invalid phone number format.",
                    code: "InvalidFormat",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }
    }
}
