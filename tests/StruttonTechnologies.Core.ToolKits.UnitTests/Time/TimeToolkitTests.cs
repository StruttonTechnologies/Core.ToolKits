using StruttonTechnologies.Core.ToolKit.Time.Clocks;
using StruttonTechnologies.Core.ToolKit.Time.Extensions;
using StruttonTechnologies.Core.ToolKit.Time.Models;
using StruttonTechnologies.Core.ToolKit.Time.Utilities;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Time;

public sealed class TimeToolkitTests
{
    [Fact]
    public void FakeClock_StoresUtcAndCanAdvance()
    {
        var start = new DateTime(2026, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var clock = new FakeClock(start);

        clock.Advance(TimeSpan.FromHours(2));

        Assert.Equal(start.AddHours(2), clock.UtcNow);
        Assert.Equal(TimeSpan.Zero, clock.UtcNowOffset.Offset);
    }

    [Fact]
    public void DateRange_RejectsEndBeforeStart()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new DateRange(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1)));
    }

    [Fact]
    public void DateRange_ContainsUsesExclusiveEnd()
    {
        var start = new DateTime(2026, 1, 1);
        var end = new DateTime(2026, 1, 2);
        var range = new DateRange(start, end);

        Assert.True(range.Contains(start));
        Assert.False(range.Contains(end));
    }

    [Fact]
    public void DateRange_MergeOverlaps_MergesTouchingRanges()
    {
        var ranges = new[]
        {
            new DateRange(new DateTime(2026, 1, 1), new DateTime(2026, 1, 3)),
            new DateRange(new DateTime(2026, 1, 3), new DateTime(2026, 1, 5)),
            new DateRange(new DateTime(2026, 1, 10), new DateTime(2026, 1, 11))
        };

        var merged = DateRange.MergeOverlaps(ranges);

        Assert.Equal(2, merged.Count);
        Assert.Equal(new DateTime(2026, 1, 5), merged[0].End);
    }

    [Fact]
    public void DateTimeExtensions_CalculateExpectedBoundaries()
    {
        var date = new DateTime(2026, 7, 7, 13, 30, 0, DateTimeKind.Local);

        Assert.Equal(new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Local), date.StartOfMonth());
        Assert.Equal(new DateTime(2026, 7, 7), date.StartOfWeek(DayOfWeek.Tuesday));
        Assert.Equal(new DateTime(2026, 7, 8), date.Next(DayOfWeek.Wednesday));
        Assert.Equal(new DateTime(2026, 7, 6), date.Previous(DayOfWeek.Monday));
    }

    [Fact]
    public void BusinessDayCalculator_SkipsWeekendsAndHolidays()
    {
        var holiday = new DateOnly(2026, 1, 1);
        var calculator = new BusinessDayCalculator(holidays: [holiday]);

        Assert.False(calculator.IsBusinessDay(new DateTime(2026, 1, 1)));
        Assert.False(calculator.IsBusinessDay(new DateTime(2026, 1, 3)));
        Assert.True(calculator.IsBusinessDay(new DateTime(2026, 1, 2)));
    }

    [Fact]
    public void RecurrenceGenerator_GeneratesExpectedValues()
    {
        var values = RecurrenceGenerator.Generate(
            new DateTime(2026, 1, 1),
            TimeSpan.FromDays(1),
            new DateTime(2026, 1, 3)).ToArray();

        Assert.Equal(3, values.Length);
        Assert.True(RecurrenceGenerator.Matches(new DateTime(2026, 1, 3), new DateTime(2026, 1, 1), TimeSpan.FromDays(1)));
    }

    [Fact]
    public void ScheduledTaskTracker_UsesClockForRunIntervals()
    {
        var clock = new FakeClock(new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        var tracker = new ScheduledTaskTracker(clock);

        Assert.True(tracker.ShouldRun("task", TimeSpan.FromMinutes(5)));
        tracker.RegisterExecution("task");
        Assert.False(tracker.ShouldRun("task", TimeSpan.FromMinutes(5)));
        clock.Advance(TimeSpan.FromMinutes(5));
        Assert.True(tracker.ShouldRun("task", TimeSpan.FromMinutes(5)));
    }

    [Fact]
    public void TimeStateTracker_TracksAgeAndExpiration()
    {
        var clock = new FakeClock(new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        var tracker = new TimeStateTracker(clock);

        tracker.Touch("key");
        clock.Advance(TimeSpan.FromSeconds(30));

        Assert.True(tracker.Exists("key"));
        Assert.Equal(TimeSpan.FromSeconds(30), tracker.Age("key"));
        Assert.True(tracker.HasExpired("key", TimeSpan.FromSeconds(30)));
    }
}
