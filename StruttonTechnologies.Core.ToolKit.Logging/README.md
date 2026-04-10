# StruttonTechnologies.Core.ToolKit.Logging

Shared logging conventions, categories, scopes, event ID guidance, and reusable source-generated log message helpers.

## Included

- `LoggingCategories`
- `LogScopeKeys`
- `LoggingEventId`
- `LoggingEventIds`
- `LoggerFactoryExtensions`
- `LoggerExtensions`
- `LogMessageBuilder`
- `Startup.StartupGuardLogs`
- `Diagnostics.RequestDiagnosticLogs`
- `Validation.ValidationLogs`

## Intended Usage

Use this package to centralize logging infrastructure and common patterns.

Keep project-specific log message classes in the owning project unless the message is truly cross-cutting.

## Example

```csharp
var logger = app.Services
    .GetRequiredService<ILoggerFactory>()
    .CreateToolkitLogger(LoggingCategories.StartupValidation);

var connectionStringName = "DefaultConnection";
var connectionString = app.Configuration.GetConnectionString(connectionStringName);

if (string.IsNullOrWhiteSpace(connectionString))
{
    StartupGuardLogs.MissingConnectionString(logger, connectionStringName);
    throw new InvalidOperationException($"Critical configuration missing: {connectionStringName}");
}

StartupGuardLogs.ConnectionStringFound(logger, connectionStringName);
```
