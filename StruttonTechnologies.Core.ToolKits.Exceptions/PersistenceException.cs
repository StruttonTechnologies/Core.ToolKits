namespace StruttonTechnologies.Core.ToolKit.Exceptions
{
    /// <summary>
    /// Represents an error that occurred while persisting or retrieving data.
    /// </summary>
    public class PersistenceException : Exception
    {
        public PersistenceException()
        {
        }

        public PersistenceException(string message)
            : base(message)
        {
        }

        public PersistenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
