using System.Text.RegularExpressions;

using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format
{
    /// <summary>
    /// Validates that an email address matches a practical standard format.
    /// </summary>
    public sealed class EmailFormatValidator : IValidator<string>
    {
        private static readonly Regex Regex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

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

            if (!Regex.IsMatch(input))
            {
                return ValidationResult.Failure(
                    message: "Invalid email format.",
                    code: "InvalidFormat",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }
    }
}
