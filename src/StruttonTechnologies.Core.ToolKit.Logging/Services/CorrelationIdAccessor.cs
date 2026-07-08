namespace StruttonTechnologies.Core.ToolKit.Logging.Services
{
    /// <summary>
    /// Stores a correlation identifier in the current asynchronous context.
    /// </summary>
    public sealed class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        private static readonly AsyncLocal<string?> CurrentCorrelationId = new();

        /// <inheritdoc/>
        public string? CorrelationId
        {
            get => CurrentCorrelationId.Value;
            set => CurrentCorrelationId.Value = value;
        }

        /// <inheritdoc/>
        public string GetOrCreate()
        {
            if (!string.IsNullOrWhiteSpace(this.CorrelationId))
            {
                return this.CorrelationId!;
            }

            this.CorrelationId = Guid.NewGuid().ToString("N");
            return this.CorrelationId;
        }
    }
}
