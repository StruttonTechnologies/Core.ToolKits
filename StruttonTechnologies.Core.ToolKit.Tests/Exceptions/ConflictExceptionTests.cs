using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ConflictExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateException_WhenCalledWithNoParameters()
        {
            var exception = new ConflictException();

            Assert.NotNull(exception);
            Assert.IsType<ConflictException>(exception);
        }

        [Theory]
        [InlineData("Resource conflict detected")]
        [InlineData("The requested resource is in conflict with the current state")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new ConflictException(message);

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Conflict occurred";

            var exception = new ConflictException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new ConflictException("Test conflict");

            var exception = Assert.Throws<ConflictException>(action);

            Assert.Equal("Test conflict", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new ConflictException("Test");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<ConflictException>(ex);
            }
        }
    }
}
