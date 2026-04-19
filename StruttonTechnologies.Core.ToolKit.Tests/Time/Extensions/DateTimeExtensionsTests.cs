using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Time.Extensions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Extensions
{
    [ExcludeFromCodeCoverage]
    public class DateTimeExtensionsTests
    {
        [Theory]
        [InlineData(2024, 1, 6)]  // Saturday
        [InlineData(2024, 1, 7)]  // Sunday
        public void IsWeekend_ShouldReturnTrue_ForWeekendDays(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.IsWeekend();

            Assert.True(result);
        }

        [Theory]
        [InlineData(2024, 1, 1)]  // Monday
        [InlineData(2024, 1, 2)]  // Tuesday
        [InlineData(2024, 1, 3)]  // Wednesday
        [InlineData(2024, 1, 4)]  // Thursday
        [InlineData(2024, 1, 5)]  // Friday
        public void IsWeekend_ShouldReturnFalse_ForWeekdays(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.IsWeekend();

            Assert.False(result);
        }

        [Fact]
        public void IsWeekend_ShouldUseCustomWeekendDays_WhenProvided()
        {
            var friday = new DateTime(2024, 1, 5); // Friday
            var customWeekend = new[] { DayOfWeek.Friday, DayOfWeek.Saturday };

            var result = friday.IsWeekend(customWeekend);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2024, 1, 1)]  // Monday
        [InlineData(2024, 1, 5)]  // Friday
        public void IsWeekday_ShouldReturnTrue_ForWeekdays(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.IsWeekday();

            Assert.True(result);
        }

        [Theory]
        [InlineData(2024, 1, 6)]  // Saturday
        [InlineData(2024, 1, 7)]  // Sunday
        public void IsWeekday_ShouldReturnFalse_ForWeekends(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.IsWeekday();

            Assert.False(result);
        }

        [Fact]
        public void StartOfDayUtc_ShouldReturnMidnight()
        {
            var date = new DateTime(2024, 1, 15, 14, 30, 45, DateTimeKind.Utc);

            var result = date.StartOfDayUtc();

            Assert.Equal(new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc), result);
            Assert.Equal(DateTimeKind.Utc, result.Kind);
        }

        [Fact]
        public void EndOfDayUtc_ShouldReturnLastTickOfDay()
        {
            var date = new DateTime(2024, 1, 15, 14, 30, 45, DateTimeKind.Utc);

            var result = date.EndOfDayUtc();

            Assert.Equal(new DateTime(2024, 1, 15, 23, 59, 59, DateTimeKind.Utc).AddTicks(9999999), result);
            Assert.Equal(DateTimeKind.Utc, result.Kind);
        }

        [Theory]
        [InlineData(2024, 1, 15)]
        [InlineData(2024, 2, 29)]  // Leap year
        [InlineData(2024, 12, 31)]
        public void StartOfMonth_ShouldReturnFirstDayOfMonth(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.StartOfMonth();

            Assert.Equal(new DateTime(year, month, 1), result);
        }

        [Theory]
        [InlineData(2024, 1, 15, 31)]  // January has 31 days
        [InlineData(2024, 2, 15, 29)]  // February 2024 (leap year)
        [InlineData(2024, 4, 15, 30)]  // April has 30 days
        public void EndOfMonth_ShouldReturnLastTickOfMonth(int year, int month, int day, int expectedLastDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.EndOfMonth();

            Assert.Equal(year, result.Year);
            Assert.Equal(month, result.Month);
            Assert.Equal(expectedLastDay, result.Day);
            Assert.Equal(23, result.Hour);
            Assert.Equal(59, result.Minute);
            Assert.Equal(59, result.Second);
        }

        [Theory]
        [InlineData(2024, 1, 10, DayOfWeek.Sunday, 7)]   // Wednesday -> previous Sunday
        [InlineData(2024, 1, 10, DayOfWeek.Monday, 8)]   // Wednesday -> previous Monday
        [InlineData(2024, 1, 7, DayOfWeek.Sunday, 7)]    // Sunday -> same day
        public void StartOfWeek_ShouldReturnCorrectStartDay(int year, int month, int day, DayOfWeek firstDay, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.StartOfWeek(firstDay);

            Assert.Equal(new DateTime(year, month, expectedDay).Date, result);
        }

        [Fact]
        public void EndOfWeek_ShouldReturnLastTickOfWeek()
        {
            var wednesday = new DateTime(2024, 1, 10); // Wednesday

            var result = wednesday.EndOfWeek(DayOfWeek.Sunday);

            Assert.Equal(DayOfWeek.Saturday, result.DayOfWeek);
            Assert.Equal(23, result.Hour);
            Assert.Equal(59, result.Minute);
        }

        [Theory]
        [InlineData(2024, 1, 10, DayOfWeek.Friday, 12)]    // Wednesday -> next Friday
        [InlineData(2024, 1, 10, DayOfWeek.Sunday, 14)]    // Wednesday -> next Sunday
        [InlineData(2024, 1, 10, DayOfWeek.Wednesday, 17)] // Wednesday -> next Wednesday (7 days)
        public void Next_ShouldReturnNextOccurrence(int year, int month, int day, DayOfWeek targetDay, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.Next(targetDay);

            Assert.Equal(targetDay, result.DayOfWeek);
            Assert.Equal(expectedDay, result.Day);
        }

        [Theory]
        [InlineData(2024, 1, 10, DayOfWeek.Monday, 8)]     // Wednesday -> previous Monday
        [InlineData(2024, 1, 10, DayOfWeek.Sunday, 7)]     // Wednesday -> previous Sunday
        [InlineData(2024, 1, 10, DayOfWeek.Wednesday, 3)]  // Wednesday -> previous Wednesday (7 days back)
        public void Previous_ShouldReturnPreviousOccurrence(int year, int month, int day, DayOfWeek targetDay, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.Previous(targetDay);

            Assert.Equal(targetDay, result.DayOfWeek);
            Assert.Equal(expectedDay, result.Day);
        }

        [Fact]
        public void EachDay_ShouldReturnAllDaysBetween()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 5);

            var days = start.EachDay(end).ToList();

            Assert.Equal(5, days.Count);
            Assert.Equal(new DateTime(2024, 1, 1), days[0]);
            Assert.Equal(new DateTime(2024, 1, 5), days[4]);
        }

        [Fact]
        public void EachDay_ShouldReturnEmptySequence_WhenEndBeforeStart()
        {
            var start = new DateTime(2024, 1, 5);
            var end = new DateTime(2024, 1, 1);

            var days = start.EachDay(end).ToList();

            Assert.Empty(days);
        }

        [Fact]
        public void EachDay_ShouldReturnSingleDay_WhenStartEqualsEnd()
        {
            var date = new DateTime(2024, 1, 1);

            var days = date.EachDay(date).ToList();

            Assert.Single(days);
            Assert.Equal(date.Date, days[0]);
        }

        [Fact]
        public void EachDay_ShouldIgnoreTimeComponent()
        {
            var start = new DateTime(2024, 1, 1, 14, 30, 0);
            var end = new DateTime(2024, 1, 3, 9, 15, 0);

            var days = start.EachDay(end).ToList();

            Assert.Equal(3, days.Count);
            Assert.All(days, day => Assert.Equal(TimeSpan.Zero, day.TimeOfDay));
        }

        [Fact]
        public void EachDay_ShouldHandleMonthBoundaries()
        {
            var start = new DateTime(2024, 1, 30);
            var end = new DateTime(2024, 2, 2);

            var days = start.EachDay(end).ToList();

            Assert.Equal(4, days.Count);
            Assert.Equal(new DateTime(2024, 1, 30), days[0]);
            Assert.Equal(new DateTime(2024, 1, 31), days[1]);
            Assert.Equal(new DateTime(2024, 2, 1), days[2]);
            Assert.Equal(new DateTime(2024, 2, 2), days[3]);
        }
    }
}
