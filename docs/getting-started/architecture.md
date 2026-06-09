# Getting Started Architecture

[Home](../../README.md) > [Documentation](../README.md) > Getting Started > Architecture

The Core ToolKits are intended to support layered .NET applications without forcing a specific application framework.

---

## Recommended Layer Usage

| Layer | Common Toolkits |
|---|---|
| API / Presentation | Validation, Pagination, Exceptions, Logging |
| Coordinator / Application | Validation, GuardKit, Time, Exceptions |
| Domain | GuardKit, Exceptions |
| Infrastructure | Registration, Logging, Time |
| Entity Framework | Pagination.EntityFramework |
| Composition Root | Composition, Registration |

---

## Key Principle

Application-specific behavior should stay in the application. Reusable, non-application-specific infrastructure belongs in Core ToolKits.

---

← Previous: [Quick Start](quick-start.md)

Next: [Toolkit Overview](../architecture/toolkit-overview.md) →
