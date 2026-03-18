# Guard

The `Guard` class is the entry point for all guard evaluations.

Every guard expression begins with a static method on the `Guard` class. These methods evaluate a condition and return a `GuardCondition<T>` which provides the continuation behavior.

The `Guard` class does **not perform actions** itself. Its responsibility is strictly limited to **evaluating conditions**.

---

## Evaluation Pattern

The guard system follows a simple pattern:

Evaluate → Continue → Execute

Conceptually this looks like:

    Guard → GuardCondition<T> → Behavior

The `Guard` class performs the evaluation and returns a continuation object that determines what should happen next.

---

## Direct Value Evaluation

The most basic guard evaluates a value directly.

Example:

    return await Guard.IsNull(user)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

The guard determines whether the condition matches and the continuation decides what to do next.

---

## Property Evaluation (Selector Pattern)

Guards can also safely evaluate a property of an object using a selector.

Example:

    return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

This pattern evaluates both:

- whether the object itself is null
- whether the selected property satisfies the condition

This eliminates the need for layered checks such as:

    if (user == null || string.IsNullOrWhiteSpace(user.Email))

Instead, the guard handles both evaluations in a single fluent expression.

---

## Guard Responsibilities

The `Guard` class is responsible for:

- determining whether a condition exists
- returning a `GuardCondition<T>` continuation
- providing a clean and discoverable API surface

The `Guard` class is **not responsible for performing actions** such as returning values or executing operations. Those behaviors are handled by `GuardCondition<T>`.

---

## Implementing Guards

Each guard evaluation is implemented in its own file using partial classes.

Example structure:

    Guard
    ├── Guard.cs
    └── Methods
        ├── IsNull.cs
        ├── IsNullOrWhiteSpace.cs
        ├── IsDefault.cs
        ├── IsTrue.cs
        └── IsFalse.cs

This approach prevents the `Guard` class from becoming a large monolithic utility class while keeping the public API simple.

---

## Example Evaluations

Examples of evaluations provided by the guard system include:

- IsNull
- IsNullOrWhiteSpace
- IsDefault
- IsTrue
- IsFalse

Each of these returns a `GuardCondition<T>` that determines the continuation behavior.

---

## Summary

The `Guard` class serves as the **evaluation entry point** for the guard system.

Its only responsibility is to determine whether a condition matches and return the continuation object that defines what happens next.