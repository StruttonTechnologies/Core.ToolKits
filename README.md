# Core.ToolKit

Core.ToolKit provides reusable engineering utilities designed to support consistent, maintainable, and architecture-aligned application development.

These libraries solve common cross-cutting concerns such as guard logic, validation, service composition, and testing support without introducing unnecessary abstraction or hidden behavior.

---

## 🎯 Purpose

In most systems, certain patterns appear repeatedly:

- guard clauses  
- validation  
- dependency registration  
- test setup and utilities  

When implemented inconsistently, these concerns lead to:

- duplicated logic  
- reduced readability  
- harder-to-maintain systems  

Core.ToolKit provides a structured and consistent approach to handling these concerns while keeping business logic clean and focused.

---

## 📦 Included Components


### GuardKit

A fluent guard and continuation framework for handling defensive logic.

Instead of writing:

```csharp
if (user == null)
{
    return Array.Empty<LoginInfo>();
}
```
You can write:

```csharp
return await Guard.IsNull(user)
    .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));
```
---

### Common Usage Patterns

#### Returning a default or empty result

```csharp
return Guard.IsNull(user)
    .Return(Array.Empty<LoginInfo>(), u => u.Logins);
```
---

#### Returning an error / throwing an exception

```csharp
var user = Guard.IsNull(user)
    .ReturnOrThrow(() => new UserNotFoundException());
```
Or with a continuation:

```csharp
return await Guard.IsNull(user)
    .ReturnOrThrow(
        () => new UserNotFoundException(),
        u => _userManager.GetLoginsAsync(u));
```
---

#### Using selectors (checking nested values)

```csharp
return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
    .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));
```
---

### Why this matters

GuardKit separates:

- evaluation → what is being checked  
- continuation → what happens next  

This results in:

- consistent defensive patterns  
- reduced branching and duplication  
- clearer intent in code  
