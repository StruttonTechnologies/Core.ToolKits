using StruttonTechnologies.Core.ToolKit.Testing.Utilities;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Utilities;

public sealed class RandomDataGeneratorTests
{
    private enum SampleState
    {
        First,
        Second,
        Third,
    }

    [Fact]
    public void NextString_WithSeed_ReturnsDeterministicValue()
    {
        RandomDataGenerator first = new(seed: 1234);
        RandomDataGenerator second = new(seed: 1234);

        string firstValue = first.NextString(12);
        string secondValue = second.NextString(12);

        Assert.Equal(firstValue, secondValue);
    }

    [Fact]
    public void NextUtcDate_ReturnsUtcValueWithinRange()
    {
        RandomDataGenerator generator = new(seed: 50);
        DateTime start = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime end = new(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc);

        DateTime value = generator.NextUtcDate(start, end);

        Assert.Equal(DateTimeKind.Utc, value.Kind);
        Assert.True(value >= start);
        Assert.True(value < end);
    }

    [Fact]
    public void NextEnum_ReturnsDefinedValue()
    {
        RandomDataGenerator generator = new(seed: 7);

        SampleState value = generator.NextEnum<SampleState>();

        Assert.Contains(value, Enum.GetValues<SampleState>());
    }
}
