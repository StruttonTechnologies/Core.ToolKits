# Guards

The **Guards toolkit** provides a fluent API for evaluating conditions and determining continuation behavior.

It is designed to reduce repetitive defensive code and improve readability when handling common validation and null-check scenarios.

---

## Purpose

The Guards toolkit introduces a simple pattern that separates two concerns:

- **Evaluation** — determining whether a condition exists
- **Continuation** — determining what should happen when the condition matches

This allows developers to express defensive logic clearly without repeating conditional boilerplate throughout the codebase.

---

## Basic Example

Traditional defensive code:

    if (user == null)
    {
        return Array.Empty<UserLoginInfo>();
    }

Using Guards:

    return await Guard.IsNull(user)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

The intent of the code becomes immediately clear.

---

## Property Evaluation (Selector Pattern)

The guard framework also supports evaluating properties safely using a selector.

Example:

    return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

In this case the guard evaluates:

- whether the object itself is null
- whether the selected property is invalid for the condition

This avoids having to write layered checks such as:

    if (user == null || string.IsNullOrWhiteSpace(user.Email))

The selector pattern allows this to be expressed as a single guard evaluation.

---

## Architectural Model

The guard system is intentionally simple and consists of two main parts.

Component | Responsibility
--- | ---
Guard | Performs the evaluation
GuardCondition<T> | Provides continuation behaviors

Conceptually the flow looks like this:

    Guard → GuardCondition<T> → Behavior

---

## Example Usage

Checking for null:

    return await Guard.IsNull(user)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

Checking for null or whitespace:

    return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

Returning a value instead of executing a continuation:

    return await Guard.IsNull(user)
        .Return(defaultUser, u => _repository.LoadAsync(u));

---

## Project Structure

The Guards project is organized to keep responsibilities clearly separated.

    Guard
    │
    ├── Guard.cs
    │
    ├── Methods
    │   └── Evaluator methods
    │
    └── GuardCondition
        └── Continuation behaviors

Each evaluator method is implemented in its own file using partial classes to keep the Guard class organized and easy to maintain.

---

## Design Goals

The Guards toolkit is designed to:

- remove repetitive defensive checks
- provide clear, readable continuation logic
- separate evaluation from behavior
- allow safe evaluation of object properties
- remain dependency-free and reusable across all layers

This makes the toolkit useful in:

- domain libraries
- application services
- identity systems
- infrastructure layers
- APIs and web applications

---

## Summary

The Guards toolkit provides a fluent and expressive way to write defensive logic by separating:

Evaluation → Continuation → Execution

This keeps business logic clean while centralizing common defensive patterns into reusable toolkit components.