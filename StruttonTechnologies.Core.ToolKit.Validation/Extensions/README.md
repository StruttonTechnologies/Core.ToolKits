# Extensions

Provides fluent APIs for enriching `ValidationResult` instances.

---

## Example

```csharp
ValidationResult.Failure("Invalid email")
    .WithCode("EmailInvalid")
    .WithField("Email")
    .WithSuggestion("Enter a valid email address");
```

---

## Available Methods

- WithCode
- WithField
- WithSuggestion
- WithMetadata
- WithTraceId
- WithException

---

## Design Notes

- Immutable (returns new instances)
- Chainable
- Improves readability and diagnostics
