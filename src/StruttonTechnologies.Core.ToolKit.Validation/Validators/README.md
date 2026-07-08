# Validators

Validators evaluate input and return structured validation results.

Validators should remain small and delegate concept-specific truth checks to lower-level rule authorities when available.

```text
StruttonTechnologies.Core.Rules
    Owns universal concept rules.

StruttonTechnologies.Core.ToolKit.Validation
    Owns validation contracts, results, and failure reporting.
```

Do not duplicate email, phone number, ZIP code, URL, or similar universal rules inside validators when a rule authority exists.
