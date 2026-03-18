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
            Assert.True(Guard.IsType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WhenValueIsDifferentType_ReturnsNotMatched()
        {
            object value = 42;
            Assert.False(Guard.IsType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenSelectedValueIsExpectedType_ReturnsMatched()
        {
            var value = new ValueTestObject<object> { Value = "hello" };
            Assert.True(Guard.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsType_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            ValueTestObject<object>? value = null;
            Assert.False(Guard.IsType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WhenValueIsDifferentType_ReturnsMatched()
        {
            object value = 42;
            Assert.True(Guard.IsNotType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WhenValueIsExpectedType_ReturnsNotMatched()
        {
            object value = "hello";
            Assert.False(Guard.IsNotType<string>(value).Return(true, _ => false));
        }

        [Fact]
        public void IsNotType_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            ValueTestObject<object>? value = null;
            Assert.True(Guard.IsNotType<ValueTestObject<object>, string>(value, x => x.Value).Return(true, _ => false));
        }
    }
}
