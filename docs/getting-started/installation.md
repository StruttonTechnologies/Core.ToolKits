# Installation

[Home](../../README.md) > [Documentation](../README.md) > Getting Started > Installation

Install only the packages required by the application or library you are building.

---

## Common Starting Packages

```bash
dotnet add package StruttonTechnologies.Core.ToolKit.GuardKit
dotnet add package StruttonTechnologies.Core.ToolKit.Validation
dotnet add package StruttonTechnologies.Core.ToolKit.Exceptions
```

For applications using paging:

```bash
dotnet add package StruttonTechnologies.Core.ToolKit.Pagination
```

For Entity Framework Core query paging:

```bash
dotnet add package StruttonTechnologies.Core.ToolKit.Pagination.EntityFramework
```

For modular application startup:

```bash
dotnet add package StruttonTechnologies.Core.ToolKit.Composition
dotnet add package StruttonTechnologies.Core.ToolKit.Registration
```

---

## Recommended Package Selection

| Scenario | Packages |
|---|---|
| DTO/request validation | Validation, Exceptions |
| Domain invariant checks | GuardKit, Exceptions |
| API list endpoints | Pagination |
| EF Core list endpoints | Pagination, Pagination.EntityFramework |
| Modular monolith startup | Composition, Registration |
| Testable date/time logic | Time |
| Consistent diagnostics | Logging |

---

← Previous: [Documentation Home](../README.md)

Next: [Quick Start](quick-start.md) →
