using System.Collections.ObjectModel;

namespace StruttonTechnologies.Core.ToolKit.Validation.Models
{
    /// <summary>
    /// Represents the outcome of a validation operation.
    /// </summary>
    public sealed class ValidationResult
    {
        private ValidationResult(
            bool isValid,
            string? message,
            string? code,
            string? field,
            IReadOnlyList<string>? suggestions,
            IReadOnlyDictionary<string, object>? metadata,
            Exception? exception,
            string? traceId,
            ValidationSeverity severity)
        {
            this.IsValid = isValid;
            this.Message = message;
            this.Code = code;
            this.Field = field;
            this.Suggestions = suggestions;
            this.Metadata = metadata;
            this.Exception = exception;
            this.TraceId = traceId;
            this.Severity = severity;
        }

        /// <summary>
        /// Gets a value indicating whether validation succeeded.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Gets a human-readable validation message.
        /// </summary>
        public string? Message { get; }

        /// <summary>
        /// Gets a machine-readable validation code.
        /// </summary>
        public string? Code { get; }

        /// <summary>
        /// Gets the field or logical member associated with the validation result.
        /// </summary>
        public string? Field { get; }

        /// <summary>
        /// Gets optional suggestions that can help resolve the validation issue.
        /// </summary>
        public IReadOnlyList<string>? Suggestions { get; }

        /// <summary>
        /// Gets optional metadata for diagnostics, telemetry, or UI handling.
        /// </summary>
        public IReadOnlyDictionary<string, object>? Metadata { get; }

        /// <summary>
        /// Gets the exception associated with the validation result, if any.
        /// </summary>
        public Exception? Exception { get; }

        /// <summary>
        /// Gets an optional trace identifier used for correlation.
        /// </summary>
        public string? TraceId { get; }

        /// <summary>
        /// Gets the severity associated with the validation result.
        /// </summary>
        public ValidationSeverity Severity { get; }

        /// <summary>
        /// Creates a success result.
        /// </summary>
        /// <param name="message">An optional success message.</param>
        /// <returns>A successful <see cref="ValidationResult"/>.</returns>
        public static ValidationResult Success(string? message = null)
            => new(true, message, null, null, null, null, null, null, ValidationSeverity.Info);

        /// <summary>
        /// Creates a warning result.
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="code">An optional warning code.</param>
        /// <param name="field">An optional field associated with the warning.</param>
        /// <param name="suggestions">Optional suggestions for resolving the warning.</param>
        /// <param name="metadata">Optional metadata associated with the warning.</param>
        /// <param name="traceId">An optional trace identifier.</param>
        /// <returns>A warning <see cref="ValidationResult"/>.</returns>
        public static ValidationResult Warning(
            string message,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null,
            string? traceId = null)
            => new(
                true,
                message,
                code,
                field,
                suggestions is null ? null : new ReadOnlyCollection<string>(suggestions.ToArray()),
                metadata is null ? null : new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(metadata)),
                null,
                traceId,
                ValidationSeverity.Warning);

        /// <summary>
        /// Creates a failure result.
        /// </summary>
        /// <param name="message">The failure message.</param>
        /// <param name="code">An optional error code.</param>
        /// <param name="field">An optional field associated with the failure.</param>
        /// <param name="suggestions">Optional suggestions for resolving the failure.</param>
        /// <param name="metadata">Optional metadata associated with the failure.</param>
        /// <param name="exception">An optional exception related to the failure.</param>
        /// <param name="traceId">An optional trace identifier.</param>
        /// <param name="severity">The failure severity.</param>
        /// <returns>A failed <see cref="ValidationResult"/>.</returns>
        public static ValidationResult Failure(
            string message,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null,
            Exception? exception = null,
            string? traceId = null,
            ValidationSeverity severity = ValidationSeverity.Error)
            => new(
                false,
                message,
                code,
                field,
                suggestions is null ? null : new ReadOnlyCollection<string>(suggestions.ToArray()),
                metadata is null ? null : new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(metadata)),
                exception,
                traceId,
                severity);

        /// <summary>
        /// Creates a copy of the current result with updated values.
        /// </summary>
        /// <param name="isValid">An optional validity override.</param>
        /// <param name="message">An optional message override.</param>
        /// <param name="code">An optional code override.</param>
        /// <param name="field">An optional field override.</param>
        /// <param name="suggestions">Optional suggestions override.</param>
        /// <param name="metadata">Optional metadata override.</param>
        /// <param name="exception">An optional exception override.</param>
        /// <param name="traceId">An optional trace identifier override.</param>
        /// <param name="severity">An optional severity override.</param>
        /// <returns>A new <see cref="ValidationResult"/> containing the merged values.</returns>
        public ValidationResult Copy(
            bool? isValid = null,
            string? message = null,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null,
            Exception? exception = null,
            string? traceId = null,
            ValidationSeverity? severity = null)
        {
            var actualSuggestions = suggestions is null
                ? this.Suggestions?.ToArray()
                : suggestions.ToArray();

            var actualMetadata = metadata is null
                ? this.Metadata?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                : new Dictionary<string, object>(metadata);

            return new ValidationResult(
                isValid ?? this.IsValid,
                message ?? this.Message,
                code ?? this.Code,
                field ?? this.Field,
                actualSuggestions is null ? null : new ReadOnlyCollection<string>(actualSuggestions),
                actualMetadata is null ? null : new ReadOnlyDictionary<string, object>(actualMetadata),
                exception ?? this.Exception,
                traceId ?? this.TraceId,
                severity ?? this.Severity);
        }
    }
}
