namespace StruttonTechnologies.Core.ToolKit.Exceptions
{
    /// <summary>
    /// Thrown when an expected entity cannot be found.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
