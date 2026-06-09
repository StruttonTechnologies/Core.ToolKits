using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Validation.Extensions
{
    /// <summary>
    /// Provides convenience methods for enriching <see cref="ValidationResult"/> instances.
    /// </summary>
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Adds or replaces the field value on a validation result.
        /// </summary>
        /// <param name="result">The source result.</param>
        /// <param name="field">The field name to associate with the result.</param>
        /// <returns>A new <see cref="ValidationResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> or <paramref name="field"/> is null.</exception>
        public static ValidationResult WithField(this ValidationResult result, string field)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(field);
            return result.Copy(field: field);
        }

        /// <summary>
        /// Adds or replaces the trace identifier on a validation result.
        /// </summary>
        /// <param name="result">The source result.</param>
        /// <param name="traceId">The trace identifier.</param>
        /// <returns>A new <see cref="ValidationResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> or <paramref name="traceId"/> is null.</exception>
        public static ValidationResult WithTraceId(this ValidationResult result, string traceId)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(traceId);
            return result.Copy(traceId: traceId);
        }

        /// <summary>
        /// Appends a suggestion to a validation result.
        /// </summary>
        /// <param name="result">The source result.</param>
        /// <param name="suggestion">The suggestion text to add.</param>
        /// <returns>A new <see cref="ValidationResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> or <paramref name="suggestion"/> is null.</exception>
        public static ValidationResult WithSuggestion(this ValidationResult result, string suggestion)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(suggestion);

            var updatedSuggestions = result.Suggestions?.ToList() ?? new List<string>();
            updatedSuggestions.Add(suggestion);
            return result.Copy(suggestions: updatedSuggestions);
        }

        /// <summary>
        /// Adds or replaces a metadata entry on a validation result.
        /// </summary>
        /// <param name="result">The source result.</param>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>A new <see cref="ValidationResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> or <paramref name="key"/> is null.</exception>
        public static ValidationResult WithMetadata(this ValidationResult result, string key, object value)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(key);

            var updatedMetadata = result.Metadata?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value) ?? new Dictionary<string, object>();
            updatedMetadata[key] = value;
            return result.Copy(metadata: updatedMetadata);
        }

        /// <summary>
        /// Adds or replaces an exception on a validation result.
        /// </summary>
        /// <param name="result">The source result.</param>
        /// <param name="exception">The exception to associate with the result.</param>
        /// <returns>A new <see cref="ValidationResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> or <paramref name="exception"/> is null.</exception>
        public static ValidationResult WithException(this ValidationResult result, Exception exception)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(exception);
            return result.Copy(exception: exception);
        }
    }
}
