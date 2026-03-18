namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Numeric
{
    /// <summary>
    /// Contains test scenarios for numeric guard evaluators.
    /// </summary>
    public class NumericEvaluatorTests
    {
        [Fact]
        public void IsGreaterThan_WhenValueIsGreater_ReturnsMatched()
        {
            Assert.True(Guard.IsGreaterThan(10, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThan_WhenValueIsNotGreater_ReturnsNotMatched()
        {
            Assert.False(Guard.IsGreaterThan(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThan_WithSelector_WhenSelectedValueIsGreater_ReturnsMatched()
        {
            var value = new IntHolder { Value = 10 };
            Assert.True(Guard.IsGreaterThan(value, x => x.Value, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThan_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;
            Assert.False(Guard.IsGreaterThan(value, x => x.Value, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenValueEqualsComparison_ReturnsMatched()
        {
            Assert.True(Guard.IsGreaterThanOrEqual(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenValueIsLess_ReturnsNotMatched()
        {
            Assert.False(Guard.IsGreaterThanOrEqual(4, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThan_WhenValueIsLess_ReturnsMatched()
        {
            Assert.True(Guard.IsLessThan(4, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThan_WhenValueIsNotLess_ReturnsNotMatched()
        {
            Assert.False(Guard.IsLessThan(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThanOrEqual_WhenValueEqualsComparison_ReturnsMatched()
        {
            Assert.True(Guard.IsLessThanOrEqual(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThanOrEqual_WhenValueIsGreater_ReturnsNotMatched()
        {
            Assert.False(Guard.IsLessThanOrEqual(6, 5).Return(true, _ => false));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        public void IsNegative_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, Guard.IsNegative(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsPositive_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, Guard.IsPositive(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(-1, false)]
        public void IsZero_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, Guard.IsZero(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(-1, true)]
        public void IsNotZero_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, Guard.IsNotZero(value).Return(true, _ => false));
        }

        private sealed class IntHolder
        {
            public int Value { get; set; }
        }
    }
}
