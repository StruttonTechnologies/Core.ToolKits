using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class PersistenceExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateException_WhenCalledWithNoParameters()
        {
            var exception = new PersistenceException();

            Assert.NotNull(exception);
            Assert.IsType<PersistenceException>(exception);
        }

        [Theory]
        [InlineData("Persistence error occurred")]
        [InlineData("Failed to save data")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new PersistenceException(message);

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Persistence failed";

            var exception = new PersistenceException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new PersistenceException("Test persistence error");

            var exception = Assert.Throws<PersistenceException>(action);

            Assert.Equal("Test persistence error", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new PersistenceException("Test");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<PersistenceException>(ex);
            }
        }
    }
}
