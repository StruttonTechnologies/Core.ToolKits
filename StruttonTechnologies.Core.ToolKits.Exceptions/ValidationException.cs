namespace StruttonTechnologies.Core.ToolKit.Exceptions
{
    /// <summary>
    /// Represents a validation failure containing one or more error messages.
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation errors occurred.")
        {
            ValidationErrors = Array.Empty<string>();
        }

        public ValidationException(string message)
            : base(message)
        {
            ValidationErrors = new[] { message };
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
            ValidationErrors = new[] { message };
        }

        public ValidationException(IEnumerable<string> validationErrors)
            : base("One or more validation errors occurred.")
        {
            ArgumentNullException.ThrowIfNull(validationErrors);
            ValidationErrors = validationErrors.Where(static e => !string.IsNullOrWhiteSpace(e)).ToArray();
        }

        public IReadOnlyList<string> ValidationErrors { get; }
    }
}
