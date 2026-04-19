using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CustomApplicationExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateException_WhenCalledWithNoParameters()
        {
            var exception = new CustomApplicationException();

            Assert.NotNull(exception);
            Assert.IsType<CustomApplicationException>(exception);
        }

        [Theory]
        [InlineData("Application error occurred")]
        [InlineData("Custom application exception")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new CustomApplicationException(message);

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Application error";

            var exception = new CustomApplicationException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new CustomApplicationException("Test error");

            var exception = Assert.Throws<CustomApplicationException>(action);

            Assert.Equal("Test error", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new CustomApplicationException("Test");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<CustomApplicationException>(ex);
            }
        }
    }
}
