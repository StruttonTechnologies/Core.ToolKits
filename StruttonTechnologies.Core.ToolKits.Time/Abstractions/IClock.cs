namespace StruttonTechnologies.Core.ToolKits.Time.Abstractions
{
    /// <summary>
    /// Represents a time source used to make time-dependent code testable.
    /// </summary>
    public interface IClock
    {
        DateTime UtcNow { get; }

        DateTimeOffset UtcNowOffset => new(UtcNow, TimeSpan.Zero);
    }
}
