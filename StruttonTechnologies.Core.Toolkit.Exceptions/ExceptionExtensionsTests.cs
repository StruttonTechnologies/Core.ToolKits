using StruttonTechnologies.Core.ToolKits.Exceptions;

namespace StruttonTechnologies.Core.ToolKits.Tests.Exceptions;

public sealed class ExceptionExtensionsTests
{
    [Fact]
    public void GetInnermostMessage_ReturnsDeepestMessage()
    {
        var exception = new Exception("outer", new InvalidOperationException("inner"));

        var message = exception.GetInnermostMessage();

        Assert.Equal("inner", message);
    }
}
