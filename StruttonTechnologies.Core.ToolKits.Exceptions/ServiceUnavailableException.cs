namespace StruttonTechnologies.Core.ToolKits.Exceptions
{
    /// <summary>
    /// Thrown when a dependent service is unavailable.
    /// </summary>
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException()
        {
        }

        public ServiceUnavailableException(string message)
            : base(message)
        {
        }

        public ServiceUnavailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
