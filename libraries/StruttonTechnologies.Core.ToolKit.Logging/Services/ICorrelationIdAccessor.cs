namespace StruttonTechnologies.Core.ToolKit.Logging.Services
{
    /// <summary>
    /// Provides access to the current correlation identifier.
    /// </summary>
    public interface ICorrelationIdAccessor
    {
        /// <summary>
        /// Gets or sets the current correlation identifier.
        /// </summary>
        string? CorrelationId { get; set; }

        /// <summary>
        /// Gets the current correlation identifier, creating one when absent.
        /// </summary>
        /// <returns>The current correlation identifier.</returns>
        string GetOrCreate();
    }
}
