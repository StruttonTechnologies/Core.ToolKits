# Core.ToolKit Reference

Reusable engineering utilities for building consistent, maintainable, and architecture-aligned .NET applications.

These NuGet packages provide tested, production-ready solutions for common cross-cutting concerns such as guard logic, validation, logging infrastructure, service registration, exception handling, and time-based operations.

---

## 📦 Available Packages

| Package | Purpose |
|---------|---------|
| `StruttonTechnologies.Core.ToolKit.GuardKit` | Fluent guard and continuation framework for defensive programming |
| `StruttonTechnologies.Core.ToolKit.Validation` | Validation abstractions, validators, and result models |
| `StruttonTechnologies.Core.ToolKit.Logging` | Structured logging conventions and source-generated log messages |
| `StruttonTechnologies.Core.ToolKit.Registration` | Service collection composition and dependency registration utilities |
| `StruttonTechnologies.Core.ToolKit.Exceptions` | Standard exception types for application-level error handling |
| `StruttonTechnologies.Core.ToolKit.Time` | Clock abstractions, date utilities, and business-day calculations |

---

## 🛡️ GuardKit

**Package:** `StruttonTechnologies.Core.ToolKit.GuardKit`  
**Namespace:** `StruttonTechnologies.Core.ToolKit.GuardKit`

A fluent guard and continuation framework that separates evaluation logic from continuation behavior.

### Core Pattern

```csharp
Guard.{Evaluator}(value)
     .{Behavior}(...)
```

### Evaluators

#### General Evaluators

| Method | Description |
|--------|-------------|
| `IsNull<T>(T? value)` | Evaluates whether the value is null |
| `IsNotNull<T>(T? value)` | Evaluates whether the value is not null |
| `IsDefault<T>(T value)` | Evaluates whether the value is the default value for its type |
| `IsNotDefault<T>(T value)` | Evaluates whether the value is not the default value |
| `IsTrue(bool value)` | Evaluates whether the boolean is true |
| `IsFalse(bool value)` | Evaluates whether the boolean is false |

#### String Evaluators

| Method | Description |
|--------|-------------|
| `IsNullOrEmpty(string? value)` | Evaluates whether the string is null or empty |
| `IsNullOrWhiteSpace(string? value)` | Evaluates whether the string is null, empty, or whitespace |
| `IsEmpty(string? value)` | Evaluates whether the string is empty (but not null) |
| `IsWhiteSpace(string? value)` | Evaluates whether the string consists only of whitespace |
| `HasValue(string? value)` | Evaluates whether the string has a non-whitespace value |

#### Numeric Evaluators

| Method | Description |
|--------|-------------|
| `IsZero(numeric value)` | Evaluates whether the numeric value is zero |
| `IsNotZero(numeric value)` | Evaluates whether the numeric value is not zero |
| `IsPositive(numeric value)` | Evaluates whether the numeric value is greater than zero |
| `IsNegative(numeric value)` | Evaluates whether the numeric value is less than zero |
| `IsGreaterThan(numeric value, numeric threshold)` | Evaluates whether the value is greater than the threshold |
| `IsGreaterThanOrEqual(numeric value, numeric threshold)` | Evaluates whether the value is greater than or equal to the threshold |
| `IsLessThan(numeric value, numeric threshold)` | Evaluates whether the value is less than the threshold |
| `IsLessThanOrEqual(numeric value, numeric threshold)` | Evaluates whether the value is less than or equal to the threshold |

#### Collection Evaluators

| Method | Description |
|--------|-------------|
| `IsEmpty<T>(IEnumerable<T>? collection)` | Evaluates whether the collection is empty or null |
| `HasItems<T>(IEnumerable<T>? collection)` | Evaluates whether the collection contains items |

#### Equality Evaluators

| Method | Description |
|--------|-------------|
| `IsEqual<T>(T? value, T? other)` | Evaluates whether two values are equal |
| `IsNotEqual<T>(T? value, T? other)` | Evaluates whether two values are not equal |

#### Type Evaluators

| Method | Description |
|--------|-------------|
| `IsType<T>(object? value)` | Evaluates whether the value is of the specified type |
| `IsNotType<T>(object? value)` | Evaluates whether the value is not of the specified type |

### Selector Support

Most evaluators support property selectors to evaluate nested values:

```csharp
Guard.IsNull(user, u => u.Email)
     .ReturnEmptyArray(u => GetUserLogins(u));
```

### Behaviors (Continuations)

#### Return Behaviors

| Method | Description |
|--------|-------------|
| `Return<TResult>(TResult matched, Func<T, TResult> notMatched)` | Returns a value when matched, otherwise invokes factory |
| `Return<TResult>(Func<TResult> matched, Func<T, TResult> notMatched)` | Returns result from matched or not-matched factory |
| `ReturnAsync<TResult>(...)` | Async version of Return |
| `ReturnNull<TResult>()` | Returns null when matched |
| `ReturnNull<TResult>(Func<T, TResult?> notMatched)` | Returns null when matched, otherwise invokes factory |
| `ReturnDefault<TResult>()` | Returns default value when matched |
| `ReturnDefault<TResult>(Func<T, TResult> notMatched)` | Returns default when matched, otherwise invokes factory |

#### Collection Return Behaviors

| Method | Description |
|--------|-------------|
| `ReturnEmptyArray<TResult>()` | Returns empty array when matched |
| `ReturnEmptyArray<TResult>(Func<T, TResult[]> notMatched)` | Returns empty array when matched, otherwise invokes factory |
| `ReturnEmptyArrayAsync<TResult>(Func<T, Task<TResult[]>> notMatched)` | Async version returning empty array or invoking factory |
| `ReturnEmptyList<TResult>()` | Returns empty list when matched |
| `ReturnEmptyList<TResult>(Func<T, List<TResult>> notMatched)` | Returns empty list when matched, otherwise invokes factory |
| `ReturnEmptyEnumerable<TResult>()` | Returns empty enumerable when matched |
| `ReturnEmptyEnumerable<TResult>(Func<T, IEnumerable<TResult>> notMatched)` | Returns empty enumerable when matched, otherwise invokes factory |

#### Exception Behaviors

| Method | Description |
|--------|-------------|
| `ReturnOrThrow(Func<Exception> exceptionFactory)` | Throws exception when matched, otherwise returns value |
| `ReturnOrThrow<TResult>(Func<Exception> exceptionFactory, Func<T, TResult> notMatched)` | Throws when matched, otherwise invokes factory |
| `ReturnOrThrowAsync<TResult>(...)` | Async version throwing or invoking factory |

#### Action Behaviors

| Method | Description |
|--------|-------------|
| `Do(Action<T> action)` | Executes action with value when matched |
| `Do(Action action)` | Executes action when matched |
| `DoAsync(Func<T, Task> action)` | Executes async action with value when matched |
| `DoAsync(Func<Task> action)` | Executes async action when matched |

#### Validation Behaviors

| Method | Description |
|--------|-------------|
| `ReturnValidation(ValidationResult matched)` | Returns validation result when matched |
| `ReturnValidation(ValidationResult matched, Func<T, ValidationResult> notMatched)` | Returns validation based on match |

### Usage Examples

#### Defensive null check with early return

```csharp
return await Guard.IsNull(user)
    .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));
```

#### Throw exception or continue

```csharp
var validUser = Guard.IsNull(user)
    .ReturnOrThrow(() => new EntityNotFoundException("User not found"));
```

#### Execute side effect only when matched

```csharp
Guard.IsNotNull(cachedData)
    .Do(data => _logger.LogInformation("Using cached data"));
```

#### Nested property evaluation

```csharp
return Guard.IsNullOrWhiteSpace(user, u => u.Email)
    .Return(
        Array.Empty<string>(),
        u => GetEmailDomains(u.Email));
```

---

## ✅ Validation

**Package:** `StruttonTechnologies.Core.ToolKit.Validation`  
**Namespace:** `StruttonTechnologies.Core.ToolKit.Validation`

Validation framework providing reusable validators, validation results, and composition support.

### Core Abstractions

#### IValidator&lt;T&gt;

```csharp
public interface IValidator<in T>
{
    ValidationResult Validate(T input);
}
```

### ValidationResult

Rich validation result with multiple levels of detail:

```csharp
public sealed class ValidationResult
{
    public bool IsValid { get; }
    public string? Message { get; }
    public string? Code { get; }
    public string? Field { get; }
    public IReadOnlyList<string>? Suggestions { get; }
    public IReadOnlyDictionary<string, object>? Metadata { get; }
    public Exception? Exception { get; }
    public string? TraceId { get; }
    public ValidationSeverity Severity { get; }
    
    // Factory methods
    public static ValidationResult Success(string? message = null);
    public static ValidationResult Warning(string message, ...);
    public static ValidationResult Failure(string message, ...);
}
```

### ValidationSeverity

| Value | Description |
|-------|-------------|
| `Info` | Informational validation result |
| `Warning` | Non-critical validation issue |
| `Error` | Validation failure |
| `Critical` | Critical validation failure |

### Built-in Validators

#### Format Validators

| Validator | Description |
|-----------|-------------|
| `EmailFormatValidator` | Validates email addresses using regex |
| `PhoneNumberFormatValidator` | Validates phone numbers |
| `UsZipCodeFormatValidator` | Validates US zip codes (5-digit and ZIP+4) |
| `BlacklistPhoneValidator` | Validates phone against blacklist |

#### Common Validators

| Validator | Description |
|-----------|-------------|
| `RegexValidator` | Validates strings against custom regex patterns |
| `IdValidator` | Validates identifier values |
| `NotDefaultValidator<T>` | Ensures value is not the default for its type |

#### Contact Validators

| Validator | Description |
|-----------|-------------|
| `WhitelistEmailValidator` | Validates email against allowed domains |

#### Composite Validator

```csharp
var compositeValidator = new CompositeValidator<string>(
[
    new EmailFormatValidator(),
    new WhitelistEmailValidator(allowedDomains)
]);

ValidationResult result = compositeValidator.Validate(email);
```

Executes validators in sequence and returns the first failure.

### Extensions

#### ValidationResultExtensions

Extension methods for working with `ValidationResult` instances:

```csharp
// Example usage
IEnumerable<ValidationResult> results = GetValidationResults();
bool allValid = results.AllValid();
var failures = results.GetFailures();
```

### Usage Examples

#### Single validator

```csharp
var validator = new EmailFormatValidator();
ValidationResult result = validator.Validate("user@example.com");

if (!result.IsValid)
{
    Console.WriteLine($"{result.Code}: {result.Message}");
}
```

#### Composite validation

```csharp
var validators = new IValidator<string>[]
{
    new EmailFormatValidator(),
    new WhitelistEmailValidator(new[] { "example.com", "test.com" })
};

var composite = new CompositeValidator<string>(validators);
ValidationResult result = composite.Validate("user@example.com");
```

---

## 📋 Logging

**Package:** `StruttonTechnologies.Core.ToolKit.Logging`  
**Namespace:** `StruttonTechnologies.Core.ToolKit.Logging`

Structured logging conventions, correlation support, and source-generated log messages for consistent application logging.

### Features

- Shared logger categories
- Recommended event ID ranges
- Well-known event IDs for toolkit log messages
- Reusable structured scope helpers
- Async-flow correlation ID storage
- DI registration for correlation support
- Source-generated logging methods

### Services

#### ICorrelationIdAccessor

```csharp
public interface ICorrelationIdAccessor
{
    string? CorrelationId { get; }
    void SetCorrelationId(string correlationId);
}
```

Provides async-local storage for correlation IDs that flow through async operations.

### Utilities

| Class | Description |
|-------|-------------|
| `LoggingCategories` | Well-known category names for logger creation |
| `LoggingEventId` | Event ID factory methods |
| `LoggingEventIds` | Pre-defined event IDs for toolkit messages |
| `LoggingEventRanges` | Recommended event ID ranges by category |
| `LogScopeKeys` | Well-known scope key names |

### Helpers

| Class | Description |
|-------|-------------|
| `LogMessageBuilder` | Fluent builder for structured log messages |
| `LogScopeBuilder` | Fluent builder for structured log scopes |

### Source-Generated Log Messages

Pre-defined logging methods for common scenarios:

- **StartupGuardLogs** - Startup and initialization guards
- **RequestDiagnosticLogs** - HTTP request diagnostics
- **CorrelationDiagnosticLogs** - Correlation tracking
- **ExceptionLogs** - Exception logging
- **ValidationLogs** - Validation result logging

### Registration

```csharp
builder.Services.AddToolkitLogging();
```

Registers `ICorrelationIdAccessor` and related logging services.

### Usage Examples

#### Using correlation accessor

```csharp
public class MyService
{
    private readonly ICorrelationIdAccessor _correlationAccessor;
    private readonly ILogger<MyService> _logger;

    public MyService(ICorrelationIdAccessor correlationAccessor, ILogger<MyService> logger)
    {
        _correlationAccessor = correlationAccessor;
        _logger = logger;
    }

    public void ProcessRequest()
    {
        string correlationId = _correlationAccessor.CorrelationId ?? Guid.NewGuid().ToString();
        _logger.LogInformation("Processing request {CorrelationId}", correlationId);
    }
}
```

#### Using structured scopes

```csharp
using var scope = _logger.BeginScope(
    new Dictionary<string, object>
    {
        [LogScopeKeys.CorrelationId] = correlationId,
        [LogScopeKeys.UserId] = userId
    });

_logger.LogInformation("User action performed");
```

---

## 🔧 Registration

**Package:** `StruttonTechnologies.Core.ToolKit.Registration`  
**Namespace:** `StruttonTechnologies.Core.ToolKit.Registration`

Service collection composition utilities for combining and organizing dependency injection registrations.

### ServiceCollectionComposer

Provides methods for composing multiple `IServiceCollection` instances into a target collection.

#### Composition Behaviors

```csharp
public enum ServiceCompositionBehavior
{
    Append = 0,                      // Add all descriptors
    SkipExistingServiceType = 1,     // Skip if service type exists
    ReplaceExistingServiceType = 2,  // Replace existing service type
    ThrowIfServiceTypeExists = 3     // Throw if service type exists
}
```

#### ServiceCompositionOptions

```csharp
public class ServiceCompositionOptions
{
    public ServiceCompositionBehavior Behavior { get; set; }
}
```

### Methods

```csharp
public static class ServiceCollectionComposer
{
    // Compose single source collection into target
    public static IServiceCollection Compose(
        IServiceCollection target,
        IServiceCollection source,
        ServiceCompositionOptions? options = null);

    // Compose multiple source collections into target
    public static IServiceCollection Compose(
        IServiceCollection target,
        ServiceCompositionOptions? options = null,
        params IServiceCollection[] sources);
}
```

### Usage Examples

#### Append services from multiple modules

```csharp
var services = new ServiceCollection();

ServiceCollectionComposer.Compose(
    target: services,
    sources: [
        AuthenticationModule.Services,
        DatabaseModule.Services,
        ApiModule.Services
    ]);
```

#### Replace existing service types

```csharp
var options = new ServiceCompositionOptions
{
    Behavior = ServiceCompositionBehavior.ReplaceExistingServiceType
};

ServiceCollectionComposer.Compose(
    target: services,
    source: overrideServices,
    options: options);
```

#### Enforce unique service types

```csharp
var options = new ServiceCompositionOptions
{
    Behavior = ServiceCompositionBehavior.ThrowIfServiceTypeExists
};

// Throws if duplicate service type found
ServiceCollectionComposer.Compose(target, source, options);
```

---

## ⚠️ Exceptions

**Package:** `StruttonTechnologies.Core.ToolKit.Exceptions`  
**Namespace:** `StruttonTechnologies.Core.ToolKit.Exceptions`

Standard exception types for application-level error handling and domain-specific error scenarios.

### Exception Types

| Exception | Description | Use Case |
|-----------|-------------|----------|
| `CustomApplicationException` | Base application exception | General application-level errors |
| `EntityNotFoundException` | Entity not found | Requested entity does not exist |
| `ValidationException` | Validation failure | Input validation errors |
| `ConflictException` | Resource conflict | Concurrent modification conflicts |
| `ConcurrencyConflictException` | Concurrency violation | Optimistic concurrency failures |
| `DatabaseException` | Database operation failure | Database errors |
| `PersistenceException` | Persistence failure | Data persistence errors |
| `ServiceUnavailableException` | Service unavailable | External service unavailable |

### ExceptionExtensions

Extension methods for working with exceptions:

```csharp
public static class ExceptionExtensions
{
    // Example methods available
    // (check source for complete list)
}
```

### Usage Examples

#### Throw domain-specific exception

```csharp
public User GetUser(int userId)
{
    var user = _repository.FindById(userId);
    
    if (user == null)
    {
        throw new EntityNotFoundException($"User with ID {userId} not found.");
    }
    
    return user;
}
```

#### Handle concurrency conflicts

```csharp
try
{
    await _repository.UpdateAsync(entity);
}
catch (DbUpdateConcurrencyException ex)
{
    throw new ConcurrencyConflictException(
        "The entity was modified by another user.", ex);
}
```

---

## ⏰ Time

**Package:** `StruttonTechnologies.Core.ToolKit.Time`  
**Namespace:** `StruttonTechnologies.Core.ToolKit.Time`

Clock abstractions, date utilities, business-day calculations, and time-based operation support for testable time-dependent code.

### Abstractions

#### IClock

```csharp
public interface IClock
{
    DateTime UtcNow { get; }
    DateTimeOffset UtcNowOffset { get; }
}
```

Makes time-dependent code testable by abstracting the current time.

### Implementations

| Class | Description |
|-------|-------------|
| `SystemClock` | Returns actual system time (`DateTime.UtcNow`) |
| `FakeClock` | Controllable clock for testing |

### Models

#### DateRange

```csharp
public readonly record struct DateRange
{
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public TimeSpan Duration { get; }
    
    public bool Contains(DateTime value);
    public bool Overlaps(DateRange other);
    public DateRange? Intersect(DateRange other);
    public static IReadOnlyList<DateRange> MergeOverlaps(IEnumerable<DateRange> ranges);
}
```

Represents an inclusive start / exclusive end date range with overlap and intersection operations.

### Utilities

#### BusinessDayCalculator

```csharp
public sealed class BusinessDayCalculator
{
    public BusinessDayCalculator(
        IEnumerable<DayOfWeek>? weekendDays = null,
        IEnumerable<DateOnly>? holidays = null);
    
    public bool IsBusinessDay(DateTime date);
    public DateTime NextBusinessDay(DateTime date);
    public DateTime PreviousBusinessDay(DateTime date);
    public int CountBusinessDays(DateTime startInclusive, DateTime endInclusive);
    public DateTime AddBusinessDays(DateTime date, int businessDays);
}
```

Calculates business days with configurable weekends and holidays.

#### RecurrenceGenerator

Generates recurring dates based on patterns.

#### ScheduledTaskTracker

Tracks scheduled task execution state.

#### TimeStateTracker

Tracks time-based state changes.

### Extensions

#### DateTimeExtensions

Extension methods for `DateTime` operations.

#### TimeZoneExtensions

Extension methods for `TimeZoneInfo` operations.

### Usage Examples

#### Using IClock for testable code

```csharp
public class OrderService
{
    private readonly IClock _clock;

    public OrderService(IClock clock)
    {
        _clock = clock;
    }

    public Order CreateOrder()
    {
        return new Order
        {
            CreatedAt = _clock.UtcNow,
            // ...
        };
    }
}

// In production
services.AddSingleton<IClock, SystemClock>();

// In tests
var fakeClock = new FakeClock(new DateTime(2024, 1, 15, 10, 30, 0, DateTimeKind.Utc));
var service = new OrderService(fakeClock);
```

#### Business day calculations

```csharp
var holidays = new[]
{
    new DateOnly(2024, 1, 1),  // New Year's Day
    new DateOnly(2024, 7, 4),  // Independence Day
    new DateOnly(2024, 12, 25) // Christmas
};

var calculator = new BusinessDayCalculator(holidays: holidays);

var today = new DateTime(2024, 1, 12); // Friday
var nextBusinessDay = calculator.NextBusinessDay(today); // Monday, Jan 15
var isBusinessDay = calculator.IsBusinessDay(today); // true

int businessDays = calculator.CountBusinessDays(
    new DateTime(2024, 1, 1),
    new DateTime(2024, 1, 31));
```

#### Date range operations

```csharp
var range1 = new DateRange(
    new DateTime(2024, 1, 1),
    new DateTime(2024, 1, 15));

var range2 = new DateRange(
    new DateTime(2024, 1, 10),
    new DateTime(2024, 1, 20));

bool overlaps = range1.Overlaps(range2); // true
DateRange? intersection = range1.Intersect(range2); // Jan 10 - Jan 15
bool contains = range1.Contains(new DateTime(2024, 1, 5)); // true
```

---

## 🎯 Design Principles

These toolkits follow these design principles:

1. **Minimal Abstraction** - Only abstract what needs to vary
2. **Explicit Behavior** - Clear naming and intent
3. **Composability** - Components work well together
4. **Testability** - Easy to test and mock
5. **No Magic** - Behavior is explicit and discoverable
6. **Architecture Alignment** - Supports clean architecture patterns

---

## 🔄 Integration Patterns

### Typical Usage in Clean Architecture

```
Domain Layer:
  - Core.ToolKit.Exceptions (domain exceptions)
  - Core.ToolKit.GuardKit (domain guards)

Infrastructure Layer:
  - Core.ToolKit.Time (clock implementations)
  - Core.ToolKit.Logging (logging infrastructure)
  - Core.ToolKit.Validation (validators)

API Layer:
  - Core.ToolKit.GuardKit (input guards)
  - Core.ToolKit.Validation (request validation)
  - Core.ToolKit.Exceptions (exception mapping)

Composition Root:
  - Core.ToolKit.Registration (service composition)
```

---

## 📚 Related Resources

- Repository: [https://github.com/StruttonTechnologies/Core.ToolKits](https://github.com/StruttonTechnologies/Core.ToolKits)
- Issues: [GitHub Issues](https://github.com/StruttonTechnologies/Core.ToolKits/issues)

---

## ⚙️ Package Installation

```xml
<PackageReference Include="StruttonTechnologies.Core.ToolKit.GuardKit" Version="*" />
<PackageReference Include="StruttonTechnologies.Core.ToolKit.Validation" Version="*" />
<PackageReference Include="StruttonTechnologies.Core.ToolKit.Logging" Version="*" />
<PackageReference Include="StruttonTechnologies.Core.ToolKit.Registration" Version="*" />
<PackageReference Include="StruttonTechnologies.Core.ToolKit.Exceptions" Version="*" />
<PackageReference Include="StruttonTechnologies.Core.ToolKit.Time" Version="*" />
```

---

## 🚧 Status

This project is currently in active development. Changes are being made regularly as the architecture and implementation continue to evolve.

---

## 💡 When to Use These Toolkits

### Use GuardKit when:
- You need defensive null checks with continuation behavior
- You want to avoid deeply nested if statements
- You need consistent early-return patterns
- You want to separate evaluation from outcome logic

### Use Validation when:
- You need reusable validation logic
- You want structured validation results
- You need to compose multiple validators
- You want rich validation feedback with codes, fields, and suggestions

### Use Logging when:
- You need structured logging with correlation
- You want consistent log categories and event IDs
- You need correlation ID flow through async operations
- You want source-generated log methods

### Use Registration when:
- You need to compose service collections from multiple modules
- You want explicit control over duplicate service handling
- You're building modular applications
- You need to replace or override service registrations

### Use Exceptions when:
- You need domain-specific exception types
- You want consistent error handling across layers
- You need to distinguish between different error scenarios
- You want exceptions that integrate with logging and diagnostics

### Use Time when:
- You need testable time-dependent code
- You need business day calculations
- You need date range operations
- You want to avoid static DateTime.Now dependencies

---

*This document describes the functionality available in Core.ToolKit NuGet packages for use by AI coding assistants and development teams.*
