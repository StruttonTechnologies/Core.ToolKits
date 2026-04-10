namespace StruttonTechnologies.Core.ToolKit.Logging.Helpers
{
    /// <summary>
    /// Builds dictionaries for structured logging scopes.
    /// </summary>
    public static class LogScopeBuilder
    {
        /// <summary>
        /// Creates a scope dictionary from the provided values.
        /// </summary>
        /// <param name="values">The scope values.</param>
        /// <returns>A scope dictionary suitable for <c>BeginScope</c>.</returns>
        public static IReadOnlyDictionary<string, object?> Create(params (string Key, object? Value)[] values)
        {
            ArgumentNullException.ThrowIfNull(values);

            Dictionary<string, object?> dictionary = [with(StringComparer.Ordinal)];
            foreach ((string? key, object? value) in values)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    continue;
                }

                dictionary[key] = value;
            }

            return dictionary;
        }
    }
}
