using Microsoft.Extensions.Logging;

using Moq;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.Logging.Logging
{
    /// <summary>
    /// Moq helpers for verifying ILogger calls.
    /// </summary>
    public static class LoggerMockExtensions
    {
        public static void VerifyLog<T>(
            this Mock<ILogger<T>> loggerMock,
            LogLevel level,
            string messageFragment,
            Times times)
        {
            ArgumentNullException.ThrowIfNull(loggerMock);
            ArgumentException.ThrowIfNullOrWhiteSpace(messageFragment);

            loggerMock.Verify(
                logger => logger.Log(
                    level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains(messageFragment, StringComparison.Ordinal)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                times);
        }
    }
}
