````md
# GitHub Copilot Guidelines  
Strutton Technologies — Unified Development Standards

These guidelines define how GitHub Copilot should generate code, tests, documentation, and architectural patterns within repositories in the Strutton Technologies ecosystem.

They combine:

- the original Strutton Technologies Copilot rules  
- expanded architectural, testing, and workflow guidance  
- modern C# expectations  
- STP workflow integration  
- explicit “do” and “do not” rules  

These instructions ensure Copilot produces code that is:

- consistent  
- maintainable  
- aligned with your architecture  
- easy for developers to understand  
- compatible with STP and .NET 10  

---

# Purpose

AI-assisted code generation can produce large amounts of code quickly. Without guidance, generated code may not match the development style or architectural expectations used within a project.

The purpose of these guidelines is to ensure that generated code:

- follows consistent coding practices
- aligns with established architectural patterns
- remains readable and maintainable
- integrates well with existing solutions
- supports long-term evolution of the codebase

---

# Core Coding Preferences

These rules describe the preferred coding style for generated C# code.

## Namespace Style

Use **block-scoped namespaces**.

Example:

```csharp
namespace Example.Project.Domain
{
    public class ExampleClass
    {
    }
}
```

Do **not** use file-scoped namespaces.

Avoid:

```csharp
namespace Example.Project.Domain;
```

---

## Braces for Control Statements

Always use braces for control statements, even if the body contains a single line.

Preferred:

```csharp
if (condition)
{
    DoWork();
}
```

Avoid:

```csharp
if (condition)
    DoWork();
```

Using braces improves readability and reduces the chance of errors when code is modified later.

---

## General Principles

Generated code should aim to be:

- clear
- readable
- maintainable
- consistent with the surrounding codebase

Avoid overly clever implementations. Favor straightforward solutions that other developers can easily understand.

---

# Architecture & Layering

Copilot must follow these architectural rules:

## Clean Layering

- **Domain/Core** → business logic  
- **Infrastructure** → persistence, external services  
- **API** → controllers, endpoints  
- **Tests** → scenario-based test organization  

Do **not** mix responsibilities across layers.

## Dependency Injection

- Use constructor injection  
- Avoid static service locators  
- Avoid manually instantiating dependencies inside classes  

## Partial Class Organization

Avoid creating large "mega classes" that contain many unrelated methods.

Instead, use **partial classes and method-per-file organization** to keep code easy to navigate and maintain.

### Parent Class Pattern

Create a parent partial class that represents the logical class.

Example:

```csharp
namespace Example.Project.Guards
{
    public static partial class Guard
    {
    }
}
```

This file acts as the logical root for the class.

### Method Organization

Place methods into separate files using partial classes.

Create a folder that groups the methods. The folder name should either be:

- `Methods`
- or a descriptive category name when appropriate

Example structure:

```
Guard
├─ Guard.cs
└─ Methods
   ├─ Guard.AgainstNull.cs
   ├─ Guard.AgainstEmpty.cs
   └─ Guard.AgainstOutOfRange.cs
```

Each method file should declare the same partial class.

Example:

```csharp
namespace Example.Project.Guards
{
    public static partial class Guard
    {
        public static void AgainstNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
```

### Namespace Consistency

All partial class files must use the **same namespace** as the parent class.

Do not create nested or alternate namespaces for method files.

Example:

```csharp
namespace Example.Project.Guards
```

Consistency is important so the compiler correctly merges the partial class definitions.

---

# Modern C# Expectations

Copilot should use:

- `var` for local inference  
- pattern matching  
- primary constructors when appropriate  
- collection expressions  
- async/await everywhere applicable  
- expression-bodied members when readable  
- `readonly` fields where possible  

Avoid outdated patterns.

---

# Test Organization & Guidelines

Unit tests should be organized to keep tests easy to navigate and maintain.

Avoid creating a single large test class containing many unrelated tests.

Instead, organize tests by **class under test** and group related scenarios together.

## Folder Structure

Create a folder for the class being tested.

Example:

```
GuardTests
└─ AgainstNull
```

This folder contains tests related to the `Guard.AgainstNull` behavior.

## File Organization

Within the folder, create **test files grouped by scenario or behavior**.

Each file may contain multiple related tests.

Example:

```
GuardTests
└─ AgainstNull
   ├─ NullValueTests.cs
   ├─ ValidValueTests.cs
   └─ ExceptionBehaviorTests.cs
```

This keeps tests organized without creating excessive numbers of files.

## Example Test File

Example structure for a grouped test file:

```csharp
public class NullValueTests
{
    [Fact]
    public void ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            Guard.AgainstNull(null, "value"));
    }

    [Fact]
    public void ExceptionShouldContainCorrectParameterName()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
            Guard.AgainstNull(null, "value"));

        Assert.Equal("value", exception.ParamName);
    }
}
```

## Naming Guidelines

Test class names should describe the behavior being tested.

Examples:

- `NullValueTests`
- `ValidValueTests`
- `ExceptionBehaviorTests`

Avoid generic names such as:

- `Tests`
- `GuardTests`
- `TestCases`

## Test Framework & Style

- Use **xUnit**  
- Prefer **scenario-based test grouping**  
- Prefer **FluentAssertions** when available:

```csharp
result.Should().Be(expected);
```

Avoid mocking domain logic. Mock only external dependencies.

---

# STP Toolkit Integration

Copilot should assume developers use the STP commands:

- `stp restore`
- `stp build`
- `stp test`
- `stp pack`
- `stp coverage`
- `stp analyze-coverage`

Generated instructions or examples should reference these commands when relevant, instead of raw `dotnet` commands, unless explicitly required.

---

# NuGet Packaging Expectations

Generated library code must be packable:

- Public APIs documented  
- XML comments encouraged  
- No internal-only “dead code”  
- No preview or experimental APIs  

Versioning is controlled by tags (e.g., `v1.2.3`).  
Copilot should **not** guess or hard-code version numbers.

---

# Documentation Guidelines

- Use Markdown  
- Include examples where helpful  
- Keep explanations concise  
- Prefer tables for structured data  

---

# Copilot Behavior Rules

## Do NOT generate:

- File-scoped namespaces  
- Static service locators  
- Preview or experimental .NET APIs  
- Large “mega classes”  
- Unnecessary `#region` blocks  
- Deprecated patterns  
- Overly clever or cryptic code  

## DO generate:

- Clean, maintainable, modern C#  
- Small, focused methods  
- Partial class organization  
- Scenario-based tests  
- XML docs for public APIs  
- DI-friendly patterns  

## When unsure, Copilot should:

- Prefer clarity over cleverness  
- Prefer maintainability over brevity  
- Prefer explicitness over magic  

---

# Example File Layout

```
/src
  /MyProject
    MyService.Core.cs
    MyService.Validation.cs
    MyService.Mapping.cs
    MyService.Extensions.cs

/tests
  /MyProject.Tests
    MyService
      CoreBehaviorTests.cs
      ValidationTests.cs
      MappingTests.cs
```

---

# Expanding These Guidelines

This document will evolve over time as additional development patterns and preferences are identified.

Future additions may include guidance related to:

- architecture layering (more detailed rules)
- repository structure
- additional testing expectations
- naming conventions
- project organization
- specific patterns for APIs, handlers, and services

---

# Final Notes

These instructions apply to all Copilot-generated content in this repository.

Copilot should always prioritize:

- Maintainability  
- Clarity  
- Consistency  
- Testability  
- Alignment with STP workflows  
````