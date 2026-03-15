# Guard Evaluators

The **Evaluators** folder contains the methods that determine whether a guard condition has been met.

Each evaluator is implemented as a **static method on the `Guard` class** using partial class files. These methods perform the condition check and return a `GuardCondition<T>` which provides the continuation behavior.

Evaluators **do not perform actions** such as returning values or executing operations. Their responsibility is strictly limited to determining whether a condition matches.

---

## Evaluation Pattern

All evaluators follow the same conceptual pattern:

    Guard.<Condition>(value)
          ↓
    GuardCondition<T>
          ↓
       Behavior

The evaluator determines whether the condition matches. If the condition matches, the continuation behavior is executed. Otherwise the provided continuation is allowed to run.

---

## Direct Value Evaluation

Some evaluators operate directly on the provided value.

Example:

    Guard.IsNull(user)

This checks whether the provided value matches the condition.

---

## Property Evaluation (Selector Pattern)

Evaluators may also support evaluating a property from an object using a selector.

Example:

    Guard.IsNullOrWhiteSpace(user, u => u.Email)

This pattern evaluates both:

- whether the object itself is null
- whether the selected property matches the condition

This avoids the need for layered defensive checks such as:

    if (user == null || string.IsNullOrWhiteSpace(user.Email))

Instead, the guard performs the entire evaluation in a single fluent expression.

---

## Example Evaluator

A simple evaluator might look like this:

    public static GuardCondition<T> IsNull<T>(T? value)
        where T : class
    {
        return new GuardCondition<T>(value, value is null);
    }

Selector-based evaluators follow the same pattern but also evaluate a selected property.

---

## Current Evaluators

The guard system currently provides several common evaluations:

| Evaluator | Description |
|----------|-------------|
| IsNull | Checks whether a reference value is null |
| IsNullOrWhiteSpace | Checks whether a string is null, empty, or whitespace |
| IsDefault | Checks whether a value equals its default value |
| IsTrue | Checks whether a Boolean value is true |
| IsFalse | Checks whether a Boolean value is false |

Additional evaluators can be added as needed following the same pattern.

---

## Design Goals

Evaluators are designed to be:

- small and focused
- easy to read and maintain
- consistent in naming and behavior
- implemented in separate files to avoid large utility classes

Each evaluator file contains a single method (or related overloads) that extend the `Guard` partial class.

---

## Summary

The Evaluators folder contains the **condition checks** that drive the guard system.

They determine **whether a condition exists** and return a continuation object that decides **what happens next**.