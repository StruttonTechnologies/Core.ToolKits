namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Numeric
{
    /// <summary>
    /// Contains test scenarios for numeric guard evaluators.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NumericEvaluatorTests
    {
        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsGreaterThan.
        /// </summary>
        #region IsGreaterThan

        [Theory]
        [InlineData(10, 5, true)]
        [InlineData(5, 5, false)]
        [InlineData(4, 5, false)]
        public void IsGreaterThan_WhenEvaluated_ReturnsExpectedResult(int value, int comparison, bool expected)
        {
            bool result = GuardTest.IsGreaterThan(value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 5, true)]
        [InlineData(5, 5, false)]
        [InlineData(4, 5, false)]
        public void IsGreaterThan_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, int comparison, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsGreaterThan(value, x => x.Value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsGreaterThan_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsGreaterThan(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsGreaterThan_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 10 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsGreaterThan<IntHolder, int>(value, null!, 5));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsGreaterThanOrEqual.
        /// </summary>
        #region IsGreaterThanOrEqual

        [Theory]
        [InlineData(10, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(4, 5, false)]
        public void IsGreaterThanOrEqual_WhenEvaluated_ReturnsExpectedResult(int value, int comparison, bool expected)
        {
            bool result = GuardTest.IsGreaterThanOrEqual(value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(4, 5, false)]
        public void IsGreaterThanOrEqual_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, int comparison, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsGreaterThanOrEqual(value, x => x.Value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsGreaterThanOrEqual_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsGreaterThanOrEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsGreaterThanOrEqual_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 5 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsGreaterThanOrEqual<IntHolder, int>(value, null!, 5));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsLessThan.
        /// </summary>
        #region IsLessThan

        [Theory]
        [InlineData(4, 5, true)]
        [InlineData(5, 5, false)]
        [InlineData(6, 5, false)]
        public void IsLessThan_WhenEvaluated_ReturnsExpectedResult(int value, int comparison, bool expected)
        {
            bool result = GuardTest.IsLessThan(value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 5, true)]
        [InlineData(5, 5, false)]
        [InlineData(6, 5, false)]
        public void IsLessThan_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, int comparison, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsLessThan(value, x => x.Value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsLessThan_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsLessThan(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsLessThan_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 5 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsLessThan<IntHolder, int>(value, null!, 5));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsLessThanOrEqual.
        /// </summary>
        #region IsLessThanOrEqual

        [Theory]
        [InlineData(4, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(6, 5, false)]
        public void IsLessThanOrEqual_WhenEvaluated_ReturnsExpectedResult(int value, int comparison, bool expected)
        {
            bool result = GuardTest.IsLessThanOrEqual(value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(6, 5, false)]
        public void IsLessThanOrEqual_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, int comparison, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsLessThanOrEqual(value, x => x.Value, comparison).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsLessThanOrEqual_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsLessThanOrEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsLessThanOrEqual_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 5 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsLessThanOrEqual<IntHolder, int>(value, null!, 5));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsNegative.
        /// </summary>
        #region IsNegative

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        public void IsNegative_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            bool result = GuardTest.IsNegative(value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        public void IsNegative_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsNegative<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsNegative_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsNegative<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsNegative_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = -1 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsNegative<IntHolder, int>(value, null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsPositive.
        /// </summary>
        #region IsPositive

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsPositive_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            bool result = GuardTest.IsPositive(value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsPositive_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsPositive<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsPositive_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsPositive<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsPositive_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 1 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsPositive<IntHolder, int>(value, null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsZero.
        /// </summary>
        #region IsZero

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(-1, false)]
        public void IsZero_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            bool result = GuardTest.IsZero(value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(-1, false)]
        public void IsZero_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsZero<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsZero_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsZero<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsZero_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 0 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsZero<IntHolder, int>(value, null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for the direct and selector overloads of IsNotZero.
        /// </summary>
        #region IsNotZero

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(-1, true)]
        public void IsNotZero_WhenEvaluated_ReturnsExpectedResult(int value, bool expected)
        {
            bool result = GuardTest.IsNotZero(value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(-1, true)]
        public void IsNotZero_WithSelector_WhenEvaluated_ReturnsExpectedResult(int actual, bool expected)
        {
            IntHolder value = new() { Value = actual };

            bool result = GuardTest.IsNotZero<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsNotZero_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool result = GuardTest.IsNotZero<IntHolder, int>(value, x => x.Value).Return(true, _ => false);

            Assert.False(result);
        }

        [Fact]
        public void IsNotZero_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new() { Value = 1 };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsNotZero<IntHolder, int>(value, null!));
        }

        #endregion

        private sealed class IntHolder
        {
            public int Value { get; set; }
        }
    }
}
