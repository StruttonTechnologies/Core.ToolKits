# Data

The `Data` folder contains reusable theory data builders and commonly used theory data sets.

The goal of this folder is to reduce boilerplate when writing `[Theory]` tests and to provide consistent, reusable data across many test projects.

These helpers should remain **generic** and broadly useful.

---

## Included Classes

- `TheoryDataBuilder`
- `StringTheoryData`
- `EnumerableTheoryData`
- `IntegerTheoryData`
- `BooleanTheoryData`

---

## TheoryDataBuilder

`TheoryDataBuilder` provides helper methods for creating theory data rows.

It helps reduce repetitive `new object[] { ... }` boilerplate.

### Example

```csharp
public static IEnumerable<object[]> PositiveNumbers =>
[
    TheoryDataBuilder.CreateRow(1),
    TheoryDataBuilder.CreateRow(5),
    TheoryDataBuilder.CreateRow(10)
];
```

### Why use it

Instead of writing:

```csharp
public static IEnumerable<object[]> PositiveNumbers =>
[
    new object[] { 1 },
    new object[] { 5 },
    new object[] { 10 }
];
```

you can write:

```csharp
public static IEnumerable<object[]> PositiveNumbers =>
[
    TheoryDataBuilder.CreateRow(1),
    TheoryDataBuilder.CreateRow(5),
    TheoryDataBuilder.CreateRow(10)
];
```

This improves readability and consistency.

---

## StringTheoryData

`StringTheoryData` provides common string-based data sets used in tests.

Typical categories include:

- null, empty, and whitespace strings
- populated strings
- empty strings
- whitespace strings

### Example usage

```csharp
[Theory]
[MemberData(nameof(StringTheoryData.NullOrWhiteSpace), MemberType = typeof(StringTheoryData))]
public void HasValue_WhenStringIsNullOrWhiteSpace_ReturnsFalse(string? value)
{
    Assert.False(value.HasValue());
}
```

### Example datasets

Examples of values that may be included:

- `null`
- `string.Empty`
- `" "`
- `"\t"`
- `"\r\n"`
- `"hello"`

---

## EnumerableTheoryData

`EnumerableTheoryData` provides commonly used enumerable-based data sets.

Typical categories include:

- empty integer collections
- populated integer collections
- empty string collections
- populated string collections

### Example usage

```csharp
[Theory]
[MemberData(nameof(EnumerableTheoryData.EmptyIntegers), MemberType = typeof(EnumerableTheoryData))]
public void HasItems_WhenCollectionIsEmpty_ReturnsNotMatched(IEnumerable<int> collection)
{
    var result = GuardEvaluator.HasItems(collection);

    Assert.False(result.Return(true, _ => false));
}
```

### Example datasets

Examples of values that may be included:

- `Enumerable.Empty<int>()`
- `Array.Empty<int>()`
- `new List<int>()`
- `new[] { 1 }`
- `new[] { 1, 2 }`

---

## IntegerTheoryData

`IntegerTheoryData` provides commonly used integer-based data sets.

Typical categories include:

- negative values
- zero
- positive values
- boundary-style values

### Example usage

```csharp
[Theory]
[MemberData(nameof(IntegerTheoryData.Boundaries), MemberType = typeof(IntegerTheoryData))]
public void SomeMethod_WhenUsingBoundaryValues_HandlesInputCorrectly(int value)
{
    Assert.IsType<int>(value);
}
```

### Example datasets

Examples of values that may be included:

- `int.MinValue`
- `-1`
- `0`
- `1`
- `int.MaxValue`

---

## BooleanTheoryData

`BooleanTheoryData` provides commonly used boolean-based data sets.

Typical categories include:

- true and false
- true only
- false only

### Example usage

```csharp
[Theory]
[MemberData(nameof(BooleanTheoryData.TrueAndFalse), MemberType = typeof(BooleanTheoryData))]
public void Toggle_WhenValueIsProvided_HandlesBothStates(bool value)
{
    Assert.IsType<bool>(value);
}
```

### Example datasets

Examples of values that may be included:

- `true`
- `false`

---

## When to Use the Data Folder

Use the `Data` folder when:

- the data is reusable across multiple tests or projects
- the values represent generic test input categories
- the data reduces repetitive boilerplate
- the data is not tied to a single feature or test scenario

---

## When Not to Use the Data Folder

Do **not** place data here when it is specific to one item under test.

If the data only makes sense for one specific feature, keep it local in a test context file.

### Example

This belongs local to the test area:

```text
HasItems
└─ HasItemsTestContext.cs
```

This is appropriate when the data is specific to `HasItems` behavior and would not be broadly reused elsewhere.

---

## General Guidance

The `Data` folder should remain:

- generic
- reusable
- easy to understand
- low-boilerplate

Avoid adding feature-specific or package-specific data here.

If the data is only useful when using a specific package, it may belong in a more specialized testing toolkit such as:

- `StruttonTechnologies.Core.ToolKit.Testing.Guards`
- `StruttonTechnologies.Core.ToolKit.Testing.EntityFramework`
