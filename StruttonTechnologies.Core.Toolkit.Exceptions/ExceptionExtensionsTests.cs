namespace StruttonTechnologies.Core.ToolKit.Exceptions
{
    public sealed class ExceptionExtensionsTests
    {
        [Fact]
        public void GetInnermostMessage_ReturnsDeepestMessage()
        {
            Exception exception = new Exception("outer", new InvalidOperationException("inner"));

            string message = exception.GetInnermostMessage();

            Assert.Equal("inner", message);
        }
    }
}
