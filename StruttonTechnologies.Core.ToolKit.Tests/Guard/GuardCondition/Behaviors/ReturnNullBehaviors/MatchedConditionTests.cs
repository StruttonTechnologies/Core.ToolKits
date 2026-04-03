namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnNullBehaviors
{
    /// <summary>
    /// Contains matched-condition test scenarios for <c>ReturnNull</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void ReturnNull_WhenMatched_ReturnsNull()
        {
            string? result = GuardTest.IsTrue(true).ReturnNull(_ => "fallback");

            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnNullAsync_WhenMatched_ReturnsNull()
        {
            string? result = await GuardTest.IsTrue(true).ReturnNull(_ => Task.FromResult("fallback"));

            Assert.Null(result);
        }
    }
}
