using StruttonTechnologies.Core.ToolKit.Testing.Utilities;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Utilities;

public sealed class TestClockFactoryTests
{
    [Fact]
    public void Create_WithUtcNow_ReturnsFakeClockWithThatValue()
    {
        DateTime utcNow = new(2026, 3, 1, 12, 0, 0, DateTimeKind.Utc);

        var clock = TestClockFactory.Create(utcNow);

        Assert.Equal(utcNow, clock.UtcNow);
    }
}
