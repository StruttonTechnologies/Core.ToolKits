# Format Validators

Format validators validate common string formats and return structured `ValidationResult` values.

The validators in this folder delegate universal concept checks to `StruttonTechnologies.Core.Rules` instead of duplicating regex or normalization logic locally.

Examples:

- `EmailFormatValidator` uses `EmailRules`
- `PhoneNumberFormatValidator` uses `PhoneNumberRules`
- `UsZipCodeFormatValidator` uses `UsZipCodeRules`

This keeps `Core.Rules` as the authority for what is true about a concept while this package remains responsible for validation reporting.
