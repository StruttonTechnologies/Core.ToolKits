namespace StruttonTechnologies.Core.ToolKit.Testing.Utilities;

/// <summary>
/// Helpers for awaiting and timing asynchronous test operations.
/// </summary>
public static class TaskTestHelper
{
    public static async Task<T> WaitAsync<T>(Task<T> task, TimeSpan timeout)
    {
        ArgumentNullException.ThrowIfNull(task);

        using CancellationTokenSource cancellationSource = new(timeout);
        return await task.WaitAsync(cancellationSource.Token);
    }

    public static async Task WaitAsync(Task task, TimeSpan timeout)
    {
        ArgumentNullException.ThrowIfNull(task);

        using CancellationTokenSource cancellationSource = new(timeout);
        await task.WaitAsync(cancellationSource.Token);
    }
}
