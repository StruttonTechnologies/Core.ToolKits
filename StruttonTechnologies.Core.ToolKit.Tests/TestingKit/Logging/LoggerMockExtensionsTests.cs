using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Logging;

using Moq;

using StruttonTechnologies.Core.ToolKit.TestingKit.Logging.Logging;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Logging
{
    [ExcludeFromCodeCoverage]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1848:Use the LoggerMessage delegates", Justification = "Test code - performance is not critical")]
    public class LoggerMockExtensionsTests
    {
        [Fact]
        public void VerifyLog_ShouldThrowArgumentNullException_WhenLoggerMockIsNull()
        {
            Mock<ILogger<TestClass>> loggerMock = null!;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, "message", Times.Once()));

            Assert.Equal("loggerMock", exception.ParamName);
        }

        [Fact]
        public void VerifyLog_ShouldThrowArgumentException_WhenMessageFragmentIsNull()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();

            Assert.Throws<ArgumentNullException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, null!, Times.Once()));
        }

        [Fact]
        public void VerifyLog_ShouldThrowArgumentException_WhenMessageFragmentIsEmpty()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();

            var exception = Assert.Throws<ArgumentException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, string.Empty, Times.Once()));

            Assert.Equal("messageFragment", exception.ParamName);
        }

        [Fact]
        public void VerifyLog_ShouldThrowArgumentException_WhenMessageFragmentIsWhitespace()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();

            var exception = Assert.Throws<ArgumentException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, "   ", Times.Once()));

            Assert.Equal("messageFragment", exception.ParamName);
        }

        [Fact]
        public void VerifyLog_ShouldPass_WhenLogWasCalledWithMatchingMessage()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("This is a test message");

            loggerMock.VerifyLog(LogLevel.Information, "test message", Times.Once());
        }

        [Fact]
        public void VerifyLog_ShouldFail_WhenLogWasNotCalled()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();

            Assert.Throws<MockException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, "message", Times.Once()));
        }

        [Fact]
        public void VerifyLog_ShouldFail_WhenLogLevelDoesNotMatch()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("test message");

            Assert.Throws<MockException>(() =>
                loggerMock.VerifyLog(LogLevel.Warning, "test message", Times.Once()));
        }

        [Fact]
        public void VerifyLog_ShouldFail_WhenMessageDoesNotContainFragment()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("test message");

            Assert.Throws<MockException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, "different message", Times.Once()));
        }

        [Fact]
        public void VerifyLog_ShouldPass_WhenCalledMultipleTimes()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("test message 1");
            loggerMock.Object.LogInformation("test message 2");

            loggerMock.VerifyLog(LogLevel.Information, "test message", Times.Exactly(2));
        }

        [Fact]
        public void VerifyLog_ShouldSupportPartialMatch()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("This is a longer test message with more details");

            loggerMock.VerifyLog(LogLevel.Information, "test message", Times.Once());
        }

        [Fact]
        public void VerifyLog_ShouldBeCaseSensitive()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("Test Message");

            Assert.Throws<MockException>(() =>
                loggerMock.VerifyLog(LogLevel.Information, "test message", Times.Once()));
        }

        [Fact]
        public void VerifyLog_ShouldWorkWithWarningLevel()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogWarning("warning message");

            loggerMock.VerifyLog(LogLevel.Warning, "warning", Times.Once());
        }

        [Fact]
        public void VerifyLog_ShouldWorkWithErrorLevel()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogError("error occurred");

            loggerMock.VerifyLog(LogLevel.Error, "error occurred", Times.Once());
        }

        [Fact]
        public void VerifyLog_ShouldWorkWithTimesNever()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();

            loggerMock.VerifyLog(LogLevel.Information, "message", Times.Never());
        }

        [Fact]
        public void VerifyLog_ShouldWorkWithTimesAtLeastOnce()
        {
            var loggerMock = new Mock<ILogger<TestClass>>();
            loggerMock.Object.LogInformation("test message");
            loggerMock.Object.LogInformation("test message");

            loggerMock.VerifyLog(LogLevel.Information, "test message", Times.AtLeastOnce());
        }

        public sealed class TestClass
        {
        }
    }
}
