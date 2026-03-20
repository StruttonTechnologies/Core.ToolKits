namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Equality
{
    /// <summary>
    /// Contains test scenarios for equality-based guard evaluators.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EqualityTests
    {
        [Fact]
        public void IsEqual_WhenValuesAreEqual_ReturnsMatched()
        {
            bool matched = GuardTest.IsEqual("abc", "abc").Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsEqual_WhenValuesAreDifferent_ReturnsNotMatched()
        {
            bool matched = GuardTest.IsEqual("abc", "xyz").Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEqual_WithSelector_WhenSelectedValueMatches_ReturnsMatched()
        {
            IntHolder value = new IntHolder { Value = 5 };

            bool matched = GuardTest.IsEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsEqual_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool matched = GuardTest.IsEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEqual_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new IntHolder { Value = 5 };
            Func<IntHolder, int> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => GuardTest.IsEqual(value, selector, 5));

            Assert.Equal("selector", exception.ParamName);
        }

        [Fact]
        public void IsNotEqual_WhenValuesAreDifferent_ReturnsMatched()
        {
            bool matched = GuardTest.IsNotEqual("abc", "xyz").Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotEqual_WhenValuesAreEqual_ReturnsNotMatched()
        {
            bool matched = GuardTest.IsNotEqual("abc", "abc").Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotEqual_WithSelector_WhenSelectedValueDiffers_ReturnsMatched()
        {
            IntHolder value = new IntHolder { Value = 7 };

            bool matched = GuardTest.IsNotEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsNotEqual_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            IntHolder? value = null;

            bool matched = GuardTest.IsNotEqual(value, x => x.Value, 5).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsNotEqual_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            IntHolder value = new IntHolder { Value = 7 };
            Func<IntHolder, int> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => GuardTest.IsNotEqual(value, selector, 5));

            Assert.Equal("selector", exception.ParamName);
        }

        [ExcludeFromCodeCoverage]
        private sealed class IntHolder
        {
            public int Value { get; set; }
        }
    }
}
