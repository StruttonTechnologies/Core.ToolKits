using System.Collections.ObjectModel;

namespace StruttonTechnologies.Core.ToolKit.Validation.Models
{
    /// <summary>
    /// Represents a single validation failure with associated details.
    /// </summary>
    public sealed class ValidationFailure
    {
        private ValidationFailure(
            string message,
            string? code,
            string? field,
            IReadOnlyList<string>? suggestions,
            IReadOnlyDictionary<string, object>? metadata,
            ValidationSeverity severity)
        {
            this.Message = message;
            this.Code = code;
            this.Field = field;
            this.Suggestions = suggestions;
            this.Metadata = metadata;
            this.Severity = severity;
        }

        /// <summary>
        /// Gets the human-readable validation failure message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the machine-readable validation code.
        /// </summary>
        public string? Code { get; }

        /// <summary>
        /// Gets the field or logical member associated with the validation failure.
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
        /// Gets the severity associated with the validation failure.
        /// </summary>
        public ValidationSeverity Severity { get; }

        /// <summary>
        /// Creates a validation failure with error severity.
        /// </summary>
        /// <param name="message">The failure message.</param>
        /// <param name="code">An optional error code.</param>
        /// <param name="field">An optional field associated with the failure.</param>
        /// <param name="suggestions">Optional suggestions for resolving the failure.</param>
        /// <param name="metadata">Optional metadata associated with the failure.</param>
        /// <returns>A <see cref="ValidationFailure"/> with error severity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        public static ValidationFailure Error(
            string message,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null)
        {
            ArgumentNullException.ThrowIfNull(message);

            return new ValidationFailure(
                message,
                code,
                field,
                suggestions is null ? null : new ReadOnlyCollection<string>(suggestions.ToArray()),
                metadata is null ? null : new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(metadata)),
                ValidationSeverity.Error);
        }

        /// <summary>
        /// Creates a validation failure with warning severity.
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="code">An optional warning code.</param>
        /// <param name="field">An optional field associated with the warning.</param>
        /// <param name="suggestions">Optional suggestions for resolving the warning.</param>
        /// <param name="metadata">Optional metadata associated with the warning.</param>
        /// <returns>A <see cref="ValidationFailure"/> with warning severity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        public static ValidationFailure Warning(
            string message,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null)
        {
            ArgumentNullException.ThrowIfNull(message);

            return new ValidationFailure(
                message,
                code,
                field,
                suggestions is null ? null : new ReadOnlyCollection<string>(suggestions.ToArray()),
                metadata is null ? null : new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(metadata)),
                ValidationSeverity.Warning);
        }

        /// <summary>
        /// Creates a validation failure with the specified severity.
        /// </summary>
        /// <param name="message">The failure message.</param>
        /// <param name="severity">The failure severity.</param>
        /// <param name="code">An optional error code.</param>
        /// <param name="field">An optional field associated with the failure.</param>
        /// <param name="suggestions">Optional suggestions for resolving the failure.</param>
        /// <param name="metadata">Optional metadata associated with the failure.</param>
        /// <returns>A <see cref="ValidationFailure"/> with the specified severity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        public static ValidationFailure Create(
            string message,
            ValidationSeverity severity,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null)
        {
            ArgumentNullException.ThrowIfNull(message);

            return new ValidationFailure(
                message,
                code,
                field,
                suggestions is null ? null : new ReadOnlyCollection<string>(suggestions.ToArray()),
                metadata is null ? null : new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(metadata)),
                severity);
        }

        /// <summary>
        /// Creates a copy of the current failure with updated values.
        /// </summary>
        /// <param name="message">An optional message override.</param>
        /// <param name="code">An optional code override.</param>
        /// <param name="field">An optional field override.</param>
        /// <param name="suggestions">An optional suggestions override.</param>
        /// <param name="metadata">An optional metadata override.</param>
        /// <param name="severity">An optional severity override.</param>
        /// <returns>A new <see cref="ValidationFailure"/> with the updated values.</returns>
        public ValidationFailure With(
            string? message = null,
            string? code = null,
            string? field = null,
            IEnumerable<string>? suggestions = null,
            IDictionary<string, object>? metadata = null,
            ValidationSeverity? severity = null)
        {
            return new ValidationFailure(
                message ?? this.Message,
                code ?? this.Code,
                field ?? this.Field,
                suggestions is null ? this.Suggestions : new ReadOnlyCollection<string>(suggestions.ToArray()),
                metadata is null ? this.Metadata : new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(metadata)),
                severity ?? this.Severity);
        }
    }
}
