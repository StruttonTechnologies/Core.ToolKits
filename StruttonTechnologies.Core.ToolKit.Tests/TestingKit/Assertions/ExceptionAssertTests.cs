using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Testing.Assertions;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Assertions
{
    [ExcludeFromCodeCoverage]
    public class ExceptionAssertTests
    {
        [Fact]
        public void ThrowsWithMessage_ShouldThrowArgumentNullException_WhenActionIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(null!, "message"));

            Assert.Equal("action", exception.ParamName);
        }

        [Fact]
        public void ThrowsWithMessage_ShouldThrowArgumentException_WhenMessageFragmentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(() => throw new InvalidOperationException(), null!));
        }

        [Fact]
        public void ThrowsWithMessage_ShouldThrowArgumentException_WhenMessageFragmentIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(() => throw new InvalidOperationException(), string.Empty));

            Assert.Equal("expectedMessageFragment", exception.ParamName);
        }

        [Fact]
        public void ThrowsWithMessage_ShouldThrowArgumentException_WhenMessageFragmentIsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(() => throw new InvalidOperationException(), "   "));

            Assert.Equal("expectedMessageFragment", exception.ParamName);
        }

        [Fact]
        public void ThrowsWithMessage_ShouldReturnException_WhenMessageContainsFragment()
        {
            var result = ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(
                () => throw new InvalidOperationException("This is a test error"),
                "test error");

            Assert.NotNull(result);
            Assert.IsType<InvalidOperationException>(result);
        }

        [Fact]
        public void ThrowsWithMessage_ShouldThrow_WhenMessageDoesNotContainFragment()
        {
            Assert.Throws<Xunit.Sdk.ContainsException>(() =>
                ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(
                    () => throw new InvalidOperationException("This is a test error"),
                    "missing fragment"));
        }

        [Fact]
        public void ThrowsWithMessage_ShouldThrow_WhenWrongExceptionType()
        {
            Assert.Throws<Xunit.Sdk.ThrowsException>(() =>
                ExceptionAssert.ThrowsWithMessage<ArgumentException>(
                    () => throw new InvalidOperationException("error"),
                    "error"));
        }

        [Fact]
        public void ThrowsWithMessage_ShouldBeCaseSensitive()
        {
            Assert.Throws<Xunit.Sdk.ContainsException>(() =>
                ExceptionAssert.ThrowsWithMessage<InvalidOperationException>(
                    () => throw new InvalidOperationException("ERROR MESSAGE"),
                    "error message"));
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldThrowArgumentNullException_WhenActionIsNull()
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(null!, "message"));

            Assert.Equal("action", exception.ParamName);
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldThrowArgumentException_WhenMessageFragmentIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
                    () => Task.FromException(new InvalidOperationException()), 
                    null!));
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldThrowArgumentException_WhenMessageFragmentIsEmpty()
        {
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
                    () => Task.FromException(new InvalidOperationException()),
                    string.Empty));

            Assert.Equal("expectedMessageFragment", exception.ParamName);
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldThrowArgumentException_WhenMessageFragmentIsWhitespace()
        {
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
                    () => Task.FromException(new InvalidOperationException()),
                    "   "));

            Assert.Equal("expectedMessageFragment", exception.ParamName);
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldReturnException_WhenMessageContainsFragment()
        {
            var result = await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
                () => Task.FromException<object>(new InvalidOperationException("This is an async error")),
                "async error");

            Assert.NotNull(result);
            Assert.IsType<InvalidOperationException>(result);
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldThrow_WhenMessageDoesNotContainFragment()
        {
            await Assert.ThrowsAsync<Xunit.Sdk.ContainsException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
                    () => Task.FromException<object>(new InvalidOperationException("This is an async error")),
                    "missing fragment"));
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldThrow_WhenWrongExceptionType()
        {
            await Assert.ThrowsAsync<Xunit.Sdk.ThrowsException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<ArgumentException>(
                    () => Task.FromException<object>(new InvalidOperationException("error")),
                    "error"));
        }

        [Fact]
        public async Task ThrowsWithMessageAsync_ShouldBeCaseSensitive()
        {
            await Assert.ThrowsAsync<Xunit.Sdk.ContainsException>(async () =>
                await ExceptionAssert.ThrowsWithMessageAsync<InvalidOperationException>(
                    () => Task.FromException<object>(new InvalidOperationException("ERROR MESSAGE")),
                    "error message"));
        }
    }
}
