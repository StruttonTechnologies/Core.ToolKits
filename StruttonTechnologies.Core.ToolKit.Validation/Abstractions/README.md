# Abstractions

The `Abstractions` folder contains the core contracts used by the validation framework.

---

## IValidator<T>

```csharp
public interface IValidator<in T>
{
    ValidationResult Validate(T input);
}
```

---

## Purpose

- Standardize validation behavior
- Enable dependency injection
- Support composition
- Keep logic testable and isolated

---

## Design Notes

- Minimal by design
- Returns concrete `ValidationResult`
- Avoids unnecessary abstraction layers
