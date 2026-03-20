namespace StruttonTechnologies.Core.ToolKit.Validation.Validators.Composite;

using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

/// <summary>
/// Executes multiple validators in sequence and returns the first failure encountered.
/// </summary>
/// <typeparam name="T">The input type validated by the composite validator.</typeparam>
public sealed class CompositeValidator<T> : IValidator<T>
{
    private readonly IReadOnlyList<IValidator<T>> validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeValidator{T}"/> class.
    /// </summary>
    /// <param name="validators">The validators to execute in order.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="validators"/> is null.</exception>
    public CompositeValidator(IEnumerable<IValidator<T>> validators)
    {
        ArgumentNullException.ThrowIfNull(validators);
        this.validators = validators.ToArray();
    }

    /// <summary>
    /// Validates the supplied input by executing the configured validators in order.
    /// </summary>
    /// <param name="input">The input to validate.</param>
    /// <returns>
    /// The first failed <see cref="ValidationResult"/>, or a success result when all validators pass.
    /// </returns>
    public ValidationResult Validate(T input)
    {
        foreach (var validator in this.validators)
        {
            var result = validator.Validate(input);
            if (!result.IsValid)
            {
                return result;
            }
        }

        return ValidationResult.Success();
    }
}
