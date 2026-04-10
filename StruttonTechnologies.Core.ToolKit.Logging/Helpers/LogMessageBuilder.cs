namespace StruttonTechnologies.Core.ToolKit.Logging.Helpers;

/// <summary>
/// Builds small, consistent diagnostic message fragments.
/// </summary>
public static class LogMessageBuilder
{
    /// <summary>
    /// Creates a missing configuration message.
    /// </summary>
    /// <param name="configurationName">The configuration item name.</param>
    /// <returns>A formatted message.</returns>
    public static string MissingConfiguration(string configurationName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(configurationName);
        return $"Missing configuration value: '{configurationName}'.";
    }

    /// <summary>
    /// Creates a configuration found message.
    /// </summary>
    /// <param name="configurationName">The configuration item name.</param>
    /// <returns>A formatted message.</returns>
    public static string ConfigurationFound(string configurationName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(configurationName);
        return $"Configuration check passed: '{configurationName}' found.";
    }
}
