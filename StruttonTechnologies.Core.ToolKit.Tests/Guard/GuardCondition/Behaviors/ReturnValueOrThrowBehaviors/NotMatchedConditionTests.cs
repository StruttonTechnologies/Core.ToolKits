using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValueOrThrowBehaviors
{
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void ReturnOrThrow_ShouldReturnValue_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);

            var result = condition.ReturnOrThrow(() => new InvalidOperationException("Should not throw"));

            Assert.Equal(testValue, result);
        }

        [Fact]
        public void ReturnOrThrow_ShouldReturnValue_WhenFalseConditionIsNotMatched()
        {
            var testValue = false;
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsTrue(testValue);

            var result = condition.ReturnOrThrow(() => new InvalidOperationException("Should not throw"));

            Assert.False(result);
        }

        [Theory]
        [InlineData("valid")]
        [InlineData("test")]
        [InlineData("non-empty")]
        public void ReturnOrThrow_ShouldReturnValue_WhenStringHasValue(string value)
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNullOrEmpty(value);

            var result = condition.ReturnOrThrow(() => new ArgumentException("Should not throw"));

            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-5)]
        public void ReturnOrThrow_ShouldReturnValue_WhenNumberIsNotZero(int value)
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsZero(value);

            var result = condition.ReturnOrThrow(() => new InvalidOperationException("Should not throw"));

            Assert.Equal(value, result);
        }
    }
}
