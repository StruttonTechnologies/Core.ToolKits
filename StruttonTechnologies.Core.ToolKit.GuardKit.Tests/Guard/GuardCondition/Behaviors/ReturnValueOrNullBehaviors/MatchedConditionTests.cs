namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnValueOrNullBehaviors
{
    /// <summary>
    /// Contains matched-condition test scenarios for <c>ReturnValueOrNull()</c>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void ReturnValueOrNull_WhenConditionIsMatched_ReturnsNull()
        {
            string? result = GuardTest.IsNull<string>(null)
                .ReturnValueOrNull();

            Assert.Null(result);
        }
    }
}
