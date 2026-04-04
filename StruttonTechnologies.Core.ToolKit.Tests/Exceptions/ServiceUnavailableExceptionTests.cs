using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ServiceUnavailableExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateException_WhenCalledWithNoParameters()
        {
            var exception = new ServiceUnavailableException();

            Assert.NotNull(exception);
            Assert.IsType<ServiceUnavailableException>(exception);
        }

        [Theory]
        [InlineData("Service is unavailable")]
        [InlineData("External API is down")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new ServiceUnavailableException(message);

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Service unavailable";

            var exception = new ServiceUnavailableException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new ServiceUnavailableException("Test service unavailable");

            var exception = Assert.Throws<ServiceUnavailableException>(action);

            Assert.Equal("Test service unavailable", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new ServiceUnavailableException("Test");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<ServiceUnavailableException>(ex);
            }
        }
    }
}
