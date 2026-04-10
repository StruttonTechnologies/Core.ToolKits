namespace StruttonTechnologies.Core.ToolKit.Logging.Utilities;

/// <summary>
/// Defines suggested event identifier ranges for common application areas.
/// </summary>
public static class LoggingEventIds
{
    public const int StartupMinimum = 1000;
    public const int StartupMaximum = 1099;

    public const int ValidationMinimum = 1100;
    public const int ValidationMaximum = 1199;

    public const int AuthenticationMinimum = 1200;
    public const int AuthenticationMaximum = 1299;

    public const int AuthorizationMinimum = 1300;
    public const int AuthorizationMaximum = 1399;

    public const int DataAccessMinimum = 1400;
    public const int DataAccessMaximum = 1499;

    public const int InfrastructureMinimum = 1500;
    public const int InfrastructureMaximum = 1599;

    public const int DiagnosticsMinimum = 1600;
    public const int DiagnosticsMaximum = 1699;
}
