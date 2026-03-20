namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Common;

using System.Text.RegularExpressions;
using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

/// <summary>
/// Validates string input against a supplied regular expression.
/// </summary>
public sealed class RegexValidator : IValidator<string>
{
    private readonly Regex regex;
    private readonly string errorMessage;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegexValidator"/> class.
    /// </summary>
    /// <param name="pattern">The regular expression pattern to use.</param>
    /// <param name="errorMessage">The error message returned when the pattern does not match.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="pattern"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="pattern"/> is empty.</exception>
    public RegexValidator(string pattern, string? errorMessage = null)
    {
        ArgumentNullException.ThrowIfNull(pattern);

        if (string.IsNullOrWhiteSpace(pattern))
        {
            throw new ArgumentException("A regex pattern is required.", nameof(pattern));
        }

        this.regex = new Regex(pattern, RegexOptions.Compiled);
        this.errorMessage = errorMessage ?? "Value does not match the required format.";
    }

    /// <summary>
    /// Validates the supplied string value.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns>A <see cref="ValidationResult"/> describing the outcome.</returns>
    public ValidationResult Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return ValidationResult.Failure(
                message: "Value is required.",
                code: "Required",
                field: nameof(input));
        }

        if (!this.regex.IsMatch(input))
        {
            return ValidationResult.Failure(
                message: this.errorMessage,
                code: "RegexMismatch",
                field: nameof(input));
        }

        return ValidationResult.Success();
    }
}
