### GuardKit

A fluent guard and continuation framework for handling defensive logic.

Instead of writing:

```csharp
if (user == null)
{
    return Array.Empty<LoginInfo>();
}

You can write:

```csharp
return await Guard.IsNull(user)
    .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

---

### Common Usage Patterns

#### Returning a default or empty result

```csharp
return Guard.IsNull(user)
    .Return(Array.Empty<LoginInfo>(), u => u.Logins);

---

#### Returning an error / throwing an exception

```csharp
var user = Guard.IsNull(user)
    .ReturnOrThrow(() => new UserNotFoundException());

Or with a continuation:

```csharp
return await Guard.IsNull(user)
    .ReturnOrThrow(
        () => new UserNotFoundException(),
        u => _userManager.GetLoginsAsync(u));

---

#### Using selectors (checking nested values)

```csharp
return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
    .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

---

### Why this matters

GuardKit separates:

- evaluation → what is being checked  
- continuation → what happens next  

This results in:

- consistent defensive patterns  
- reduced branching and duplication  
- clearer intent in code  
