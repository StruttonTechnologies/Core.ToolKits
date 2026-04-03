namespace StruttonTechnologies.Core.ToolKit.Testing.Assertions;

/// <summary>
/// Assertion helpers for exception verification.
/// </summary>
public static class ExceptionAssert
{
    public static TException ThrowsWithMessage<TException>(Action action, string expectedMessageFragment)
        where TException : Exception
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentException.ThrowIfNullOrWhiteSpace(expectedMessageFragment);

        TException exception = Xunit.Assert.Throws<TException>(action);
        Xunit.Assert.Contains(expectedMessageFragment, exception.Message, StringComparison.Ordinal);
        return exception;
    }

    public static async Task<TException> ThrowsWithMessageAsync<TException>(
        Func<Task> action,
        string expectedMessageFragment)
        where TException : Exception
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentException.ThrowIfNullOrWhiteSpace(expectedMessageFragment);

        TException exception = await Xunit.Assert.ThrowsAsync<TException>(action);
        Xunit.Assert.Contains(expectedMessageFragment, exception.Message, StringComparison.Ordinal);
        return exception;
    }
}
