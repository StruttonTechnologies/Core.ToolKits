using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exception
{
    [ExcludeFromCodeCoverage]
    public sealed class ExceptionExtensionsTests
    {
        [Fact]
        public void GetInnermostException_ShouldReturnSelf_WhenNoInnerException()
        {
            var exception = new InvalidOperationException("Test");

            var result = exception.GetInnermostException();

            Assert.Same(exception, result);
        }

        [Fact]
        public void GetInnermostException_ShouldReturnInnermostException_WhenMultipleLevels()
        {
            var innermost = new ArgumentException("Innermost");
            var middle = new InvalidOperationException("Middle", innermost);
            var outer = new System.Exception("Outer", middle);

            var result = outer.GetInnermostException();

            Assert.Same(innermost, result);
        }

        [Fact]
        public void GetInnermostException_ShouldThrowArgumentNullException_WhenExceptionIsNull()
        {
            System.Exception? exception = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
                exception!.GetInnermostException());

            Assert.Equal("exception", ex.ParamName);
        }

        [Fact]
        public void GetInnermostMessage_ReturnsDeepestMessage()
        {
            System.Exception exception = new global::System.Exception("outer", new InvalidOperationException("inner"));

            string message = exception.GetInnermostMessage();

            Assert.Equal("inner", message);
        }

        [Fact]
        public void GetInnermostMessage_ShouldReturnOwnMessage_WhenNoInnerException()
        {
            var exception = new InvalidOperationException("Test message");

            var result = exception.GetInnermostMessage();

            Assert.Equal("Test message", result);
        }

        [Theory]
        [InlineData("Level 1", "Level 2", "Level 3")]
        [InlineData("Error A", "Error B", "Error C")]
        public void GetInnermostMessage_ShouldReturnLastMessage_WithMultipleLevels(
            string msg1, string msg2, string msg3)
        {
            var innermost = new ArgumentException(msg3);
            var middle = new InvalidOperationException(msg2, innermost);
            var outer = new System.Exception(msg1, middle);

            var result = outer.GetInnermostMessage();

            Assert.Equal(msg3, result);
        }

        [Fact]
        public void FlattenMessages_ShouldReturnAllMessages_WhenMultipleLevels()
        {
            var innermost = new ArgumentException("Innermost");
            var middle = new InvalidOperationException("Middle", innermost);
            var outer = new System.Exception("Outer", middle);

            var messages = outer.FlattenMessages();

            Assert.Equal(3, messages.Count);
            Assert.Equal("Outer", messages[0]);
            Assert.Equal("Middle", messages[1]);
            Assert.Equal("Innermost", messages[2]);
        }

        [Fact]
        public void FlattenMessages_ShouldReturnSingleMessage_WhenNoInnerException()
        {
            var exception = new InvalidOperationException("Test");

            var messages = exception.FlattenMessages();

            Assert.Single(messages);
            Assert.Equal("Test", messages[0]);
        }

        [Fact]
        public void FlattenMessages_ShouldSkipEmptyMessages_WhenPresent()
        {
            var innermost = new ArgumentException("Valid message");
            var middle = new InvalidOperationException("", innermost);
            var outer = new System.Exception("  ", middle);

            var messages = outer.FlattenMessages();

            Assert.Single(messages);
            Assert.Equal("Valid message", messages[0]);
        }

        [Fact]
        public void FlattenMessages_ShouldThrowArgumentNullException_WhenExceptionIsNull()
        {
            System.Exception? exception = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
                exception!.FlattenMessages());

            Assert.Equal("exception", ex.ParamName);
        }

        [Fact]
        public void FlattenMessages_ShouldReturnReadOnlyList()
        {
            var exception = new InvalidOperationException("Test");

            var messages = exception.FlattenMessages();

            Assert.IsAssignableFrom<IReadOnlyList<string>>(messages);
        }

        [Fact]
        public void FlattenMessages_ShouldHandleNullOrEmptyMessages_WhenPresent()
        {
            var innermost = new ArgumentException("");
            var middle = new InvalidOperationException("  ", innermost);
            var outer = new System.Exception(null!, middle);

            var messages = outer.FlattenMessages();

            // System.Exception with null message generates a default message
            // So we should have 1 message from the outer exception's default message
            Assert.NotEmpty(messages);
        }
    }
}
