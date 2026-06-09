# Strutton Technologies Core ToolKits

Reusable .NET building blocks for validation, guard clauses, pagination, modular composition, service registration, logging, exception handling, and testable time abstractions.

The Core ToolKits are designed to support clean, consistent application development across Strutton Technologies solutions.

---

## Documentation

Start here:

| Section | Description |
|---|---|
| [Documentation Home](docs/README.md) | Complete documentation navigation |
| [Installation](docs/getting-started/installation.md) | Add the packages to a solution |
| [Quick Start](docs/getting-started/quick-start.md) | Common first-use examples |
| [Toolkit Overview](docs/architecture/toolkit-overview.md) | How the packages fit together |
| [Package Reference](docs/reference/package-reference.md) | Package list and purpose |

---

## Toolkits

| Toolkit | Purpose |
|---|---|
| [GuardKit](docs/toolkits/guardkit/overview.md) | Defensive programming and guard clauses |
| [Validation](docs/toolkits/validation/overview.md) | Validation results, failures, and validator contracts |
| [Pagination](docs/toolkits/pagination/overview.md) | Standardized paging, sorting, and EF Core query support |
| [Composition](docs/toolkits/composition/overview.md) | Modular application composition |
| [Registration](docs/toolkits/registration/overview.md) | Service registration helpers |
| [Time](docs/toolkits/time/overview.md) | Clock abstractions and testable time handling |
| [Logging](docs/toolkits/logging/overview.md) | Structured logging and diagnostics helpers |
| [Exceptions](docs/toolkits/exceptions/overview.md) | Standardized exception types |

---

## Design Goals

- Keep application code clean and intentional.
- Reduce repeated infrastructure code.
- Improve consistency between solutions.
- Support modular monolith and Clean Architecture patterns.
- Make validation, paging, registration, and time handling easier to test.


---

## Repository Layout

```text
Core.ToolKits
├── README.md
├── docs/
├── libraries/
│   └── StruttonTechnologies.Core.ToolKit.*
├── tests/
│   └── StruttonTechnologies.Core.ToolKit*.Tests
├── Directory.Build.props
├── Directory.Build.targets
└── Directory.Packages.props
```

- `libraries/` contains the reusable NuGet/library projects.
- `tests/` contains test projects.
- `docs/` contains GitHub-friendly documentation pages.
