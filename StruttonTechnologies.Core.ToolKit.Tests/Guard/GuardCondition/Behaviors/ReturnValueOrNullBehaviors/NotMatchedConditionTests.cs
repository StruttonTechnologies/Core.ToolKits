namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnValueOrNullBehaviors
{
    /// <summary>
    /// Contains not-matched-condition test scenarios for <c>ReturnValueOrNull</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void ReturnValueOrNull_WhenConditionIsNotMatched_ReturnsOriginalValue()
        {
            const string Expected = "value";

            string? result = GuardTest.IsNull(Expected)
                .ReturnValueOrNull();

            Assert.Equal(Expected, result);
        }

        [Fact]
        public void ReturnValueOrNull_WhenConditionIsNotMatched_ReturnsSameReference()
        {
            object expected = new();

            object? result = GuardTest.IsNull(expected)
                .ReturnValueOrNull();

            Assert.Same(expected, result);
        }
    }
}
