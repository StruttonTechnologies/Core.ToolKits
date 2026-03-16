# Strutton Technologies Core ToolKit Testing Guards

`StruttonTechnologies.Core.ToolKit.Testing.Guards` provides reusable testing helpers for validating behavior of the `StruttonTechnologies.Core.ToolKit.Guards` package.

This project exists to prevent duplication of guard-condition test patterns across multiple guard evaluators.

It builds on top of:

- `StruttonTechnologies.Core.ToolKit.Testing`
- `StruttonTechnologies.Core.ToolKit.Guards`

---

## Purpose

Guard evaluators follow consistent behavioral patterns:

- they return a `GuardCondition<T>`
- they expose a `Return()` method
- they either match or do not match

Testing those behaviors repeatedly can produce a lot of duplicated boilerplate.

This toolkit provides helpers that simplify writing those tests.

---

## Project Structure

```text
StruttonTechnologies.Core.ToolKit.Testing.Guards
├─ Assertions
├─ Conditions
├─ Data
└─ README.md
```

### Assertions

Helpers for asserting common guard outcomes.

Examples:

- matched conditions
- non-matched conditions

### Conditions

Helpers for working with `GuardCondition<T>` results.

These helpers help reduce repeated `.Return(true, _ => false)` patterns.

### Data

Reusable datasets specific to guard testing.

Examples:

- empty collections
- populated collections
- null values

---

## Relationship to Other Projects

| Project | Responsibility |
|---|---|
`Core.ToolKit.Testing` | generic reusable testing utilities |
`Core.ToolKit.Testing.Guards` | guard-specific testing helpers |
`Core.ToolKit.Guards.Tests` | unit tests for the Guards package |

---

## Design Goals

This toolkit should remain:

- small
- focused
- reusable
- guard-specific

It should **not** become a general-purpose testing library.

---

Strutton Technologies
