# Toolkit Overview

[Home](../../README.md) > [Documentation](../README.md) > Architecture > Toolkit Overview

The Core ToolKits are organized as focused packages. Each package solves a specific cross-cutting problem without forcing unnecessary dependencies on consuming applications.

---

## Conceptual Map

```text
Core ToolKits
│
├── GuardKit
├── Validation
│   └── Exceptions
│
├── Pagination
│   └── Pagination.EntityFramework
│
├── Composition
│   └── Registration
│
├── Time
├── Logging
└── Exceptions
```

---

## Usage Philosophy

Use the smallest set of packages required for the project. Keep each application free to decide its own architecture while reusing shared infrastructure consistently.

---

← Previous: [Getting Started Architecture](../getting-started/architecture.md)

Next: [Dependency Map](dependency-map.md) →
