using StruttonTechnologies.Core.ToolKit.Testing.Assertions;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Assertions;

public sealed class ExceptionAssertTests
{
    [Fact]
    public void ThrowsWithMessage_ReturnsThrownException()
    {
        InvalidOperationException exception = ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(
            () => throw new InvalidOperationException("alpha failure"),
            "alpha");

        Assert.Equal("alpha failure", exception.Message);
    }

    [Fact]
    public async Task ThrowsWithMessageAsync_ReturnsThrownException()
    {
        InvalidOperationException exception = await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
            () => Task.FromException(new InvalidOperationException("beta failure")),
            "beta");

        Assert.Equal("beta failure", exception.Message);
    }
}
