# Composite Validators

Combines multiple validators into a validation pipeline.

---

## Behavior

- Executes validators in order
- Stops on first failure (fail-fast)

---

## Example

```csharp
var validator = new CompositeValidator<string>(
    new EmailFormatValidator(),
    new WhitelistEmailValidator(allowedEmails));
```

---

## Purpose

- Enable modular validation
- Simplify orchestration
