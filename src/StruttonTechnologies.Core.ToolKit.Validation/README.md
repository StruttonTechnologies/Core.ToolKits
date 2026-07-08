# StruttonTechnologies.Core.ToolKit.Validation

A lightweight, composable validation framework for building clean, reusable, and testable validation logic in Strutton Technologies applications.

This package provides a simple validator contract, a structured validation result model, fluent enrichment extensions, dependency injection registration, and reusable validators for common application scenarios.

---

## Architectural Role

Validation is responsible for evaluating input and returning structured validation feedback. It does not own the universal truth rules for concepts such as email addresses, phone numbers, ZIP codes, or URLs.

Those universal rules live in `StruttonTechnologies.Core.Rules`. Validators in this package delegate concept-specific checks to rule authorities such as:

- `EmailRules`
- `PhoneNumberRules`
- `UsZipCodeRules`
- `UrlRules`

This keeps the responsibility split clear:

```text
Rules
    Define what is universally true about a concept.

Validation
    Evaluates input and reports validation failures in a consistent format.
```

---

## Features

- Simple `IValidator<T>` contract
- Concrete `ValidationResult` model
- Fluent result enrichment extensions
- Dependency injection registration support
- Reusable validators organized by concern
- Validators that delegate universal checks to `StruttonTechnologies.Core.Rules`
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

## Rule-backed Validators

Concept-specific validators should not duplicate regexes or formatting rules. They should call the appropriate rule authority.

Example:

```csharp
using StruttonTechnologies.Core.Rules;
using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

public sealed class EmailFormatValidator : IValidator<string>
{
    public ValidationResult Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return ValidationResult.Failure("Email is required.");
        }

        return EmailRules.IsValid(input)
            ? ValidationResult.Success()
            : ValidationResult.Failure("Invalid email format.");
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
- Keep universal concept rules in `StruttonTechnologies.Core.Rules`
- Support modular architecture and dependency injection

---

## License

MIT (or your preferred license)
