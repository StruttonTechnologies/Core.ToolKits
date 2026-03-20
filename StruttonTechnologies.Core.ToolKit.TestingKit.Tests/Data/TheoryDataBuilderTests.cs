namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public sealed class TheoryDataBuilderTests
    {
        [Fact]
        public void CreateRow_WithOneValue_ReturnsSingleItemArray()
        {
            object[] row = TheoryDataBuilder.CreateRow(42);

            Assert.Single(row);
            Assert.Equal(42, Assert.IsType<int>(row[0]));
        }

        [Fact]
        public void CreateRow_WithTwoValues_ReturnsTwoItemArray()
        {
            object[] row = TheoryDataBuilder.CreateRow("alpha", 42);

            Assert.Equal(2, row.Length);
            Assert.Equal("alpha", Assert.IsType<string>(row[0]));
            Assert.Equal(42, Assert.IsType<int>(row[1]));
        }

        [Fact]
        public void CreateRow_WithThreeValues_ReturnsThreeItemArray()
        {
            object[] row = TheoryDataBuilder.CreateRow("alpha", 42, true);

            Assert.Equal(3, row.Length);
            Assert.Equal("alpha", Assert.IsType<string>(row[0]));
            Assert.Equal(42, Assert.IsType<int>(row[1]));
            Assert.True(Assert.IsType<bool>(row[2]));
        }
    }
}
