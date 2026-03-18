namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Type
{
    /// <summary>
    /// Contains test scenarios for type guard evaluators.
    /// </summary>
    public class TypeEvaluatorTests
    {
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
            ValueTestObject<object> value = new ValueTestObject<object> { Value = "hello" };
            Assert.True(GuardTest.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            ValueTestObject<object>? value = null;
            Assert.False(GuardTest.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

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
        public void IsNotType_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            ValueTestObject<object>? value = null;
            Assert.True(GuardTest.IsNotType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }
    }
}
