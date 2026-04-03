namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public sealed class StringTheoryDataTests
    {
        [Fact]
        public void NullOrWhiteSpace_ContainsOnlyNullEmptyAndWhitespaceValues()
        {
            List<object[]> rows = StringTheoryData.NullOrWhiteSpace.ToList();

            Assert.Equal(6, rows.Count);
            Assert.Contains(rows, row => row.Length == 1 && row[0] is null);
            Assert.Contains(rows, row => row.Length == 1 && row[0] is string value && value == string.Empty);

            Assert.All(rows, row =>
            {
                Assert.Single(row);

                if (row[0] is string value)
                {
                    Assert.True(string.IsNullOrWhiteSpace(value));
                }
            });
        }

        [Fact]
        public void Populated_ContainsOnlyNonWhitespaceValues()
        {
            List<object[]> rows = StringTheoryData.Populated.ToList();

            Assert.Equal(4, rows.Count);
            Assert.All(rows, row =>
            {
                string value = Assert.IsType<string>(Assert.Single(row));
                Assert.False(string.IsNullOrWhiteSpace(value));
            });
        }

        [Fact]
        public void Empty_ContainsOnlyEmptyString()
        {
            List<object[]> rows = StringTheoryData.Empty.ToList();

            object[] row = Assert.Single(rows);
            Assert.Equal(string.Empty, Assert.IsType<string>(Assert.Single(row)));
        }

        [Fact]
        public void WhiteSpace_ContainsOnlyWhitespaceValues()
        {
            List<object[]> rows = StringTheoryData.WhiteSpace.ToList();

            Assert.Equal(4, rows.Count);
            Assert.All(rows, row =>
            {
                string value = Assert.IsType<string>(Assert.Single(row));
                Assert.True(string.IsNullOrWhiteSpace(value));
            });
        }
    }
}
