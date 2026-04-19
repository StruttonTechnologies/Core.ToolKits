using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DatabaseExceptionTests
    {
        [Theory]
        [InlineData("Database connection failed")]
        [InlineData("Query execution error")]
        [InlineData("")]
        public void Constructor_ShouldSetMessage_WhenCalledWithMessage(string message)
        {
            var exception = new DatabaseException(message);

            Assert.Equal(message, exception.Message);
            Assert.Equal(string.Empty, exception.EntityName);
            Assert.Equal(string.Empty, exception.Operation);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenCalledWithBoth()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Database error";

            var exception = new DatabaseException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Same(innerException, exception.InnerException);
            Assert.Equal(string.Empty, exception.EntityName);
            Assert.Equal(string.Empty, exception.Operation);
        }

        [Theory]
        [InlineData("Insert failed", "User", "Insert")]
        [InlineData("Update failed", "Order", "Update")]
        [InlineData("Delete failed", "Product", "Delete")]
        public void Constructor_ShouldSetMessageEntityAndOperation_WhenCalledWithAll(
            string message, string entityName, string operation)
        {
            var exception = new DatabaseException(message, entityName, operation);

            Assert.Equal(message, exception.Message);
            Assert.Equal(entityName, exception.EntityName);
            Assert.Equal(operation, exception.Operation);
        }

        [Fact]
        public void Constructor_ShouldSetAllProperties_WhenCalledWithAllParameters()
        {
            var innerException = new InvalidOperationException("Inner error");
            var message = "Database operation failed";
            var entityName = "Customer";
            var operation = "Insert";

            var exception = new DatabaseException(message, entityName, operation, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Equal(entityName, exception.EntityName);
            Assert.Equal(operation, exception.Operation);
            Assert.Same(innerException, exception.InnerException);
        }

        [Fact]
        public void Exception_ShouldBeThrowable()
        {
            Action action = () => throw new DatabaseException("Test database error");

            var exception = Assert.Throws<DatabaseException>(action);

            Assert.Equal("Test database error", exception.Message);
        }

        [Fact]
        public void Exception_ShouldBeCatchableAsException()
        {
            try
            {
                throw new DatabaseException("Test", "Entity", "Operation");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<DatabaseException>(ex);
            }
        }

        [Fact]
        public void EntityName_ShouldDefaultToEmpty_WhenNotProvided()
        {
            var exception = new DatabaseException("Test");

            Assert.Equal(string.Empty, exception.EntityName);
        }

        [Fact]
        public void Operation_ShouldDefaultToEmpty_WhenNotProvided()
        {
            var exception = new DatabaseException("Test");

            Assert.Equal(string.Empty, exception.Operation);
        }
    }
}
