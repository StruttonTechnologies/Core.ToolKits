using StruttonTechnologies.Core.ToolKits.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exception
{
    public sealed class ExceptionExtensionsTests
    {
        [Fact]
        public void GetInnermostMessage_ReturnsDeepestMessage()
        {
            System.Exception exception = new global::System.Exception("outer", new InvalidOperationException("inner"));

            string message = exception.GetInnermostMessage();

            Assert.Equal("inner", message);
        }
    }
}
