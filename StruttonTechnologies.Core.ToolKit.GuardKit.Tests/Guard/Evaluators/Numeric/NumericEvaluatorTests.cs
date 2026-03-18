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
            Assert.True(GuardTest.IsGreaterThan(10, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThan_WhenValueIsNotGreater_ReturnsNotMatched()
        {
            Assert.False(GuardTest.IsGreaterThan(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThan_WithSelector_WhenSelectedValueIsGreater_ReturnsMatched()
        {
            IntHolder value = new IntHolder { Value = 10 };
            Assert.True(GuardTest.IsGreaterThan(value, x => x.Value, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThan_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;
            Assert.False(GuardTest.IsGreaterThan(value, x => x.Value, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenValueEqualsComparison_ReturnsMatched()
        {
            Assert.True(GuardTest.IsGreaterThanOrEqual(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenValueIsLess_ReturnsNotMatched()
        {
            Assert.False(GuardTest.IsGreaterThanOrEqual(4, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThan_WhenValueIsLess_ReturnsMatched()
        {
            Assert.True(GuardTest.IsLessThan(4, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThan_WhenValueIsNotLess_ReturnsNotMatched()
        {
            Assert.False(GuardTest.IsLessThan(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThanOrEqual_WhenValueEqualsComparison_ReturnsMatched()
        {
            Assert.True(GuardTest.IsLessThanOrEqual(5, 5).Return(true, _ => false));
        }

        [Fact]
        public void IsLessThanOrEqual_WhenValueIsGreater_ReturnsNotMatched()
        {
            Assert.False(GuardTest.IsLessThanOrEqual(6, 5).Return(true, _ => false));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        public void IsNegative_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsNegative(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsPositive_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsPositive(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(-1, false)]
        public void IsZero_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsZero(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(-1, true)]
        public void IsNotZero_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsNotZero(value).Return(true, _ => false));
        }

        private sealed class IntHolder
        {
            public int Value { get; set; }
        }
    }
}
