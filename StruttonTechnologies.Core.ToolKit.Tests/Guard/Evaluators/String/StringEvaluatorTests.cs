namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.String
{
    /// <summary>
    /// Contains test scenarios for string guard evaluators.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StringEvaluatorTests
    {
        /// <summary>
        /// Tests for HasValue (direct and selector overloads).
        /// </summary>
        #region HasValue

        [Theory]
        [InlineData("hello", true)]
        [InlineData("value", true)]
        [InlineData("a", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("  ", false)]
        [InlineData("\t", false)]
        public void HasValue_WhenEvaluated_ReturnsExpectedResult(string? value, bool expected)
        {
            Assert.Equal(expected, GuardTest.HasValue(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData("hello", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void HasValue_WithSelector_WhenEvaluated_ReturnsExpectedResult(string? input, bool expected)
        {
            StringHolder value = new() { Value = input };

            bool result = GuardTest.HasValue(value, x => x.Value).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasValue_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            StringHolder? value = null;

            Assert.False(GuardTest.HasValue(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void HasValue_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            StringHolder value = new() { Value = "hello" };

            Assert.Throws<ArgumentNullException>(() => GuardTest.HasValue<StringHolder>(value, null!));
        }

        #endregion

        /// <summary>
        /// Tests for IsEmpty (direct and selector overloads).
        /// </summary>
        #region IsEmpty

        [Theory]
        [InlineData("", true)]
        [InlineData("hello", false)]
        [InlineData(" ", false)]
        public void IsEmpty_WhenEvaluated_ReturnsExpectedResult(string value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsEmpty(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData("", true)]
        [InlineData("hello", false)]
        [InlineData(" ", false)]
        public void IsEmpty_WithSelector_WhenEvaluated_ReturnsExpectedResult(string input, bool expected)
        {
            StringHolder value = new() { Value = input };

            bool result = GuardTest.IsEmpty(value, x => x.Value!).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsEmpty_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            StringHolder? value = null;

            Assert.False(GuardTest.IsEmpty(value, x => x.Value!).Return(true, _ => false));
        }

        [Fact]
        public void IsEmpty_WithNull_ReturnsNotMatched()
        {
            GuardCondition<string> result = GuardTest.IsEmpty(null!);

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEmpty_WithEmptyString_ReturnsMatched()
        {
            GuardCondition<string> result = GuardTest.IsEmpty("");

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsEmpty_WithNonEmptyString_ReturnsNotMatched()
        {
            GuardCondition<string> result = GuardTest.IsEmpty("hello");

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEmpty_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            StringHolder value = new() { Value = "" };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsEmpty<StringHolder>(value, null!));
        }

        #endregion

        /// <summary>
        /// Tests for IsNullOrEmpty (direct and selector overloads).
        /// </summary>
        #region IsNullOrEmpty

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", false)]
        [InlineData("hello", false)]
        public void IsNullOrEmpty_WhenEvaluated_ReturnsExpectedResult(string? value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsNullOrEmpty(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("hello", false)]
        public void IsNullOrEmpty_WithSelector_WhenEvaluated_ReturnsExpectedResult(string? input, bool expected)
        {
            StringHolder value = new() { Value = input };

            bool result = GuardTest.IsNullOrEmpty(value, x => x.Value!).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsNullOrEmpty_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            StringHolder? value = null;

            Assert.True(GuardTest.IsNullOrEmpty(value, x => x.Value!).Return(true, _ => false));
        }

        [Fact]
        public void IsNullOrEmpty_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            StringHolder value = new() { Value = "hello" };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsNullOrEmpty<StringHolder>(value, null!));
        }

        #endregion

        /// <summary>
        /// Tests for IsNullOrWhiteSpace (direct and selector overloads).
        /// </summary>
        #region IsNullOrWhiteSpace

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("hello", false)]
        public void IsNullOrWhiteSpace_WhenEvaluated_ReturnsExpectedResult(string? value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsNullOrWhiteSpace(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("hello", false)]
        public void IsNullOrWhiteSpace_WithSelector_WhenEvaluated_ReturnsExpectedResult(string? input, bool expected)
        {
            StringHolder value = new() { Value = input };

            bool result = GuardTest.IsNullOrWhiteSpace(value, x => x.Value!).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsNullOrWhiteSpace_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            StringHolder value = new() { Value = "hello" };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsNullOrWhiteSpace<StringHolder>(value, null!));
        }

        [Fact]
        public void IsNullOrWhiteSpace_WithSelector_WhenValueIsNull_ReturnsMatched()
        {
            string? value = null;

            GuardCondition<string> result = GuardTest.IsNullOrWhiteSpace(value, x => x);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNullOrWhiteSpace_WithSelector_WhenValueIsNull_DoesNotInvokeSelector()
        {
            string? value = null;
            bool selectorCalled = false;

            GuardCondition<string> result = GuardTest.IsNullOrWhiteSpace(
                value,
                x =>
                {
                    selectorCalled = true;
                    return x;
                });

            result.Return(true, _ => false);

            Assert.False(selectorCalled);
        }

        #endregion

        /// <summary>
        /// Tests for IsWhiteSpace (direct and selector overloads).
        /// </summary>
        #region IsWhiteSpace

        [Theory]
        [InlineData(" ", true)]
        [InlineData("\t", true)]
        [InlineData("", false)]
        [InlineData("hello", false)]
        public void IsWhiteSpace_WhenEvaluated_ReturnsExpectedResult(string? value, bool expected)
        {
            Assert.Equal(expected, GuardTest.IsWhiteSpace(value).Return(true, _ => false));
        }

        [Theory]
        [InlineData(" ", true)]
        [InlineData("\t", true)]
        [InlineData("hello", false)]
        public void IsWhiteSpace_WithSelector_WhenEvaluated_ReturnsExpectedResult(string input, bool expected)
        {
            StringHolder value = new() { Value = input };

            bool result = GuardTest.IsWhiteSpace(value, x => x.Value!).Return(true, _ => false);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsWhiteSpace_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            StringHolder? value = null;

            Assert.False(GuardTest.IsWhiteSpace(value, x => x.Value!).Return(true, _ => false));
        }

        [Fact]
        public void IsWhiteSpace_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            StringHolder value = new() { Value = " " };

            Assert.Throws<ArgumentNullException>(() => GuardTest.IsWhiteSpace<StringHolder>(value, null!));
        }

        #endregion

        private sealed class StringHolder
        {
            public string? Value { get; set; }
        }
    }
}
