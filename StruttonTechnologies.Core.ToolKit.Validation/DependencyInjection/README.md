# DependencyInjection

Provides registration helpers for integrating validators into `IServiceCollection`.

---

## Usage

```csharp
services.AddValidators(typeof(Program).Assembly);
```

---

## Purpose

- Discover validators via assembly scanning
- Register validators with DI
- Centralize configuration

---

## Design Notes

- Uses extension methods, not registrar interfaces
- Follows standard .NET DI patterns
