namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public sealed class EnumerableTheoryDataTests
    {
        [Fact]
        public void EmptyIntegers_ContainsOnlyEmptyCollections()
        {
            List<object[]> rows = EnumerableTheoryData.EmptyIntegers.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row => Assert.Empty(Assert.IsAssignableFrom<IEnumerable<int>>(Assert.Single(row))));
        }

        [Fact]
        public void PopulatedIntegers_ContainsOnlyCollectionsWithItems()
        {
            List<object[]> rows = EnumerableTheoryData.PopulatedIntegers.ToList();

            Assert.Equal(4, rows.Count);
            Assert.All(rows, row => Assert.NotEmpty(Assert.IsAssignableFrom<IEnumerable<int>>(Assert.Single(row))));
        }

        [Fact]
        public void EmptyStrings_ContainsOnlyEmptyCollections()
        {
            List<object[]> rows = EnumerableTheoryData.EmptyStrings.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row => Assert.Empty(Assert.IsAssignableFrom<IEnumerable<string>>(Assert.Single(row))));
        }

        [Fact]
        public void PopulatedStrings_ContainsOnlyCollectionsWithItems()
        {
            List<object[]> rows = EnumerableTheoryData.PopulatedStrings.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row => Assert.NotEmpty(Assert.IsAssignableFrom<IEnumerable<string>>(Assert.Single(row))));
        }
    }
}
