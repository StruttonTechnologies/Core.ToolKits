using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ConcurrencyConflictExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateException_WhenCalledWithNoParameters()
        {
            var exception = new ConcurrencyConflictException();

            Assert.NotNull(exception);
            Assert.IsType<ConcurrencyConflictException>(exception);
        }

        [Theory]
        [InlineData("Concurrency conflict detected")]
        [InlineData("The record was modified by another user")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new ConcurrencyConflictException(message);

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Concurrency conflict";

            var exception = new ConcurrencyConflictException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new ConcurrencyConflictException("Test conflict");

            var exception = Assert.Throws<ConcurrencyConflictException>(action);

            Assert.Equal("Test conflict", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBePersistenceException()
        {
            var exception = new ConcurrencyConflictException();

            Assert.IsAssignableFrom<PersistenceException>(exception);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsPersistenceException()
        {
            try
            {
                throw new ConcurrencyConflictException("Test");
            }
            catch (PersistenceException ex)
            {
                Assert.IsType<ConcurrencyConflictException>(ex);
            }
        }
    }
}
