namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Format;

using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

/// <summary>
/// Validates that a phone number does not exist within a configured blacklist.
/// </summary>
public sealed class BlacklistPhoneValidator : IValidator<string>
{
    private readonly HashSet<string> blacklistedNumbers;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlacklistPhoneValidator"/> class.
    /// </summary>
    /// <param name="blacklistedNumbers">The phone numbers to block.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="blacklistedNumbers"/> is null.</exception>
    public BlacklistPhoneValidator(IEnumerable<string> blacklistedNumbers)
    {
        ArgumentNullException.ThrowIfNull(blacklistedNumbers);
        this.blacklistedNumbers = new HashSet<string>(blacklistedNumbers, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Validates that the supplied phone number is not blacklisted.
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

        if (this.blacklistedNumbers.Contains(input))
        {
            return ValidationResult.Failure(
                message: "Phone number is not allowed.",
                code: "Blacklisted",
                field: nameof(input));
        }

        return ValidationResult.Success();
    }
}
