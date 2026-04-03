namespace StruttonTechnologies.Core.ToolKits.Exceptions
{
    /// <summary>
    /// Represents an error caused by a conflict with the current state of the target resource.
    /// </summary>
    public class ConflictException : Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message)
            : base(message)
        {
        }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
