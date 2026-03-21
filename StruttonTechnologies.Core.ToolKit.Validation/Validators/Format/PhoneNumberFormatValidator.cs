using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format
{
    /// <summary>
    /// Validates that a phone number matches a practical E.164-style format.
    /// </summary>
    public sealed partial class PhoneNumberFormatValidator : IValidator<string>
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

            if (!PhoneRegex().IsMatch(input))
            {
                return ValidationResult.Failure(
                    message: "Phone number must be in valid international format (E.164).",
                    code: "InvalidFormat",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }

        [GeneratedRegex(@"^\+?[1-9]\d{9,14}$")]
        private static partial Regex PhoneRegex();
    }
}
