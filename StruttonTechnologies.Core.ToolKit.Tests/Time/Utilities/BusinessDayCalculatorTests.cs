using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Utilities
{
    [ExcludeFromCodeCoverage]
    public class BusinessDayCalculatorTests
    {
        [Fact]
        public void Constructor_ShouldUseDefaultWeekends_WhenNotProvided()
        {
            var calculator = new BusinessDayCalculator();
            var saturday = new DateTime(2024, 1, 6); // Saturday
            var sunday = new DateTime(2024, 1, 7); // Sunday

            Assert.False(calculator.IsBusinessDay(saturday));
            Assert.False(calculator.IsBusinessDay(sunday));
        }

        [Fact]
        public void Constructor_ShouldUseCustomWeekends_WhenProvided()
        {
            var customWeekends = new[] { DayOfWeek.Friday, DayOfWeek.Saturday };
            var calculator = new BusinessDayCalculator(weekendDays: customWeekends);

            var friday = new DateTime(2024, 1, 5); // Friday
            var saturday = new DateTime(2024, 1, 6); // Saturday
            var sunday = new DateTime(2024, 1, 7); // Sunday

            Assert.False(calculator.IsBusinessDay(friday));
            Assert.False(calculator.IsBusinessDay(saturday));
            Assert.True(calculator.IsBusinessDay(sunday)); // Sunday is now a business day
        }

        [Fact]
        public void Constructor_ShouldUseHolidays_WhenProvided()
        {
            var holidays = new[] { new DateOnly(2024, 1, 1), new DateOnly(2024, 7, 4) };
            var calculator = new BusinessDayCalculator(holidays: holidays);

            var newYears = new DateTime(2024, 1, 1); // Monday, New Year's Day
            var independenceDay = new DateTime(2024, 7, 4); // Thursday, Independence Day

            Assert.False(calculator.IsBusinessDay(newYears));
            Assert.False(calculator.IsBusinessDay(independenceDay));
        }

        [Theory]
        [InlineData(2024, 1, 1)] // Monday
        [InlineData(2024, 1, 2)] // Tuesday
        [InlineData(2024, 1, 3)] // Wednesday
        [InlineData(2024, 1, 4)] // Thursday
        [InlineData(2024, 1, 5)] // Friday
        public void IsBusinessDay_ShouldReturnTrue_ForWeekdays(int year, int month, int day)
        {
            var calculator = new BusinessDayCalculator();
            var date = new DateTime(year, month, day);

            Assert.True(calculator.IsBusinessDay(date));
        }

        [Theory]
        [InlineData(2024, 1, 6)] // Saturday
        [InlineData(2024, 1, 7)] // Sunday
        public void IsBusinessDay_ShouldReturnFalse_ForWeekends(int year, int month, int day)
        {
            var calculator = new BusinessDayCalculator();
            var date = new DateTime(year, month, day);

            Assert.False(calculator.IsBusinessDay(date));
        }

        [Fact]
        public void NextBusinessDay_ShouldSkipWeekend()
        {
            var calculator = new BusinessDayCalculator();
            var friday = new DateTime(2024, 1, 5); // Friday

            var result = calculator.NextBusinessDay(friday);

            Assert.Equal(new DateTime(2024, 1, 8), result); // Monday
        }

        [Fact]
        public void NextBusinessDay_ShouldSkipHoliday()
        {
            var holidays = new[] { new DateOnly(2024, 1, 2) }; // Tuesday holiday
            var calculator = new BusinessDayCalculator(holidays: holidays);
            var monday = new DateTime(2024, 1, 1);

            var result = calculator.NextBusinessDay(monday);

            Assert.Equal(new DateTime(2024, 1, 3), result); // Wednesday
        }

        [Fact]
        public void NextBusinessDay_ShouldSkipMultipleNonBusinessDays()
        {
            var holidays = new[] { new DateOnly(2024, 1, 8) }; // Monday holiday
            var calculator = new BusinessDayCalculator(holidays: holidays);
            var friday = new DateTime(2024, 1, 5);

            var result = calculator.NextBusinessDay(friday);

            Assert.Equal(new DateTime(2024, 1, 9), result); // Tuesday (skips Sat, Sun, Mon holiday)
        }

        [Fact]
        public void PreviousBusinessDay_ShouldSkipWeekend()
        {
            var calculator = new BusinessDayCalculator();
            var monday = new DateTime(2024, 1, 8); // Monday

            var result = calculator.PreviousBusinessDay(monday);

            Assert.Equal(new DateTime(2024, 1, 5), result); // Friday
        }

        [Fact]
        public void PreviousBusinessDay_ShouldSkipHoliday()
        {
            var holidays = new[] { new DateOnly(2024, 1, 2) }; // Tuesday holiday
            var calculator = new BusinessDayCalculator(holidays: holidays);
            var wednesday = new DateTime(2024, 1, 3);

            var result = calculator.PreviousBusinessDay(wednesday);

            Assert.Equal(new DateTime(2024, 1, 1), result); // Monday
        }

        [Fact]
        public void CountBusinessDays_ShouldReturnZero_WhenEndBeforeStart()
        {
            var calculator = new BusinessDayCalculator();
            var start = new DateTime(2024, 1, 10);
            var end = new DateTime(2024, 1, 1);

            var count = calculator.CountBusinessDays(start, end);

            Assert.Equal(0, count);
        }

        [Fact]
        public void CountBusinessDays_ShouldCountWeekdaysOnly()
        {
            var calculator = new BusinessDayCalculator();
            var start = new DateTime(2024, 1, 1); // Monday
            var end = new DateTime(2024, 1, 7); // Sunday

            var count = calculator.CountBusinessDays(start, end);

            Assert.Equal(5, count); // Mon-Fri
        }

        [Fact]
        public void CountBusinessDays_ShouldExcludeHolidays()
        {
            var holidays = new[] { new DateOnly(2024, 1, 3) }; // Wednesday holiday
            var calculator = new BusinessDayCalculator(holidays: holidays);
            var start = new DateTime(2024, 1, 1); // Monday
            var end = new DateTime(2024, 1, 5); // Friday

            var count = calculator.CountBusinessDays(start, end);

            Assert.Equal(4, count); // 5 weekdays - 1 holiday
        }

        [Fact]
        public void CountBusinessDays_ShouldIncludeBothStartAndEnd_WhenBothBusinessDays()
        {
            var calculator = new BusinessDayCalculator();
            var start = new DateTime(2024, 1, 1); // Monday
            var end = new DateTime(2024, 1, 1); // Same Monday

            var count = calculator.CountBusinessDays(start, end);

            Assert.Equal(1, count);
        }

        [Fact]
        public void CountBusinessDays_ShouldHandleMultipleWeeks()
        {
            var calculator = new BusinessDayCalculator();
            var start = new DateTime(2024, 1, 1); // Monday
            var end = new DateTime(2024, 1, 14); // Sunday (2 full weeks)

            var count = calculator.CountBusinessDays(start, end);

            Assert.Equal(10, count); // 5 days per week * 2 weeks
        }

        [Fact]
        public void IsBusinessDay_ShouldIgnoreTimeComponent()
        {
            var calculator = new BusinessDayCalculator();
            var morning = new DateTime(2024, 1, 1, 9, 0, 0); // Monday 9 AM
            var evening = new DateTime(2024, 1, 1, 17, 30, 0); // Monday 5:30 PM

            Assert.True(calculator.IsBusinessDay(morning));
            Assert.True(calculator.IsBusinessDay(evening));
        }
    }
}
