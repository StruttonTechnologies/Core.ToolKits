using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ValidationExceptionTests
    {
        [Fact]
        public void Constructor_ShouldCreateExceptionWithDefaultMessage_WhenCalledWithNoParameters()
        {
            var exception = new ValidationException();

            Assert.NotNull(exception);
            Assert.Equal("One or more validation errors occurred.", exception.Message);
            Assert.Empty(exception.ValidationErrors);
        }

        [Theory]
        [InlineData("Validation failed")]
        [InlineData("Field is required")]
        [InlineData("Invalid format")]
        public void Constructor_ShouldSetMessageAndAddToErrors_WhenCalledWithMessage(string message)
        {
            var exception = new ValidationException(message);

            Assert.Equal(message, exception.Message);
            Assert.Single(exception.ValidationErrors);
            Assert.Equal(message, exception.ValidationErrors[0]);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerExceptionAndAddToErrors_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Validation failed";

            var exception = new ValidationException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
            Assert.Single(exception.ValidationErrors);
            Assert.Equal(message, exception.ValidationErrors[0]);
        }

        [Fact]
        public void Constructor_ShouldSetValidationErrors_WhenCalledWithErrorCollection()
        {
            var errors = new[] { "Error 1", "Error 2", "Error 3" };

            var exception = new ValidationException(errors);

            Assert.Equal("One or more validation errors occurred.", exception.Message);
            Assert.Equal(3, exception.ValidationErrors.Count);
            Assert.Equal("Error 1", exception.ValidationErrors[0]);
            Assert.Equal("Error 2", exception.ValidationErrors[1]);
            Assert.Equal("Error 3", exception.ValidationErrors[2]);
        }

        [Fact]
        public void Constructor_ShouldFilterOutNullAndWhitespace_WhenCalledWithErrorCollection()
        {
            var errors = new[] { "Valid Error", "", "  ", null!, "Another Valid Error" };

            var exception = new ValidationException(errors);

            Assert.Equal(2, exception.ValidationErrors.Count);
            Assert.Equal("Valid Error", exception.ValidationErrors[0]);
            Assert.Equal("Another Valid Error", exception.ValidationErrors[1]);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenErrorCollectionIsNull()
        {
            IEnumerable<string>? errors = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ValidationException(errors!));

            Assert.Equal("validationErrors", exception.ParamName);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new ValidationException("Test validation error");

            var exception = Assert.Throws<ValidationException>(action);

            Assert.Equal("Test validation error", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new ValidationException("Test");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<ValidationException>(ex);
            }
        }

        [Fact]
        public void ValidationErrors_ShouldBeReadOnly()
        {
            var errors = new[] { "Error 1", "Error 2" };
            var exception = new ValidationException(errors);

            Assert.IsAssignableFrom<IReadOnlyList<string>>(exception.ValidationErrors);
        }

        [Fact]
        public void Constructor_ShouldCreateEmptyErrorList_WhenEmptyArrayProvided()
        {
            var errors = Array.Empty<string>();
            var exception = new ValidationException(errors);

            Assert.Empty(exception.ValidationErrors);
        }

        [Fact]
        public void Constructor_ShouldCreateEmptyErrorList_WhenOnlyWhitespaceProvided()
        {
            var errors = new[] { "", "  " };
            var exception = new ValidationException(errors);

            Assert.Empty(exception.ValidationErrors);
        }

        [Fact]
        public void Constructor_ShouldCreateEmptyErrorList_WhenOnlyInvalidErrorsProvided()
        {
            var errors = new[] { "  ", "", null! };
            var exception = new ValidationException(errors);

            Assert.Empty(exception.ValidationErrors);
        }
    }
}
