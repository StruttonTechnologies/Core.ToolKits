# StruttonTechnologies.Core.ToolKit.Logging

Shared logging conventions, structured scope helpers, correlation support, and source-generated logging messages for StruttonTechnologies applications.

## Structure

- `Extensions`
  - `LoggerExtensions`
  - `LoggerFactoryExtensions`
- `Helpers`
  - `LogMessageBuilder`
  - `LogScopeBuilder`
- `Services`
  - `ICorrelationIdAccessor`
  - `CorrelationIdAccessor`
  - `LoggingServiceCollectionExtensions`
- `Utilities`
  - `LoggingCategories`
  - `LoggingEventId`
  - `LoggingEventIds`
  - `LoggingEventRanges`
  - `LogScopeKeys`
- `Startup`
  - `StartupGuardLogs`
- `Diagnostics`
  - `RequestDiagnosticLogs`
  - `CorrelationDiagnosticLogs`
  - `ExceptionLogs`
- `Validation`
  - `ValidationLogs`

## Features

- Shared logger categories
- Recommended event ID ranges
- Well-known event IDs for toolkit log messages
- Reusable structured scope helpers
- Async-flow correlation ID storage
- DI registration for correlation support
- Source-generated logging methods for startup, diagnostics, validation, and exceptions

## Example Registration

```csharp
builder.Services.AddToolkitLogging();
```

## Example Usage

```csharp
using StruttonTechnologies.Core.ToolKit.Logging.Diagnostics;
using StruttonTechnologies.Core.ToolKit.Logging.Extensions;
using StruttonTechnologies.Core.ToolKit.Logging.Services;
using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

var logger = loggerFactory.CreateToolkitLogger(LoggingCategories.Diagnostics);
var correlationId = correlationIdAccessor.GetOrCreate();

using (logger.BeginCorrelationScope(correlationId))
using (logger.BeginOperationScope("UserLogin"))
{
    CorrelationDiagnosticLogs.CorrelationAssigned(logger, correlationId);
    CorrelationDiagnosticLogs.OperationStarted(logger, "UserLogin");

    try
    {
        RequestDiagnosticLogs.ProcessingRequest(logger, "LoginCommand");
        RequestDiagnosticLogs.CompletedRequest(logger, "LoginCommand");
        CorrelationDiagnosticLogs.OperationCompleted(logger, "UserLogin");
    }
    catch (Exception ex)
    {
        ExceptionLogs.ExceptionOccurred(logger, "UserLogin", ex);
        throw;
    }
}
```
