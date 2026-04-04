using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKits.Time.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Time.Models
{
    [ExcludeFromCodeCoverage]
    public class DateRangeTests
    {
        [Fact]
        public void Constructor_ShouldCreateRange_WhenEndIsGreaterThanStart()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 31);

            var range = new DateRange(start, end);

            Assert.Equal(start, range.Start);
            Assert.Equal(end, range.End);
        }

        [Fact]
        public void Constructor_ShouldCreateRange_WhenStartEqualsEnd()
        {
            var date = new DateTime(2024, 1, 1);

            var range = new DateRange(date, date);

            Assert.Equal(date, range.Start);
            Assert.Equal(date, range.End);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenEndIsLessThanStart()
        {
            var start = new DateTime(2024, 1, 31);
            var end = new DateTime(2024, 1, 1);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new DateRange(start, end));

            Assert.Equal("end", exception.ParamName);
        }

        [Fact]
        public void Duration_ShouldReturnCorrectTimeSpan()
        {
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 8);
            var range = new DateRange(start, end);

            var duration = range.Duration;

            Assert.Equal(TimeSpan.FromDays(7), duration);
        }

        [Fact]
        public void Duration_ShouldReturnZero_WhenStartEqualsEnd()
        {
            var date = new DateTime(2024, 1, 1);
            var range = new DateRange(date, date);

            var duration = range.Duration;

            Assert.Equal(TimeSpan.Zero, duration);
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenValueIsAtStart()
        {
            var range = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31));

            Assert.True(range.Contains(new DateTime(2024, 1, 1)));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenValueIsAtEnd()
        {
            var range = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31));

            Assert.False(range.Contains(new DateTime(2024, 1, 31)));
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenValueIsWithinRange()
        {
            var range = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31));

            Assert.True(range.Contains(new DateTime(2024, 1, 15)));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenValueIsBeforeStart()
        {
            var range = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31));

            Assert.False(range.Contains(new DateTime(2023, 12, 31)));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenValueIsAfterEnd()
        {
            var range = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31));

            Assert.False(range.Contains(new DateTime(2024, 2, 1)));
        }

        [Fact]
        public void Overlaps_ShouldReturnTrue_WhenRangesOverlap()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15));
            var range2 = new DateRange(new DateTime(2024, 1, 10), new DateTime(2024, 1, 20));

            Assert.True(range1.Overlaps(range2));
        }

        [Fact]
        public void Overlaps_ShouldReturnTrue_WhenOneRangeContainsAnother()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31));
            var range2 = new DateRange(new DateTime(2024, 1, 10), new DateTime(2024, 1, 20));

            Assert.True(range1.Overlaps(range2));
        }

        [Fact]
        public void Overlaps_ShouldReturnFalse_WhenRangesDoNotOverlap()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15));
            var range2 = new DateRange(new DateTime(2024, 1, 20), new DateTime(2024, 1, 31));

            Assert.False(range1.Overlaps(range2));
        }

        [Fact]
        public void Overlaps_ShouldReturnFalse_WhenRangesTouch()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15));
            var range2 = new DateRange(new DateTime(2024, 1, 15), new DateTime(2024, 1, 31));

            Assert.False(range1.Overlaps(range2));
        }

        [Fact]
        public void Intersect_ShouldReturnIntersection_WhenRangesOverlap()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15));
            var range2 = new DateRange(new DateTime(2024, 1, 10), new DateTime(2024, 1, 20));

            var intersection = range1.Intersect(range2);

            Assert.NotNull(intersection);
            Assert.Equal(new DateTime(2024, 1, 10), intersection.Value.Start);
            Assert.Equal(new DateTime(2024, 1, 15), intersection.Value.End);
        }

        [Fact]
        public void Intersect_ShouldReturnNull_WhenRangesDoNotOverlap()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15));
            var range2 = new DateRange(new DateTime(2024, 1, 20), new DateTime(2024, 1, 31));

            var intersection = range1.Intersect(range2);

            Assert.Null(intersection);
        }

        [Fact]
        public void Intersect_ShouldReturnNull_WhenRangesTouch()
        {
            var range1 = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15));
            var range2 = new DateRange(new DateTime(2024, 1, 15), new DateTime(2024, 1, 31));

            var intersection = range1.Intersect(range2);

            Assert.Null(intersection);
        }

        [Fact]
        public void MergeOverlaps_ShouldThrowArgumentNullException_WhenRangesIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                DateRange.MergeOverlaps(null!));

            Assert.Equal("ranges", exception.ParamName);
        }

        [Fact]
        public void MergeOverlaps_ShouldReturnEmpty_WhenRangesIsEmpty()
        {
            var result = DateRange.MergeOverlaps(Array.Empty<DateRange>());

            Assert.Empty(result);
        }

        [Fact]
        public void MergeOverlaps_ShouldReturnSingleRange_WhenOnlyOneRange()
        {
            var ranges = new[] { new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15)) };

            var result = DateRange.MergeOverlaps(ranges);

            Assert.Single(result);
            Assert.Equal(ranges[0], result[0]);
        }

        [Fact]
        public void MergeOverlaps_ShouldMergeOverlappingRanges()
        {
            var ranges = new[]
            {
                new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10)),
                new DateRange(new DateTime(2024, 1, 5), new DateTime(2024, 1, 15)),
                new DateRange(new DateTime(2024, 1, 12), new DateTime(2024, 1, 20))
            };

            var result = DateRange.MergeOverlaps(ranges);

            Assert.Single(result);
            Assert.Equal(new DateTime(2024, 1, 1), result[0].Start);
            Assert.Equal(new DateTime(2024, 1, 20), result[0].End);
        }

        [Fact]
        public void MergeOverlaps_ShouldNotMergeNonOverlappingRanges()
        {
            var ranges = new[]
            {
                new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10)),
                new DateRange(new DateTime(2024, 1, 15), new DateTime(2024, 1, 20)),
                new DateRange(new DateTime(2024, 1, 25), new DateTime(2024, 1, 31))
            };

            var result = DateRange.MergeOverlaps(ranges);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void MergeOverlaps_ShouldMergeTouchingRanges()
        {
            var ranges = new[]
            {
                new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10)),
                new DateRange(new DateTime(2024, 1, 10), new DateTime(2024, 1, 20))
            };

            var result = DateRange.MergeOverlaps(ranges);

            Assert.Single(result);
            Assert.Equal(new DateTime(2024, 1, 1), result[0].Start);
            Assert.Equal(new DateTime(2024, 1, 20), result[0].End);
        }

        [Fact]
        public void MergeOverlaps_ShouldHandleUnorderedRanges()
        {
            var ranges = new[]
            {
                new DateRange(new DateTime(2024, 1, 15), new DateTime(2024, 1, 20)),
                new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10)),
                new DateRange(new DateTime(2024, 1, 5), new DateTime(2024, 1, 12))
            };

            var result = DateRange.MergeOverlaps(ranges);

            Assert.Equal(2, result.Count);
            Assert.Equal(new DateTime(2024, 1, 1), result[0].Start);
            Assert.Equal(new DateTime(2024, 1, 12), result[0].End);
            Assert.Equal(new DateTime(2024, 1, 15), result[1].Start);
            Assert.Equal(new DateTime(2024, 1, 20), result[1].End);
        }
    }
}
