using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public sealed class BooleanTheoryDataTests
    {
        [Fact]
        public void TrueAndFalse_ReturnsTrueAndFalse()
        {
            List<object[]> rows = BooleanTheoryData.TrueAndFalse.ToList();

            Assert.Equal(2, rows.Count);
            Assert.Contains(rows, row => Assert.IsType<bool>(Assert.Single(row)));
            Assert.Contains(rows, row => !Assert.IsType<bool>(Assert.Single(row)));
        }

        [Fact]
        public void True_ReturnsOnlyTrue()
        {
            List<object[]> rows = BooleanTheoryData.True.ToList();

            Assert.Single(rows);
            Assert.True(Assert.IsType<bool>(Assert.Single(rows[0])));
        }

        [Fact]
        public void False_ReturnsOnlyFalse()
        {
            List<object[]> rows = BooleanTheoryData.False.ToList();

            Assert.Single(rows);
            Assert.False(Assert.IsType<bool>(Assert.Single(rows[0])));
        }
    }
}
