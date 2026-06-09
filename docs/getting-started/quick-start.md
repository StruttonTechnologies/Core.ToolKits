# Quick Start

[Home](../../README.md) > [Documentation](../README.md) > Getting Started > Quick Start

This page shows the intended user flow when building application code with the Core ToolKits.

---

## Typical Application Flow

```text
Incoming Request
      |
      v
Validate DTO / Command
      |
      v
Guard Business Rules
      |
      v
Execute Application Logic
      |
      v
Return Result / Paged Result
      |
      v
Log Diagnostics / Handle Exceptions
```

---

## Example Usage Pattern

```csharp
public ValidationResult Validate(PersonDto input)
{
    List<ValidationFailure> failures = new();

    if (string.IsNullOrWhiteSpace(input.FirstName))
    {
        failures.Add(new ValidationFailure(
            "First name is required.",
            "MissingFirstName",
            nameof(input.FirstName)));
    }

    return failures.Count == 0
        ? ValidationResult.Success()
        : ValidationResult.Failed(failures);
}
```

---

## Next Steps

| Task | Documentation |
|---|---|
| Add defensive checks | [GuardKit](../toolkits/guardkit/overview.md) |
| Validate DTOs or commands | [Validation](../toolkits/validation/overview.md) |
| Return paged data | [Pagination](../toolkits/pagination/overview.md) |
| Compose modules | [Composition](../toolkits/composition/overview.md) |
| Add testable time logic | [Time](../toolkits/time/overview.md) |

---

← Previous: [Installation](installation.md)

Next: [Architecture](architecture.md) →
