# Dependency Map

[Home](../../README.md) > [Documentation](../README.md) > Architecture > Dependency Map

This page describes package relationship guidance from a user perspective.

---

## Suggested Relationships

| Package | Commonly Used With |
|---|---|
| GuardKit | Exceptions |
| Validation | Exceptions |
| Pagination | Pagination.EntityFramework |
| Composition | Registration |
| Time | Validation, GuardKit |
| Logging | Exceptions |
| Exceptions | Validation, GuardKit, Logging |

---

## Guidance

Avoid pulling in a package only because another solution uses it. Package usage should be driven by the capability needed in the current project.

---

← Previous: [Toolkit Overview](toolkit-overview.md)

Next: [Clean Architecture Usage](clean-architecture.md) →
