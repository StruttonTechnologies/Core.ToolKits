# Core.ToolKits

Reusable toolkit packages for the Strutton Technologies engineering ecosystem.

## Repository Layout

```text
Core.ToolKits
│
├── src
│   ├── StruttonTechnologies.Core.ToolKit.Composition
│   ├── StruttonTechnologies.Core.ToolKit.GuardKit
│   ├── StruttonTechnologies.Core.ToolKit.Logging
│   ├── StruttonTechnologies.Core.ToolKit.Pagination
│   ├── StruttonTechnologies.Core.ToolKit.Pagination.Dtos
│   ├── StruttonTechnologies.Core.ToolKit.Pagination.EF
│   ├── StruttonTechnologies.Core.ToolKit.Registration
│   ├── StruttonTechnologies.Core.ToolKit.Time
│   ├── StruttonTechnologies.Core.ToolKit.Validation
│   └── StruttonTechnologies.Core.Toolkit.Exceptions
│
└── tests
    ├── StruttonTechnologies.Core.ToolKits.UnitTests
    └── StruttonTechnologies.Core.ToolKits.FunctionalTests
```

Production packages live under `src`. Automated tests live under `tests`.

## Design Intent

Toolkits provide reusable implementation support for higher-level Core capabilities and applications. Each package should remain focused, independently consumable, and dependency-conscious.

Toolkits are not application features. They provide reusable capabilities such as validation, guard clauses, logging helpers, time abstractions, pagination helpers, registration utilities, and shared exception types.

## Composition

`StruttonTechnologies.Core.ToolKit.Composition` provides the public composition facade for registering toolkit services.

Consumers that want the standard toolkit registration set should call:

```csharp
services.AddStruttonTechnologiesToolKit(configuration);
```

The composition facade registers runtime services from the toolkit packages that expose them and calls no-op registration hooks for toolkit packages that intentionally have no runtime services today.

See `REGISTRATION_AUDIT.md` for the current package-by-package registration status.

## Rules and Validation

Universal concept rules belong in `StruttonTechnologies.Core.Rules` in the Foundation solution.

Validation toolkit validators may depend on those rules to report failures consistently without duplicating rule logic.

```text
Rules
    = what is universally true about a concept

Validation
    = how validation failures are reported
```

## Testing Structure

Core.ToolKits uses separate test projects by test responsibility.

```text
Core.ToolKits
│
├── src
│   └── toolkit capability projects
│
└── tests
    ├── StruttonTechnologies.Core.ToolKits.UnitTests
    └── StruttonTechnologies.Core.ToolKits.FunctionalTests
```

### Unit Tests

Unit tests cover behavior inside individual toolkit capabilities, including guard evaluators, validation models and validators, pagination behavior, time utilities, logging helpers, registration helpers, and exception helpers.

### Functional Tests

Functional tests cover cross-package behavior, such as the composition facade registering services from multiple toolkit packages together.

### Coverage Guidance

Projects that contain behavior should have unit coverage. Projects that contain only constants, marker types, records without behavior, DTOs, exceptions without custom behavior, or static extension-only helpers do not require dedicated tests until behavior is introduced.

## Build Notes

This solution uses Central Package Management through `Directory.Packages.props`.

Package references should not include versions in individual project files unless there is a deliberate exception.
