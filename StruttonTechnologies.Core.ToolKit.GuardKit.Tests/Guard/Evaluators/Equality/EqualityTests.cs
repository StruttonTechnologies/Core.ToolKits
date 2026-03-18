namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Equality
{
    /// <summary>
    /// Contains test scenarios for equality-based guard evaluators.
    /// </summary>
    public class EqualityTests
    {
        [Fact]
        public void IsEqual_WhenValuesAreEqual_ReturnsMatched()
        {
            bool matched = Guard.IsEqual("abc", "abc").Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsEqual_WhenValuesAreDifferent_ReturnsNotMatched()
        {
            bool matched = Guard.IsEqual("abc", "xyz").Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEqual_WithSelector_WhenSelectedValueMatches_ReturnsMatched()
        {
            var value = new IntHolder { Value = 5 };

            bool matched = Guard.IsEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsEqual_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool matched = Guard.IsEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEqual_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            var value = new IntHolder { Value = 5 };
            Func<IntHolder, int> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.IsEqual(value, selector, 5));

            Assert.Equal("selector", exception.ParamName);
        }

        [Fact]
        public void IsNotEqual_WhenValuesAreDifferent_ReturnsMatched()
        {
            bool matched = Guard.IsNotEqual("abc", "xyz").Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotEqual_WhenValuesAreEqual_ReturnsNotMatched()
        {
            bool matched = Guard.IsNotEqual("abc", "abc").Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotEqual_WithSelector_WhenSelectedValueDiffers_ReturnsMatched()
        {
            var value = new IntHolder { Value = 7 };

            bool matched = Guard.IsNotEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotEqual_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool matched = Guard.IsNotEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotEqual_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            var value = new IntHolder { Value = 7 };
            Func<IntHolder, int> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotEqual(value, selector, 5));

            Assert.Equal("selector", exception.ParamName);
        }

        private sealed class IntHolder
        {
            public int Value { get; set; }
        }
    }
}
