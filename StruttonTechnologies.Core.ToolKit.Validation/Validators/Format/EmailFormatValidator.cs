using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format
{
    /// <summary>
    /// Validates that an email address matches a practical standard format.
    /// </summary>
    public sealed partial class EmailFormatValidator : IValidator<string>
    {
        /// <summary>
        /// Validates the supplied email address.
        /// </summary>
        /// <param name="input">The email address to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> describing the outcome.</returns>
        public ValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return ValidationResult.Failure(
                    message: "Email is required.",
                    code: "Required",
                    field: nameof(input));
            }

            if (!EmailRegex().IsMatch(input))
            {
                return ValidationResult.Failure(
                    message: "Invalid email format.",
                    code: "InvalidFormat",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();
    }
}
