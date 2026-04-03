namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.GuardTests.Data
{
    public sealed class GuardCollectionTheoryDataTests
    {
        [Fact]
        public void EmptyIntegers_ContainsOnlyEmptyCollections()
        {
            List<object[]> rows = GuardCollectionTheoryData.EmptyIntegers.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row =>
            {
                IEnumerable<int> values = Assert.IsAssignableFrom<IEnumerable<int>>(Assert.Single(row));
                Assert.Empty(values);
            });
        }

        [Fact]
        public void PopulatedIntegers_ContainsOnlyCollectionsWithItems()
        {
            List<object[]> rows = GuardCollectionTheoryData.PopulatedIntegers.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row =>
            {
                IEnumerable<int> values = Assert.IsAssignableFrom<IEnumerable<int>>(Assert.Single(row));
                Assert.NotEmpty(values);
            });
        }

        [Fact]
        public void EmptyStrings_ContainsOnlyEmptyCollections()
        {
            List<object[]> rows = GuardCollectionTheoryData.EmptyStrings.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row =>
            {
                IEnumerable<string> values = Assert.IsAssignableFrom<IEnumerable<string>>(Assert.Single(row));
                Assert.Empty(values);
            });
        }

        [Fact]
        public void PopulatedStrings_ContainsOnlyCollectionsWithItems()
        {
            List<object[]> rows = GuardCollectionTheoryData.PopulatedStrings.ToList();

            Assert.Equal(3, rows.Count);
            Assert.All(rows, row =>
            {
                IEnumerable<string> values = Assert.IsAssignableFrom<IEnumerable<string>>(Assert.Single(row));
                Assert.NotEmpty(values);
            });
        }
    }
}
