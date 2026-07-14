using Microsoft.Extensions.Logging;
using StruttonTechnologies.Core.ToolKit.Logging.Helpers;
using StruttonTechnologies.Core.ToolKit.Logging.Services;
using StruttonTechnologies.Core.ToolKit.Logging.Utilities;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Logging;

public sealed class LoggingTests
{
    [Fact]
    public void CorrelationIdAccessor_ReturnsExistingCorrelationId()
    {
        var accessor = new CorrelationIdAccessor { CorrelationId = "abc" };

        Assert.Equal("abc", accessor.GetOrCreate());
    }

    [Fact]
    public void CorrelationIdAccessor_CreatesCorrelationIdWhenMissing()
    {
        var accessor = new CorrelationIdAccessor();

        var correlationId = accessor.GetOrCreate();

        Assert.False(string.IsNullOrWhiteSpace(correlationId));
        Assert.Equal(correlationId, accessor.CorrelationId);
    }

    [Fact]
    public void LogMessageBuilder_CreatesMissingConfigurationMessage()
    {
        var message = LogMessageBuilder.MissingConfiguration("ConnectionStrings:Default");

        Assert.Equal("Missing configuration value: 'ConnectionStrings:Default'.", message);
    }

    [Fact]
    public void LogMessageBuilder_CreatesConfigurationFoundMessage()
    {
        var message = LogMessageBuilder.ConfigurationFound("ConnectionStrings:Default");

        Assert.Equal("Configuration check passed: 'ConnectionStrings:Default' found.", message);
    }

    [Fact]
    public void LogScopeBuilder_ExcludesNullValues()
    {
        var scope = LogScopeBuilder.Create((LogScopeKeys.CorrelationId, "abc"), (LogScopeKeys.RequestId, null));

        Assert.True(scope.ContainsKey(LogScopeKeys.CorrelationId));
        Assert.False(scope.ContainsKey(LogScopeKeys.RequestId));
    }

    [Fact]
    public void LoggingEventId_Create_CreatesNamedEventId()
    {
        var eventId = LoggingEventId.Create(123, "TestEvent");

        Assert.Equal(123, eventId.Id);
        Assert.Equal("TestEvent", eventId.Name);
    }

    [Fact]
    public void LoggingEventIds_AreWithinExpectedRanges()
    {
        Assert.InRange(LoggingEventIds.ValidationFailed, LoggingEventRanges.ValidationMinimum, LoggingEventRanges.ValidationMaximum);
        Assert.InRange(LoggingEventIds.ExceptionLogged, LoggingEventRanges.ExceptionsMinimum, LoggingEventRanges.ExceptionsMaximum);
    }
}
