using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Utilities
{
    [ExcludeFromCodeCoverage]
    public class RecurrenceGeneratorTests
    {
        [Fact]
        public void Generate_ShouldThrowArgumentOutOfRangeException_WhenIntervalIsZero()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 31);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                RecurrenceGenerator.Generate(start, TimeSpan.Zero, end).ToList());

            Assert.Equal("interval", exception.ParamName);
        }

        [Fact]
        public void Generate_ShouldThrowArgumentOutOfRangeException_WhenIntervalIsNegative()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 31);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                RecurrenceGenerator.Generate(start, TimeSpan.FromDays(-1), end).ToList());

            Assert.Equal("interval", exception.ParamName);
        }

        [Fact]
        public void Generate_ShouldReturnSingleDate_WhenStartEqualsEnd()
        {
            var date = new DateTime(2024, 1, 1);

            var result = RecurrenceGenerator.Generate(date, TimeSpan.FromDays(1), date).ToList();

            Assert.Single(result);
            Assert.Equal(date, result[0]);
        }

        [Fact]
        public void Generate_ShouldReturnDailyDates()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 5);

            var result = RecurrenceGenerator.Generate(start, TimeSpan.FromDays(1), end).ToList();

            Assert.Equal(5, result.Count);
            Assert.Equal(new DateTime(2024, 1, 1), result[0]);
            Assert.Equal(new DateTime(2024, 1, 2), result[1]);
            Assert.Equal(new DateTime(2024, 1, 3), result[2]);
            Assert.Equal(new DateTime(2024, 1, 4), result[3]);
            Assert.Equal(new DateTime(2024, 1, 5), result[4]);
        }

        [Fact]
        public void Generate_ShouldReturnWeeklyDates()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 31);

            var result = RecurrenceGenerator.Generate(start, TimeSpan.FromDays(7), end).ToList();

            Assert.Equal(5, result.Count);
            Assert.Equal(new DateTime(2024, 1, 1), result[0]);
            Assert.Equal(new DateTime(2024, 1, 8), result[1]);
            Assert.Equal(new DateTime(2024, 1, 15), result[2]);
            Assert.Equal(new DateTime(2024, 1, 22), result[3]);
            Assert.Equal(new DateTime(2024, 1, 29), result[4]);
        }

        [Fact]
        public void Generate_ShouldReturnHourlyDates()
        {
            var start = new DateTime(2024, 1, 1, 0, 0, 0);
            var end = new DateTime(2024, 1, 1, 5, 0, 0);

            var result = RecurrenceGenerator.Generate(start, TimeSpan.FromHours(1), end).ToList();

            Assert.Equal(6, result.Count);
            Assert.Equal(new DateTime(2024, 1, 1, 0, 0, 0), result[0]);
            Assert.Equal(new DateTime(2024, 1, 1, 5, 0, 0), result[5]);
        }

        [Fact]
        public void Generate_ShouldNotExceedEndDate()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 10);

            var result = RecurrenceGenerator.Generate(start, TimeSpan.FromDays(3), end).ToList();

            Assert.Equal(4, result.Count);
            Assert.Equal(new DateTime(2024, 1, 1), result[0]);
            Assert.Equal(new DateTime(2024, 1, 4), result[1]);
            Assert.Equal(new DateTime(2024, 1, 7), result[2]);
            Assert.Equal(new DateTime(2024, 1, 10), result[3]);
        }

        [Fact]
        public void Matches_ShouldThrowArgumentOutOfRangeException_WhenIntervalIsZero()
        {
            var value = new DateTime(2024, 1, 1);
            var origin = new DateTime(2024, 1, 1);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                RecurrenceGenerator.Matches(value, origin, TimeSpan.Zero));

            Assert.Equal("interval", exception.ParamName);
        }

        [Fact]
        public void Matches_ShouldThrowArgumentOutOfRangeException_WhenIntervalIsNegative()
        {
            var value = new DateTime(2024, 1, 1);
            var origin = new DateTime(2024, 1, 1);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                RecurrenceGenerator.Matches(value, origin, TimeSpan.FromDays(-1)));

            Assert.Equal("interval", exception.ParamName);
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenValueIsBeforeOrigin()
        {
            var value = new DateTime(2024, 1, 1);
            var origin = new DateTime(2024, 1, 10);

            var result = RecurrenceGenerator.Matches(value, origin, TimeSpan.FromDays(1));

            Assert.False(result);
        }

        [Fact]
        public void Matches_ShouldReturnTrue_WhenValueEqualsOrigin()
        {
            var value = new DateTime(2024, 1, 1);
            var origin = new DateTime(2024, 1, 1);

            var result = RecurrenceGenerator.Matches(value, origin, TimeSpan.FromDays(1));

            Assert.True(result);
        }

        [Fact]
        public void Matches_ShouldReturnTrue_WhenValueIsOnInterval()
        {
            var origin = new DateTime(2024, 1, 1);
            var value = new DateTime(2024, 1, 8);

            var result = RecurrenceGenerator.Matches(value, origin, TimeSpan.FromDays(7));

            Assert.True(result);
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenValueIsNotOnInterval()
        {
            var origin = new DateTime(2024, 1, 1);
            var value = new DateTime(2024, 1, 9);

            var result = RecurrenceGenerator.Matches(value, origin, TimeSpan.FromDays(7));

            Assert.False(result);
        }

        [Fact]
        public void Matches_ShouldHandleHourlyInterval()
        {
            var origin = new DateTime(2024, 1, 1, 0, 0, 0);
            var value = new DateTime(2024, 1, 1, 3, 0, 0);

            var result = RecurrenceGenerator.Matches(value, origin, TimeSpan.FromHours(1));

            Assert.True(result);
        }

        [Fact]
        public void Matches_ShouldReturnFalse_ForOffByMinute()
        {
            var origin = new DateTime(2024, 1, 1, 0, 0, 0);
            var value = new DateTime(2024, 1, 1, 3, 1, 0);

            var result = RecurrenceGenerator.Matches(value, origin, TimeSpan.FromHours(1));

            Assert.False(result);
        }
    }
}
