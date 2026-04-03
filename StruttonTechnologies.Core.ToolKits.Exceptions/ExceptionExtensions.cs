namespace StruttonTechnologies.Core.ToolKits.Exceptions
{
    /// <summary>
    /// Provides extension helpers for traversing and flattening exception trees.
    /// </summary>
    public static class ExceptionExtensions
    {
        public static Exception GetInnermostException(this Exception exception)
        {
            ArgumentNullException.ThrowIfNull(exception);

            while (exception.InnerException is not null)
            {
                exception = exception.InnerException;
            }

            return exception;
        }

        public static string GetInnermostMessage(this Exception exception) =>
            exception.GetInnermostException().Message;

        public static IReadOnlyList<string> FlattenMessages(this Exception exception)
        {
            ArgumentNullException.ThrowIfNull(exception);

            List<string> messages = new();
            Exception? current = exception;

            while (current is not null)
            {
                if (!string.IsNullOrWhiteSpace(current.Message))
                {
                    messages.Add(current.Message);
                }

                current = current.InnerException;
            }

            return messages;
        }
    }
}
