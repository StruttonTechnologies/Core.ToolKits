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
            bool matched = GuardTest.IsDefault(0).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsDefault_WhenValueIsNotDefault_ReturnsNotMatched()
        {
            bool matched = GuardTest.IsDefault(10).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsDefault_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            IntHolder? value = null;

            bool matched = GuardTest.IsDefault(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsDefault_WithSelector_WhenSelectedValueIsDefault_ReturnsMatched()
        {
            IntHolder value = new IntHolder { Value = 0 };

            bool matched = GuardTest.IsDefault(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsDefault_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new IntHolder { Value = 0 };
            Func<IntHolder, int> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => GuardTest.IsDefault(value, selector));

            Assert.Equal("selector", exception.ParamName);
        }

        [Fact]
        public void IsNotDefault_WhenValueIsNotDefault_ReturnsMatched()
        {
            bool matched = GuardTest.IsNotDefault(10).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotDefault_WhenValueIsDefault_ReturnsNotMatched()
        {
            bool matched = GuardTest.IsNotDefault(0).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotDefault_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool matched = GuardTest.IsNotDefault(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotDefault_WithSelector_WhenSelectedValueIsNotDefault_ReturnsMatched()
        {
            IntHolder value = new IntHolder { Value = 42 };

            bool matched = GuardTest.IsNotDefault(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNull_WhenValueIsNull_ReturnsMatched()
        {
            string? value = null;

            bool matched = GuardTest.IsNull(value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNull_WhenValueIsNotNull_ReturnsNotMatched()
        {
            bool matched = GuardTest.IsNull("abc").Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNull_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            StringHolder? value = null;

            bool matched = GuardTest.IsNull(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNull_WithSelector_WhenSelectedValueIsNull_ReturnsMatched()
        {
            StringHolder value = new StringHolder { Value = null };

            bool matched = GuardTest.IsNull(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotNull_WhenValueIsNotNull_ReturnsMatched()
        {
            bool matched = GuardTest.IsNotNull("abc").Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotNull_WhenValueIsNull_ReturnsNotMatched()
        {
            string? value = null;

            bool matched = GuardTest.IsNotNull(value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotNull_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            StringHolder? value = null;

            bool matched = GuardTest.IsNotNull(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotNull_WithSelector_WhenSelectedValueIsNotNull_ReturnsMatched()
        {
            StringHolder value = new StringHolder { Value = "abc" };

            bool matched = GuardTest.IsNotNull(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Theory]
        [MemberData(nameof(BooleanTheoryData.TrueAndFalse), MemberType = typeof(BooleanTheoryData))]
        public void IsTrue_WhenEvaluated_ReturnsExpectedResult(bool value)
        {
            bool matched = GuardTest.IsTrue(value).Return(true, _ => false);

            Assert.Equal(value, matched);
        }

        [Fact]
        public void IsTrue_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            BoolHolder? value = null;

            bool matched = GuardTest.IsTrue(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsTrue_WithSelector_WhenSelectedValueIsFalse_ReturnsNotMatched()
        {
            BoolHolder value = new BoolHolder { Value = false };

            bool matched = GuardTest.IsTrue(value, x => x.Value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Theory]
        [MemberData(nameof(BooleanTheoryData.TrueAndFalse), MemberType = typeof(BooleanTheoryData))]
        public void IsFalse_WhenEvaluated_ReturnsExpectedResult(bool value)
        {
            bool matched = GuardTest.IsFalse(value).Return(true, _ => false);

            Assert.Equal(!value, matched);
        }

        [Fact]
        public void IsFalse_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            BoolHolder? value = null;

            bool matched = GuardTest.IsFalse(value, x => x.Value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsFalse_WithSelector_WhenSelectedValueIsTrue_ReturnsNotMatched()
        {
            BoolHolder value = new BoolHolder { Value = true };

            bool matched = GuardTest.IsFalse(value, x => x.Value).Return(true, _ => false);

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
