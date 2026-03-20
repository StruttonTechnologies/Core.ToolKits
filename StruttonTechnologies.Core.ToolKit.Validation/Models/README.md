# Models

Contains the core data models used by the validation framework.

---

## ValidationResult

Represents the outcome of a validation operation.

Supports:

- Success
- Failure
- Warning

---

## Factory Methods

```csharp
ValidationResult.Success();
ValidationResult.Failure("Error message");
ValidationResult.Warning("Warning message");
```

---

## Features

- Message
- Code
- Field
- Suggestions
- Metadata
- TraceId
- Exception

---

## Design Notes

- Immutable usage pattern
- Concrete result model
- Designed for both backend and UI consumption
