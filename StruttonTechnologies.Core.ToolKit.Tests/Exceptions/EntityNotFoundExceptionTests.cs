using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class EntityNotFoundExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateException_WhenCalledWithNoParameters()
        {
            var exception = new EntityNotFoundException();

            Assert.NotNull(exception);
            Assert.IsType<EntityNotFoundException>(exception);
        }

        [Theory]
        [InlineData("Entity not found")]
        [InlineData("User with ID 123 not found")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new EntityNotFoundException(message);

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Entity not found";

            var exception = new EntityNotFoundException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new EntityNotFoundException("Test entity not found");

            var exception = Assert.Throws<EntityNotFoundException>(action);

            Assert.Equal("Test entity not found", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new EntityNotFoundException("Test");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<EntityNotFoundException>(ex);
            }
        }
    }
}
