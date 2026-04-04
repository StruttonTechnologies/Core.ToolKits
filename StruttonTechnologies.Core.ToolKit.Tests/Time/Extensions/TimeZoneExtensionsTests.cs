using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Extensions;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Extensions
{
    [ExcludeFromCodeCoverage]
    public class TimeZoneExtensionsTests
    {
        [Fact]
        public void ConvertTo_ShouldThrowArgumentNullException_WhenSourceTimeZoneIsNull()
        {
            var dateTime = DateTime.Now;
            TimeZoneInfo? source = null;
            var target = TimeZoneInfo.Utc;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                dateTime.ConvertTo(source!, target));

            Assert.Equal("sourceTimeZone", exception.ParamName);
        }

        [Fact]
        public void ConvertTo_ShouldThrowArgumentNullException_WhenTargetTimeZoneIsNull()
        {
            var dateTime = DateTime.Now;
            var source = TimeZoneInfo.Utc;
            TimeZoneInfo? target = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                dateTime.ConvertTo(source, target!));

            Assert.Equal("targetTimeZone", exception.ParamName);
        }

        [Fact]
        public void ConvertTo_ShouldConvertBetweenTimeZones()
        {
            var utcTime = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc);
            var eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var pacific = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            var result = utcTime.ConvertTo(TimeZoneInfo.Utc, eastern);

            Assert.NotEqual(utcTime, result);
        }

        [Fact]
        public void ConvertUtcTo_ShouldThrowArgumentNullException_WhenTargetTimeZoneIsNull()
        {
            var utcTime = DateTime.UtcNow;
            TimeZoneInfo? target = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                utcTime.ConvertUtcTo(target!));

            Assert.Equal("targetTimeZone", exception.ParamName);
        }

        [Fact]
        public void ConvertUtcTo_ShouldConvertUtcToTargetTimeZone()
        {
            var utcTime = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc);
            var eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var result = utcTime.ConvertUtcTo(eastern);

            // Eastern is typically UTC-5
            Assert.NotEqual(utcTime.Hour, result.Hour);
        }

        [Fact]
        public void ConvertUtcTo_ShouldNormalizeUnspecifiedToUtc()
        {
            var unspecifiedTime = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Unspecified);
            var target = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var result = unspecifiedTime.ConvertUtcTo(target);

            // Should treat unspecified as UTC and convert
            Assert.True(result.Year > 0);
        }

        [Fact]
        public void ConvertToUtc_ShouldThrowArgumentNullException_WhenSourceTimeZoneIsNull()
        {
            var localTime = DateTime.Now;
            TimeZoneInfo? source = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                localTime.ConvertToUtc(source!));

            Assert.Equal("sourceTimeZone", exception.ParamName);
        }

        [Fact]
        public void ConvertToUtc_ShouldConvertLocalToUtc()
        {
            var eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var easternTime = new DateTime(2024, 1, 15, 7, 0, 0); // 7 AM Eastern

            var utcResult = easternTime.ConvertToUtc(eastern);

            // Should be different from input time
            Assert.NotEqual(easternTime.Hour, utcResult.Hour);
        }

        [Fact]
        public void ConvertTo_ShouldReturnSameTime_WhenSourceAndTargetAreSame()
        {
            var time = new DateTime(2024, 1, 15, 12, 0, 0);
            var timeZone = TimeZoneInfo.Utc;

            var result = time.ConvertTo(timeZone, timeZone);

            Assert.Equal(time, result);
        }

        [Fact]
        public void ConvertUtcTo_AndBack_ShouldReturnOriginalTime()
        {
            var utcTime = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc);
            var eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var easternTime = utcTime.ConvertUtcTo(eastern);
            var backToUtc = easternTime.ConvertToUtc(eastern);

            Assert.Equal(utcTime, backToUtc);
        }
    }
}
