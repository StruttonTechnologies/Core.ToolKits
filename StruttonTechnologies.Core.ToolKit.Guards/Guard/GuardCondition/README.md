# GuardCondition

`GuardCondition<T>` represents the **continuation stage** of the guard pipeline.

When a guard evaluation is performed, the `Guard` class determines whether the condition matches and returns a `GuardCondition<T>`. This object is responsible for deciding **what should happen next**.

The guard system therefore separates two responsibilities:

- **Evaluation** – performed by `Guard`
- **Continuation Behavior** – performed by `GuardCondition<T>`

Conceptually this looks like:

    Guard → GuardCondition<T> → Behavior

---

## Purpose

The purpose of `GuardCondition<T>` is to provide **clear and reusable continuation behaviors** when a guard condition matches.

Instead of writing repeated conditional logic such as:

    if (user == null)
    {
        return Array.Empty<UserLoginInfo>();
    }

the guard system allows the same behavior to be expressed fluently:

    return await Guard.IsNull(user)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

This keeps the evaluation logic and the continuation behavior cleanly separated.

---

## Behavior Methods

`GuardCondition<T>` contains the methods that define what should happen when a condition matches.

Examples include:

- `Return`
- `ReturnEmptyArray`
- `ReturnEmptyList`
- `ReturnEmptyEnumerable`

Each method follows the same pattern:

1. If the guard condition **matches**, a predefined value is returned.
2. If the guard condition **does not match**, the provided continuation delegate is executed.

---

## Example

Example using `ReturnEmptyArray`:

    return await Guard.IsNull(user)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

Flow of execution:

1. `Guard.IsNull(user)` evaluates the condition.
2. If `user` is null, `ReturnEmptyArray` immediately returns an empty array.
3. If `user` is not null, the continuation delegate is executed.

---

## Property Evaluation

When using selector-based guards, the original object is preserved so it can be used by the continuation.

Example:

    return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

Evaluation checks both:

- whether the object is null
- whether the selected property satisfies the condition

If the condition does not match, the original object is passed to the continuation delegate.

---

## Design Goals

`GuardCondition<T>` is designed to:

- keep continuation logic reusable
- avoid repeated defensive patterns
- support asynchronous continuations
- maintain clear separation between evaluation and behavior
- work consistently across all guard evaluations

---

## Summary

`GuardCondition<T>` represents the **behavior stage** of the guard system.

It provides a fluent way to define what should happen after a condition is evaluated, allowing developers to express defensive logic clearly while keeping business code clean.