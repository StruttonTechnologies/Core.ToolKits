namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Contact;

using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

/// <summary>
/// Validates that an email address exists within a configured whitelist.
/// </summary>
public sealed class WhitelistEmailValidator : IValidator<string>
{
    private readonly HashSet<string> allowedEmails;

    /// <summary>
    /// Initializes a new instance of the <see cref="WhitelistEmailValidator"/> class.
    /// </summary>
    /// <param name="allowedEmails">The allowed email addresses.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="allowedEmails"/> is null.</exception>
    public WhitelistEmailValidator(IEnumerable<string> allowedEmails)
    {
        ArgumentNullException.ThrowIfNull(allowedEmails);
        this.allowedEmails = new HashSet<string>(allowedEmails, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Validates that the supplied email address exists in the whitelist.
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

        if (!this.allowedEmails.Contains(input))
        {
            return ValidationResult.Failure(
                message: "Email is not authorized.",
                code: "NotWhitelisted",
                field: nameof(input));
        }

        return ValidationResult.Success();
    }
}
