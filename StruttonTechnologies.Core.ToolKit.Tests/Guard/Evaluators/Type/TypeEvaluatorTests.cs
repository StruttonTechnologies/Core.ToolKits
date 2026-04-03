namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Type
{
    /// <summary>
    /// Contains test scenarios for type guard evaluators.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TypeEvaluatorTests
    {
        /// <summary>
        /// Tests for IsType direct and selector overloads.
        /// </summary>
        #region IsType

        [Fact]
        public void IsType_WhenValueIsExpectedType_ReturnsMatched()
        {
            object value = "hello";

            Assert.True(GuardTest.IsType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WhenValueIsDifferentType_ReturnsNotMatched()
        {
            object value = 42;

            Assert.False(GuardTest.IsType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenSelectedValueIsExpectedType_ReturnsMatched()
        {
            ValueTestObject<object> value = new() { Value = "hello" };

            Assert.True(GuardTest.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenSelectedValueIsDifferentType_ReturnsNotMatched()
        {
            ValueTestObject<object> value = new() { Value = 42 };

            Assert.False(GuardTest.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            ValueTestObject<object>? value = null;

            Assert.False(GuardTest.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            ValueTestObject<object> value = new() { Value = "hello" };

            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsType<ValueTestObject<object>, string>(value, null!));
        }

        #endregion

        /// <summary>
        /// Tests for IsNotType direct and selector overloads.
        /// </summary>
        #region IsNotType

        [Fact]
        public void IsNotType_WhenValueIsDifferentType_ReturnsMatched()
        {
            object value = 42;

            Assert.True(GuardTest.IsNotType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WhenValueIsExpectedType_ReturnsNotMatched()
        {
            object value = "hello";

            Assert.False(GuardTest.IsNotType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WithSelector_WhenSelectedValueIsDifferentType_ReturnsMatched()
        {
            ValueTestObject<object> value = new() { Value = 42 };

            Assert.True(GuardTest.IsNotType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WithSelector_WhenSelectedValueIsExpectedType_ReturnsNotMatched()
        {
            ValueTestObject<object> value = new() { Value = "hello" };

            Assert.False(GuardTest.IsNotType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            ValueTestObject<object>? value = null;

            Assert.True(GuardTest.IsNotType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            ValueTestObject<object> value = new() { Value = "hello" };

            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsNotType<ValueTestObject<object>, string>(value, null!));
        }

        #endregion
    }
}
