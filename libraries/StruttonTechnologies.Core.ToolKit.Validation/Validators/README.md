# Format Validators

Validators that verify structural correctness of data.

---

## Examples

- EmailFormatValidator
- PhoneNumberFormatValidator
- UsZipCodeFormatValidator
- RegexValidator

---

## Purpose

- Validate format, not real-world existence
- Provide reusable regex-based validation

---

## Example

```csharp
var validator = new EmailFormatValidator();
var result = validator.Validate(email);
```

---

## Notes

- Lightweight
- No external dependencies
- Intended for business-layer validation
