# Common Validators

Reusable validators applicable across many domains.

---

## Examples

- NotDefaultValidator<T>
- IdValidator<TKey>

---

## Purpose

- Reduce duplication
- Provide foundational validation rules

---

## Example

```csharp
var validator = new NotDefaultValidator<Guid>();
var result = validator.Validate(id);
```
