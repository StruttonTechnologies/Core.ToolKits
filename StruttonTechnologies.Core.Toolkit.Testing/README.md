# Strutton Technologies Core ToolKit Testing

`StruttonTechnologies.Core.ToolKit.Testing` provides reusable test infrastructure that can be used across many different solutions and test projects.

The purpose of this project is to reduce repetitive boilerplate, improve test readability, and provide a consistent foundation for writing maintainable tests.

This project is intentionally scoped to **general-purpose testing support**.

It should contain functionality that can be useful in **any solution**, regardless of whether the consumer is testing:

- domain logic
- utility libraries
- application services
- APIs
- Blazor components
- extension methods
- validation logic

If a helper is only useful for a specific toolkit or package, it should live in a more tightly scoped testing project such as:

- `StruttonTechnologies.Core.ToolKit.Testing.Guards`
- `StruttonTechnologies.Core.ToolKit.Testing.EntityFramework`

---

## Design Goals

This project is intended to provide test functionality that is:

- reusable
- clear
- low-boilerplate
- framework-friendly
- easy to understand
- safe to consume across many solutions

The project should avoid becoming a generic dumping ground for random test-only code.

---

## Scope

This project is a good place for:

- reusable theory data helpers
- reusable test models
- deterministic time helpers
- simple helper utilities used broadly across tests
- generic test support code that is not tied to one specific package

This project is **not** the right place for:

- feature-specific test contexts
- package-specific test helpers
- scenario-specific theory data
- models that only make sense for one specific unit under test

If a helper only exists for one item being tested, it should remain local to that test area.

Example:

```text
HasItems
├─ HasItemsTestContext.cs
├─ EmptyCollectionTests.cs
└─ PopulatedCollectionTests.cs
```

---

## Project Structure

```text
StruttonTechnologies.Core.ToolKit.Testing
├─ Data
├─ TestModels
├─ Time
└─ README.md
```

### Data

Contains reusable theory data builders and common data sets that can be used across many test projects.

Examples include:

- string-based theory data
- enumerable-based theory data
- integer-based theory data
- boolean-based theory data

### TestModels

Contains generic test model classes that help reduce repetitive test setup.

Examples include:

- objects with a `Value`
- objects with an `Items` collection
- parent/child objects for selector tests
- named value objects

### Time

Contains reusable time-related test helpers.

Examples include:

- fixed clocks
- deterministic date/time providers
- repeatable time values for tests

---

## Code Coverage

Classes in this project may be marked with:

```csharp
[ExcludeFromCodeCoverage]
```

when they represent support infrastructure that should not create noise in coverage reports.

The goal is to keep coverage reports meaningful so developers trust what they see.

---

## XML Documentation

Public types and members in this project should include XML documentation.

This project is intended to be reusable across solutions, so discoverability and clarity matter.

---

## Usage Philosophy

This toolkit is intended to support tests, not replace clear test intent.

Use it to reduce boilerplate and improve consistency, but do not hide important test meaning behind unnecessary abstraction.

Good testing support should make tests easier to read, not harder.

---

## Related Projects

Examples of more specialized testing projects include:

- `StruttonTechnologies.Core.ToolKit.Testing.Guards`
- `StruttonTechnologies.Core.ToolKit.Testing.EntityFramework`

These projects should contain testing functionality that is only relevant when those specific packages are being used.

---

Strutton Technologies  
Development standards and reusable tooling for maintainable .NET applications.
