namespace StruttonTechnologies.Core.ToolKit.Logging.Utilities
{
    /// <summary>
    /// Defines well-known event identifiers for shared toolkit log messages.
    /// </summary>
    public static class LoggingEventIds
    {
        public const int MissingConnectionString = LoggingEventRanges.StartupMinimum;
        public const int ConnectionStringFound = LoggingEventRanges.StartupMinimum + 1;

        public const int ValidationFailed = LoggingEventRanges.ValidationMinimum;
        public const int ValidationPassed = LoggingEventRanges.ValidationMinimum + 1;

        public const int ProcessingRequest = LoggingEventRanges.DiagnosticsMinimum;
        public const int CompletedRequest = LoggingEventRanges.DiagnosticsMinimum + 1;
        public const int CorrelationAssigned = LoggingEventRanges.DiagnosticsMinimum + 2;
        public const int OperationStarted = LoggingEventRanges.DiagnosticsMinimum + 3;
        public const int OperationCompleted = LoggingEventRanges.DiagnosticsMinimum + 4;

        public const int ExceptionLogged = LoggingEventRanges.ExceptionsMinimum;
    }
}
