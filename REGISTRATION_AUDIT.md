# Core.ToolKits Registration Audit

This audit records which toolkit packages expose runtime services and how they are composed.

## Composition Package

`StruttonTechnologies.Core.ToolKit.Composition` is the public facade for consumers that want the full toolkit registration set.

`AddStruttonTechnologiesToolKit()` now calls:

- `AddGuardKit()`
- `AddToolkitLogging()`
- `AddRegistration()`
- `AddTimeToolkit()`
- `AddValidation()`

## Package Registration Status

| Package | Registration Method | Runtime Services | Notes |
|---|---|---:|---|
| `StruttonTechnologies.Core.ToolKit.GuardKit` | `AddGuardKit()` | No | GuardKit currently exposes static guard/evaluator functionality. The method remains as a stable composition hook. |
| `StruttonTechnologies.Core.ToolKit.Logging` | `AddToolkitLogging()` | Yes | Registers `ICorrelationIdAccessor` as `CorrelationIdAccessor`. |
| `StruttonTechnologies.Core.ToolKit.Registration` | `AddRegistration()` | No | Provides service collection composition utilities. The method remains as a stable composition hook. |
| `StruttonTechnologies.Core.ToolKit.Time` | `AddTimeToolkit()` | Yes | Registers `IClock`, `BusinessDayCalculator`, `ScheduledTaskTracker`, and `TimeStateTracker`. |
| `StruttonTechnologies.Core.ToolKit.Validation` | `AddValidation()` | Yes | Registers common, format, and composite validators that are constructable without runtime configuration. |
| `StruttonTechnologies.Core.ToolKit.Pagination` | None | No | Pagination currently exposes models, value types, and extension methods only. |
| `StruttonTechnologies.Core.ToolKit.Pagination.Dtos` | None | No | DTO/package contract only. |
| `StruttonTechnologies.Core.ToolKit.Pagination.EntityFramework` | None | No | EF pagination behavior is exposed through queryable extension methods. |
| `StruttonTechnologies.Core.ToolKit.Exceptions` | None | No | Exception and error DTO package only. |

## Registration Guidance

Packages that expose runtime services should provide an `Add...()` extension method in a `DependencyInjection` namespace.

Packages that expose only static helpers, DTOs, records, models, exceptions, or extension methods do not need to register services. If a package has no runtime services but participates in the composition facade, it may keep a no-op registration method as a stable composition hook.

Validators that require consumer-specific runtime data, such as regular expression patterns, whitelists, or blacklists, should not be globally registered by default.
