using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format
{
    /// <summary>
    /// Validates that a United States ZIP code matches either five digits or ZIP+4 format.
    /// </summary>
    public sealed partial class UsZipCodeFormatValidator : IValidator<string>
    {
        /// <summary>
        /// Validates the supplied ZIP code.
        /// </summary>
        public ValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return ValidationResult.Failure(
                    message: "ZIP code is required.",
                    code: "Required",
                    field: nameof(input));
            }

            if (!ZipCodeRegex().IsMatch(input))
            {
                return ValidationResult.Failure(
                    message: "Invalid ZIP code format.",
                    code: "InvalidFormat",
                    field: nameof(input));
            }

            return ValidationResult.Success();
        }

        [GeneratedRegex(@"^\d{5}(-\d{4})?$")]
        private static partial Regex ZipCodeRegex();
    }
}
