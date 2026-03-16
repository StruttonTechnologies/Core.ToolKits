# Time

The `Time` folder contains reusable time-related test helpers.

These helpers exist to make tests deterministic, readable, and easy to maintain when working with values such as:

- `DateTime`
- `DateTimeOffset`
- UTC timestamps
- repeatable "current time" values

The goal is to avoid tests that depend on the actual system clock, which can lead to brittle or misleading behavior.

---

## Design Goals

Time helpers in this folder should be:

- deterministic
- simple
- broadly reusable
- easy to understand
- safe to use in any solution

These helpers should remain generic and should not depend on a specific application or domain model.

---

## Included Classes

- `FixedClock`
- `FixedUtcClock`
- `TimeValues`

---

## FixedClock

`FixedClock` provides a reusable object that returns a fixed local `DateTime`.

This is useful when a test needs a stable, known time value.

### Example

```csharp
var clock = new FixedClock(new DateTime(2025, 01, 15, 8, 30, 0));

DateTime now = clock.Now;
```

### Use Cases

Typical use cases include:

- date comparison tests
- expiration logic tests
- scheduling logic tests
- repeatable local time scenarios

---

## FixedUtcClock

`FixedUtcClock` provides a reusable object that returns a fixed UTC `DateTime`.

This is useful when tests should explicitly work with UTC rather than local time.

### Example

```csharp
var clock = new FixedUtcClock(new DateTime(2025, 01, 15, 16, 30, 0, DateTimeKind.Utc));

DateTime utcNow = clock.UtcNow;
```

### Use Cases

Typical use cases include:

- UTC-based business logic
- timestamp generation tests
- persistence or API boundary tests
- expiration or comparison logic using UTC values

---

## TimeValues

`TimeValues` provides commonly used fixed date/time values for tests.

This helps avoid repeating the same literal values across multiple test projects.

### Example

```csharp
DateTime start = TimeValues.SampleLocal;
DateTime utc = TimeValues.SampleUtc;
DateTimeOffset offset = TimeValues.SampleOffset;
```

### Use Cases

Typical use cases include:

- common test setup values
- readable test fixtures
- shared reference times
- reducing repeated magic date literals

---

## When to Use the Time Folder

Use these helpers when:

- a test should not depend on the system clock
- the same date/time values are repeated across many tests
- time values should be explicit and stable
- readability improves by using named sample times

---

## When Not to Use the Time Folder

Do **not** place time helpers here if they are:

- specific to one application feature
- specific to one package
- tied to one business workflow
- dependent on a consumer-specific abstraction

If a helper only makes sense for one specific feature, it should remain local to that test area or move to a more specialized testing package.

---

## General Guidance

The `Time` folder should remain:

- generic
- deterministic
- reusable
- low-boilerplate

Avoid turning this folder into a date/time utility library for production code.

These helpers exist to support tests.

---

## Code Coverage

Types in this folder may be marked with:

```csharp
[ExcludeFromCodeCoverage]
```

when they serve purely as test support infrastructure.

This helps keep coverage reports focused on meaningful logic.
