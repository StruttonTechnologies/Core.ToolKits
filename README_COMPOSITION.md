# ToolKit Composition

This refactor adds `StruttonTechnologies.Core.ToolKit.Composition` as the public ToolKit facade.

Use:

```csharp
services.AddStruttonTechnologiesToolKit(configuration);
```

The project registers GuardKit, Logging, and Registration runtime services. Time, Validation, Pagination, and Exceptions are primarily model/utility packages and do not currently require runtime DI registration.
