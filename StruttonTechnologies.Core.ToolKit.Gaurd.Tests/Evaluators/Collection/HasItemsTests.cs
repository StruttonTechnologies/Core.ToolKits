using FluentAssertions;
using StruttonTechnologies.Core.ToolKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Gaurd.Tests.Evaluators.Collection;

public class HasItemsTests
{
    #region HasItems<T>(IEnumerable<T>? value)

    [Fact]
    public void HasItems_WithNullCollection_ShouldNotMatch()
    {
        // Arrange
        IEnumerable<int>? collection = null;

        // Act
        var result = Guard.HasItems(collection);

        // Assert
        result.Should().BeOfType<GuardCondition<IEnumerable<int>>>();
        // The guard should not match (we can verify by using a behavior)
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    [Fact]
    public void HasItems_WithEmptyCollection_ShouldNotMatch()
    {
        // Arrange
        var collection = Array.Empty<string>();

        // Act
        var result = Guard.HasItems(collection);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(CollectionsWithItems))]
    public void HasItems_WithItemsInCollection_ShouldMatch<T>(IEnumerable<T> collection)
    {
        // Act
        var result = Guard.HasItems(collection);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    public static TheoryData<IEnumerable<object>> CollectionsWithItems()
    {
        return new TheoryData<IEnumerable<object>>
        {
            new[] { 1, 2, 3 },
            new List<object> { "a", "b" },
            Enumerable.Range(1, 5),
            new[] { new object() }
        };
    }

    [Theory]
    [InlineData(new[] { 1 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 })]
    public void HasItems_WithNonEmptyArray_ShouldMatch(int[] collection)
    {
        // Act
        var result = Guard.HasItems(collection);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    [Fact]
    public void HasItems_WithSingleItem_ShouldMatch()
    {
        // Arrange
        var collection = new[] { "single" };

        // Act
        var result = Guard.HasItems(collection);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    [Fact]
    public void HasItems_WithEmptyList_ShouldNotMatch()
    {
        // Arrange
        var collection = new List<int>();

        // Act
        var result = Guard.HasItems(collection);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    #endregion

    #region HasItems<TObject, TItem>(TObject? value, Func<TObject, IEnumerable<TItem>?> selector)

    [Fact]
    public void HasItems_WithSelector_WhenNullSelector_ShouldThrowArgumentNullException()
    {
        // Arrange
        var obj = new TestObject { Items = new[] { 1, 2, 3 } };
        Func<TestObject, IEnumerable<int>?> selector = null!;

        // Act
        Action act = () => Guard.HasItems(obj, selector);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("selector");
    }

    [Fact]
    public void HasItems_WithSelector_WhenObjectIsNull_ShouldNotMatch()
    {
        // Arrange
        TestObject? obj = null;

        // Act
        var result = Guard.HasItems(obj, x => x.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    [Fact]
    public void HasItems_WithSelector_WhenSelectedCollectionIsNull_ShouldNotMatch()
    {
        // Arrange
        var obj = new TestObject { Items = null };

        // Act
        var result = Guard.HasItems(obj, x => x.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    [Fact]
    public void HasItems_WithSelector_WhenSelectedCollectionIsEmpty_ShouldNotMatch()
    {
        // Arrange
        var obj = new TestObject { Items = Array.Empty<int>() };

        // Act
        var result = Guard.HasItems(obj, x => x.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    [Fact]
    public void HasItems_WithSelector_WhenSelectedCollectionHasItems_ShouldMatch()
    {
        // Arrange
        var obj = new TestObject { Items = new[] { 1, 2, 3 } };

        // Act
        var result = Guard.HasItems(obj, x => x.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(TestObjectsWithItems))]
    public void HasItems_WithSelector_WhenMultipleObjectsWithItems_ShouldMatch(TestObject obj)
    {
        // Act
        var result = Guard.HasItems(obj, x => x.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    public static TheoryData<TestObject> TestObjectsWithItems()
    {
        return new TheoryData<TestObject>
        {
            new TestObject { Items = new[] { 1 } },
            new TestObject { Items = new[] { 1, 2, 3 } },
            new TestObject { Items = Enumerable.Range(1, 100).ToArray() }
        };
    }

    [Theory]
    [MemberData(nameof(TestObjectsWithoutItems))]
    public void HasItems_WithSelector_WhenMultipleObjectsWithoutItems_ShouldNotMatch(TestObject? obj)
    {
        // Act
        var result = Guard.HasItems(obj, x => x.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    public static TheoryData<TestObject?> TestObjectsWithoutItems()
    {
        return new TheoryData<TestObject?>
        {
            null,
            new TestObject { Items = null },
            new TestObject { Items = Array.Empty<int>() },
            new TestObject { Items = new List<int>() }
        };
    }

    [Fact]
    public void HasItems_WithSelector_WhenNestedProperty_ShouldEvaluateCorrectly()
    {
        // Arrange
        var obj = new ComplexTestObject
        {
            Nested = new TestObject { Items = new[] { 1, 2, 3 } }
        };

        // Act
        var result = Guard.HasItems(obj, x => x.Nested?.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    [Fact]
    public void HasItems_WithSelector_WhenNestedPropertyIsNull_ShouldNotMatch()
    {
        // Arrange
        var obj = new ComplexTestObject { Nested = null };

        // Act
        var result = Guard.HasItems(obj, x => x.Nested?.Items);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeFalse();
    }

    [Fact]
    public void HasItems_WithSelector_WhenSelectorReturnsStringCollection_ShouldWork()
    {
        // Arrange
        var obj = new StringCollectionObject
        {
            Names = new[] { "Alice", "Bob", "Charlie" }
        };

        // Act
        var result = Guard.HasItems(obj, x => x.Names);

        // Assert
        var matched = false;
        result.Do(_ => matched = true);
        matched.Should().BeTrue();
    }

    #endregion

    #region Test Helper Classes

    private class TestObject
    {
        public IEnumerable<int>? Items { get; set; }
    }

    private class ComplexTestObject
    {
        public TestObject? Nested { get; set; }
    }

    private class StringCollectionObject
    {
        public IEnumerable<string>? Names { get; set; }
    }

    #endregion
}
