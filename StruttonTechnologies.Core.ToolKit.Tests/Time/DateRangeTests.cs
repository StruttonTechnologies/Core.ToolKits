using StruttonTechnologies.Core.ToolKits.Time.Models;

namespace StruttonTechnologies.Core.ToolKits.Tests.Time
{
    public sealed class DateRangeTests
    {
        [Fact]
        public void Intersect_ReturnsExpectedOverlap()
        {
            var first = new DateRange(new DateTime(2026, 1, 1), new DateTime(2026, 1, 10));
            var second = new DateRange(new DateTime(2026, 1, 5), new DateTime(2026, 1, 15));

            var overlap = first.Intersect(second);

            Assert.NotNull(overlap);
            Assert.Equal(new DateTime(2026, 1, 5), overlap.Value.Start);
            Assert.Equal(new DateTime(2026, 1, 10), overlap.Value.End);
        }
    }
}
