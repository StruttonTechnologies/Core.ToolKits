using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public sealed class IntegerTheoryDataTests
    {
        [Fact]
        public void EmptyCollections_ContainsOnlyEmptyCollections()
        {
            List<IEnumerable<int>> rows = [.. IntegerTheoryData.EmptyCollections.Select(row => row.Data)];

            Assert.Equal(3, rows.Count);
            Assert.All(rows, Assert.Empty);
        }

        [Fact]
        public void PopulatedCollections_ContainsOnlyCollectionsWithItems()
        {
            List<IEnumerable<int>> rows = [.. IntegerTheoryData.PopulatedCollections.Select(row => row.Data)];

            Assert.Equal(4, rows.Count);
            Assert.All(rows, Assert.NotEmpty);
        }

        [Fact]
        public void BoundaryValues_ContainsExpectedRangeMarkers()
        {
            List<int> values = [.. IntegerTheoryData.BoundaryValues.Select(row => row.Data)];

            Assert.Equal(new[] { int.MinValue, -1, 0, 1, int.MaxValue }, values);
        }

        [Fact]
        public void PositiveValues_ContainsOnlyPositiveNumbers()
        {
            List<int> values = [.. IntegerTheoryData.PositiveValues.Select(row => row.Data)];

            Assert.Equal(5, values.Count);
            Assert.All(values, value => Assert.True(value > 0));
        }

        [Fact]
        public void NegativeValues_ContainsOnlyNegativeNumbers()
        {
            List<int> values = [.. IntegerTheoryData.NegativeValues.Select(row => row.Data)];

            Assert.Equal(5, values.Count);
            Assert.All(values, value => Assert.True(value < 0));
        }
    }
}
