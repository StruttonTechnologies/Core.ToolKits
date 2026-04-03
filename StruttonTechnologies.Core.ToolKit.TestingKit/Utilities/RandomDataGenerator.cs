namespace StruttonTechnologies.Core.ToolKit.Testing.Utilities;

/// <summary>
/// Generates random values for tests. Use a custom seed when repeatability matters.
/// </summary>
public sealed class RandomDataGenerator
{
    private readonly Random _random;

    public RandomDataGenerator(int? seed = null)
    {
        _random = seed.HasValue ? new Random(seed.Value) : Random.Shared;
    }

    public string NextString(int length, string? alphabet = null)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        alphabet ??= "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Range(0, length).Select(_ => alphabet[_random.Next(alphabet.Length)]).ToArray());
    }

    public int NextInt(int minInclusive, int maxExclusive) => _random.Next(minInclusive, maxExclusive);

    public DateTime NextUtcDate(DateTime startInclusiveUtc, DateTime endExclusiveUtc)
    {
        if (endExclusiveUtc <= startInclusiveUtc)
        {
            throw new ArgumentOutOfRangeException(nameof(endExclusiveUtc));
        }

        TimeSpan range = endExclusiveUtc - startInclusiveUtc;
        long nextTicks = (long)(_random.NextDouble() * range.Ticks);
        return DateTime.SpecifyKind(startInclusiveUtc.AddTicks(nextTicks), DateTimeKind.Utc);
    }

    public TEnum NextEnum<TEnum>()
        where TEnum : struct, Enum
    {
        TEnum[] values = Enum.GetValues<TEnum>();
        return values[_random.Next(values.Length)];
    }
}
