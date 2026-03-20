# StruttonTechnologies.Core.ToolKit.Validation

A lightweight, composable validation framework for building clean, reusable, and testable validation logic in StruttonTechnologies applications.

This package provides a simple validator contract, a structured validation result model, fluent enrichment extensions, dependency injection registration, and a set of reusable validators for common application scenarios.

---

## Features

- Simple `IValidator<T>` contract
- Concrete `ValidationResult` model
- Fluent result enrichment extensions
- Dependency injection registration support
- Reusable validators organized by concern
- Composable validation patterns
- Lightweight and dependency-conscious design

---

## Installation

```bash
dotnet add package StruttonTechnologies.Core.ToolKit.Validation
```

---

## Quick Start

```csharp
using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

public sealed class UserNameValidator : IValidator<string>
{
    public ValidationResult Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return ValidationResult.Failure("User name is required.");
        }

        return ValidationResult.Success();
    }
}
```

---

## Project Structure

```text
StruttonTechnologies.Core.ToolKit.Validation
├── Abstractions
├── DependencyInjection
├── Extensions
├── Models
├── Validators
│   ├── Common
│   ├── Composite
│   ├── Contact
│   └── Format
```

---

## Design Goals

- Keep validation explicit and easy to follow
- Favor practical reuse over unnecessary abstraction
- Return rich validation feedback in a consistent format
- Support modular architecture and dependency injection

---

## License

MIT (or your preferred license)
