namespace StruttonTechnologies.Core.ToolKit.Exceptions
{
    /// <summary>
    /// Represents errors that occur during database operations.
    /// </summary>
    public class DatabaseException : Exception
    {
        public DatabaseException(string message)
            : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DatabaseException(string message, string entityName, string operation)
            : base(message)
        {
            EntityName = entityName;
            Operation = operation;
        }

        public DatabaseException(string message, string entityName, string operation, Exception innerException)
            : base(message, innerException)
        {
            EntityName = entityName;
            Operation = operation;
        }

        public string EntityName { get; } = string.Empty;

        public string Operation { get; } = string.Empty;
    }
}
