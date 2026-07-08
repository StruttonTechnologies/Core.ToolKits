using StruttonTechnologies.Core.ToolKit.GuardKit;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.GuardKit;

public sealed class GuardBehaviorTests
{
    [Fact]
    public void ReturnOrThrow_ThrowsWhenMatched()
    {
        Assert.Throws<InvalidOperationException>(() =>
            Guard.IsTrue(true).ReturnOrThrow(() => new InvalidOperationException("matched")));
    }

    [Fact]
    public void ReturnOrThrow_ReturnsValueWhenNotMatched()
    {
        var value = Guard.IsTrue(false).ReturnOrThrow(() => new InvalidOperationException());

        Assert.False(value);
    }

    [Fact]
    public void ReturnValueOrNull_ReturnsDefaultWhenMatched()
    {
        string? value = Guard.IsNull<string>(null).ReturnValueOrNull();

        Assert.Null(value);
    }

    [Fact]
    public void ReturnDefault_ReturnsFactoryValueWhenNotMatched()
    {
        var value = Guard.IsNull("abc").ReturnDefault(v => v.Length);

        Assert.Equal(3, value);
    }

    [Fact]
    public void ReturnEmptyList_ReturnsEmptyWhenMatched()
    {
        var value = Guard.IsTrue(true).ReturnEmptyList(_ => new List<int> { 1 });

        Assert.Empty(value);
    }

    [Fact]
    public async Task DoAsync_ExecutesWhenMatched()
    {
        var called = false;

        await Guard.IsTrue(true).DoAsync(() =>
        {
            called = true;
            return Task.CompletedTask;
        });

        Assert.True(called);
    }

    [Fact]
    public void ReturnValidation_ReturnsFailureWhenMatched()
    {
        var result = Guard.IsTrue(true).ReturnValidation(
            "bad",
            "Code",
            "Field",
            () => ValidationResult.Success());

        Assert.False(result.IsValid);
        Assert.Equal("Code", result.Code);
    }
}
