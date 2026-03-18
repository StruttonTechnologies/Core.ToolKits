namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.General
{
    /// <summary>
    /// Contains test scenarios for general guard evaluators.
    /// </summary>
    public class GeneralEvaluatorTests
    {
        [Fact]
        public void IsDefault_WhenValueIsDefault_ReturnsMatched()
        {
            bool matched = Guard.IsDefault(0).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsDefault_WhenValueIsNotDefault_ReturnsNotMatched()
        {
            bool matched = Guard.IsDefault(10).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsDefault_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            IntHolder? value = null;

            bool matched = Guard.IsDefault(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsDefault_WithSelector_WhenSelectedValueIsDefault_ReturnsMatched()
        {
            var value = new IntHolder { Value = 0 };

            bool matched = Guard.IsDefault(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsDefault_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            var value = new IntHolder { Value = 0 };
            Func<IntHolder, int> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.IsDefault(value, selector));

            Assert.Equal("selector", exception.ParamName);
        }

        [Fact]
        public void IsNotDefault_WhenValueIsNotDefault_ReturnsMatched()
        {
            bool matched = Guard.IsNotDefault(10).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotDefault_WhenValueIsDefault_ReturnsNotMatched()
        {
            bool matched = Guard.IsNotDefault(0).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotDefault_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool matched = Guard.IsNotDefault(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotDefault_WithSelector_WhenSelectedValueIsNotDefault_ReturnsMatched()
        {
            var value = new IntHolder { Value = 42 };

            bool matched = Guard.IsNotDefault(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNull_WhenValueIsNull_ReturnsMatched()
        {
            string? value = null;

            bool matched = Guard.IsNull(value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNull_WhenValueIsNotNull_ReturnsNotMatched()
        {
            bool matched = Guard.IsNull("abc").Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNull_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            StringHolder? value = null;

            bool matched = Guard.IsNull(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNull_WithSelector_WhenSelectedValueIsNull_ReturnsMatched()
        {
            var value = new StringHolder { Value = null };

            bool matched = Guard.IsNull(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotNull_WhenValueIsNotNull_ReturnsMatched()
        {
            bool matched = Guard.IsNotNull("abc").Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotNull_WhenValueIsNull_ReturnsNotMatched()
        {
            string? value = null;

            bool matched = Guard.IsNotNull(value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotNull_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            StringHolder? value = null;

            bool matched = Guard.IsNotNull(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotNull_WithSelector_WhenSelectedValueIsNotNull_ReturnsMatched()
        {
            var value = new StringHolder { Value = "abc" };

            bool matched = Guard.IsNotNull(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Theory]
        [MemberData(nameof(BooleanTheoryData.TrueAndFalse), MemberType = typeof(BooleanTheoryData))]
        public void IsTrue_WhenEvaluated_ReturnsExpectedResult(bool value)
        {
            bool matched = Guard.IsTrue(value).Return(true, _ => false);

            Assert.Equal(value, matched);
        }

        [Fact]
        public void IsTrue_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            BoolHolder? value = null;

            bool matched = Guard.IsTrue(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsTrue_WithSelector_WhenSelectedValueIsFalse_ReturnsNotMatched()
        {
            var value = new BoolHolder { Value = false };

            bool matched = Guard.IsTrue(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Theory]
        [MemberData(nameof(BooleanTheoryData.TrueAndFalse), MemberType = typeof(BooleanTheoryData))]
        public void IsFalse_WhenEvaluated_ReturnsExpectedResult(bool value)
        {
            bool matched = Guard.IsFalse(value).Return(true, _ => false);

            Assert.Equal(!value, matched);
        }

        [Fact]
        public void IsFalse_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            BoolHolder? value = null;

            bool matched = Guard.IsFalse(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsFalse_WithSelector_WhenSelectedValueIsTrue_ReturnsNotMatched()
        {
            var value = new BoolHolder { Value = true };

            bool matched = Guard.IsFalse(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        private sealed class IntHolder
        {
            public int Value { get; set; }
        }

        private sealed class BoolHolder
        {
            public bool Value { get; set; }
        }

        private sealed class StringHolder
        {
            public string? Value { get; set; }
        }
    }
}
