namespace StruttonTechnologies.Core.ToolKits.Exceptions
{
    /// <summary>
    /// Represents a persistence conflict caused by concurrent changes.
    /// </summary>
    public sealed class ConcurrencyConflictException : PersistenceException
    {
        public ConcurrencyConflictException()
        {
        }

        public ConcurrencyConflictException(string message)
            : base(message)
        {
        }

        public ConcurrencyConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
