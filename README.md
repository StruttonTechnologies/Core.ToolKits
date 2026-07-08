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
    ├── StruttonTechnologies.Core.ToolKit.Tests
    └── StruttonTechnologies.Core.ToolKits.Tests
```

Production packages live under `src`. Automated tests live under `tests`.

## Design Intent

Toolkits provide reusable implementation support for higher-level Core capabilities and applications. Each package should remain focused, independently consumable, and dependency-conscious.

## Rules and Validation

Universal concept rules belong in `StruttonTechnologies.Core.Rules` in the Foundation solution. Validation toolkit validators may depend on those rules to report failures consistently without duplicating rule logic.


---

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

Projects that contain behavior should have unit coverage. Projects that contain only constants, marker types, records without behavior, or empty placeholder classes do not require dedicated tests until behavior is introduced.
