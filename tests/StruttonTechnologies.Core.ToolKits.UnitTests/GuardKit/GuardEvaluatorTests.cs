using StruttonTechnologies.Core.ToolKit.GuardKit;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.GuardKit;

public sealed class GuardEvaluatorTests
{
    [Fact]
    public void IsNull_MatchesNullValue()
    {
        var result = Guard.IsNull<string>(null).Return("matched", value => value);

        Assert.Equal("matched", result);
    }

    [Fact]
    public void IsNull_DoesNotMatchNonNullValue()
    {
        var result = Guard.IsNull("value").Return("matched", value => value);

        Assert.Equal("value", result);
    }

    [Fact]
    public void IsNotNull_MatchesNonNullValue()
    {
        var called = false;

        Guard.IsNotNull("value").Do(() => called = true);

        Assert.True(called);
    }

    [Theory]
    [InlineData("", true)]
    [InlineData(" ", false)]
    [InlineData("value", false)]
    public void IsEmpty_EvaluatesStringExpectedly(string value, bool shouldMatch)
    {
        var result = Guard.IsEmpty(value).Return(true, _ => false);

        Assert.Equal(shouldMatch, result);
    }

    [Fact]
    public void HasValue_MatchesNonBlankString()
    {
        var result = Guard.HasValue("abc").Return(true, _ => false);

        Assert.True(result);
    }

    [Fact]
    public void HasItems_MatchesCollectionWithItems()
    {
        var result = Guard.HasItems(new[] { 1 }).Return(true, _ => false);

        Assert.True(result);
    }

    [Fact]
    public void IsEmpty_MatchesNullCollection()
    {
        IEnumerable<int>? values = null;

        var result = Guard.IsEmpty(values).Return(true, _ => false);

        Assert.True(result);
    }

    [Fact]
    public void IsEqual_UsesEqualityComparer()
    {
        var result = Guard.IsEqual(5, 5).Return(true, _ => false);

        Assert.True(result);
    }

    [Fact]
    public void IsGreaterThan_MatchesGreaterValue()
    {
        var result = Guard.IsGreaterThan(10, 5).Return(true, _ => false);

        Assert.True(result);
    }

    [Fact]
    public void IsType_MatchesRequestedType()
    {
        object value = "abc";

        var result = Guard.IsType<string>(value).Return(true, _ => false);

        Assert.True(result);
    }
}
