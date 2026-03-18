# TestModels

The `TestModels` folder contains reusable model types intended to simplify test setup.

These types exist to reduce repetitive object creation and provide common shapes that are useful across many test scenarios.

The models in this folder should remain **generic** and broadly useful.

---

## Included Classes

Examples of reusable test models include:

- `ValueTestObject<T>`
- `EnumerableTestObject<T>`
- `CollectionTestObject<T>`
- `DictionaryTestObject<TKey, TValue>`
- `ParentTestObject<TChild>`
- `NamedValueTestObject<T>`
- `KeyValueTestObject<TKey, TValue>`

---

## Purpose

These models are intended to help with tests involving:

- selectors
- property access
- simple object graphs
- value wrappers
- collection-based testing
- key/value data
- parent/child relationships

They reduce the need to repeatedly create local one-off classes in every test project.

---

## ValueTestObject<T>

Represents a simple object that contains a single `Value` property.

### Example

```csharp
var model = new ValueTestObject<int>
{
    Value = 42,
};
```

### Example usage

```csharp
var result = SomeMethod(model, x => x.Value);
```

This is useful for testing selectors and simple property access.

---

## EnumerableTestObject<T>

Represents a simple object that contains an `IEnumerable<T>` in an `Items` property.

### Example

```csharp
var model = new EnumerableTestObject<string>
{
    Items = new[] { "one", "two" },
};
```

### Example usage

```csharp
var result = GuardEvaluator.HasItems(model, x => x.Items);
```

This is useful for collection-based selector tests.

---

## CollectionTestObject<T>

Represents a simple object that contains an `ICollection<T>` in an `Items` property.

### Example

```csharp
var model = new CollectionTestObject<int>
{
    Items = new List<int> { 1, 2, 3 },
};
```

### Example usage

This is useful when tests require a mutable collection type rather than a plain enumerable.

---

## DictionaryTestObject<TKey, TValue>

Represents a simple object that contains a dictionary of key/value pairs.

### Example

```csharp
var model = new DictionaryTestObject<string, int>
{
    Items = new Dictionary<string, int>
    {
        ["one"] = 1,
        ["two"] = 2,
    },
};
```

### Example usage

This is useful when testing behavior against keyed collections.

---

## ParentTestObject<TChild>

Represents a simple object that contains a `Child` property.

### Example

```csharp
var model = new ParentTestObject<ValueTestObject<int>>
{
    Child = new ValueTestObject<int>
    {
        Value = 10,
    },
};
```

### Example usage

```csharp
var value = model.Child?.Value;
```

This is useful for nested selector tests.

---

## NamedValueTestObject<T>

Represents an object that contains both a `Name` and a `Value`.

### Example

```csharp
var model = new NamedValueTestObject<int>
{
    Name = "Age",
    Value = 42,
};
```

### Example usage

This is useful when testing behavior involving named values or simple paired properties.

---

## KeyValueTestObject<TKey, TValue>

Represents an object with a `Key` and `Value`.

### Example

```csharp
var model = new KeyValueTestObject<string, int>
{
    Key = "Item1",
    Value = 5,
};
```

### Example usage

This is useful for tests involving simple keyed data structures.

---

## When to Use TestModels

Use `TestModels` when:

- a simple model shape is useful across multiple tests or projects
- the object is generic and broadly reusable
- the model reduces repetitive local test setup
- the model does not encode one specific feature or domain concept

---

## When Not to Use TestModels

Do **not** place a model here if it only makes sense for one specific item under test.

If a model only exists to support one feature, keep it local to that test area.

### Example

This should remain local:

```text
HasItems
└─ HasItemsTestContext.cs
```

That is the right place for:

- feature-specific test data
- feature-specific helper models
- one-off selector objects
- scenario-specific setup

---

## General Guidance

The `TestModels` folder should remain:

- generic
- reusable
- simple
- easy to understand

Avoid adding domain-specific or feature-specific models here.

If a model is only useful when testing a specific toolkit or package, it may belong in a more tightly scoped project such as:

- `StruttonTechnologies.Core.ToolKit.Testing.Guards`
- `StruttonTechnologies.Core.ToolKit.Testing.EntityFramework`

---

## Code Coverage

Types in `TestModels` may be marked with:

```csharp
[ExcludeFromCodeCoverage]
```

when they serve only as test support infrastructure.

This helps keep coverage reporting focused on meaningful signals.
