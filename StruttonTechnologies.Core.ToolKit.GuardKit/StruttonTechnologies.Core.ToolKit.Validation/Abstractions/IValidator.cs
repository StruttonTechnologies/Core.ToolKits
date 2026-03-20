namespace StruttonTechnologies.Core.ToolKit.Validation.Abstractions;

using StruttonTechnologies.Core.ToolKit.Validation.Models;

/// <summary>
/// Defines a validator for a specific input type.
/// </summary>
/// <typeparam name="T">The type of value to validate.</typeparam>
public interface IValidator<in T>
{
    /// <summary>
    /// Validates the supplied input value.
    /// </summary>
    /// <param name="input">The value to validate.</param>
    /// <returns>
    /// A <see cref="ValidationResult"/> that describes whether validation succeeded or failed.
    /// </returns>
    ValidationResult Validate(T input);
}
