namespace StruttonTechnologies.Core.ToolKit.Exceptions
{
    /// <summary>
    /// Represents an application-level exception within the Strutton toolkit ecosystem.
    /// </summary>
    public class CustomApplicationException : Exception
    {
        public CustomApplicationException()
        {
        }

        public CustomApplicationException(string message)
            : base(message)
        {
        }

        public CustomApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
