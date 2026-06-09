# Clean Architecture Usage

[Home](../../README.md) > [Documentation](../README.md) > Architecture > Clean Architecture Usage

The Core ToolKits work well in Clean Architecture and modular monolith solutions.

---

## Recommended Placement

For this repository, reusable toolkit libraries live under `libraries/` and tests live under `tests/`.

```text
Core.ToolKits
├── libraries
│   ├── StruttonTechnologies.Core.ToolKit.GuardKit
│   ├── StruttonTechnologies.Core.ToolKit.Validation
│   ├── StruttonTechnologies.Core.ToolKit.Pagination
│   ├── StruttonTechnologies.Core.ToolKit.Composition
│   └── StruttonTechnologies.Core.ToolKit.*
│
└── tests
    └── StruttonTechnologies.Core.ToolKit*.Tests
```

In consuming applications, the packages typically map to layers like this:

| Application Layer | Common Toolkits |
|---|---|
| API / Presentation | Validation, Pagination, Logging, Exceptions |
| Coordinator / Application | Validation, GuardKit, Time, Exceptions |
| Domain | GuardKit, Exceptions |
| Entity Framework | Pagination.EntityFramework |
| Composition Root | Composition, Registration |

---

## Rule of Thumb

If the behavior is reusable across applications, it may belong in a toolkit. If it is specific to one business application, keep it in that application.

---

← Previous: [Dependency Map](dependency-map.md)

Next: [GuardKit](../toolkits/guardkit/overview.md) →
