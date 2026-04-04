using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValueOrThrowBehaviors
{
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void ReturnOrThrow_ShouldThrowException_WhenConditionIsMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);

            Assert.False(condition.Return(true, _ => false));

            var nullCondition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<InvalidOperationException>(() =>
                nullCondition.ReturnOrThrow(() => new InvalidOperationException("Value was null")));

            Assert.Equal("Value was null", exception.Message);
        }

        [Fact]
        public void ReturnOrThrow_ShouldThrowCustomException_WhenConditionIsMatched()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsTrue(true);

            var exception = Assert.Throws<InvalidOperationException>(() =>
                condition.ReturnOrThrow(() => new InvalidOperationException("Expected exception")));

            Assert.Equal("Expected exception", exception.Message);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        public void ReturnOrThrow_ShouldThrowException_WhenStringIsWhitespace(string value)
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsWhiteSpace(value);

            var exception = Assert.Throws<ArgumentException>(() =>
                condition.ReturnOrThrow(() => new ArgumentException("String cannot be whitespace")));

            Assert.Equal("String cannot be whitespace", exception.Message);
        }
    }
}
