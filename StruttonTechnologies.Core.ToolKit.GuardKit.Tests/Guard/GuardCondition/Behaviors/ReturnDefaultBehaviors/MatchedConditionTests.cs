namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnDefaultBehaviors
{
    /// <summary>
    /// Contains matched-condition test scenarios for <c>ReturnDefault</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void ReturnDefault_WhenMatched_ReturnsDefault()
        {
            string? result = GuardTest.IsTrue(true).ReturnDefault<string>(_ => "fallback");

            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnDefaultAsync_WhenMatched_ReturnsDefault()
        {
            string? result = await GuardTest.IsTrue(true).ReturnDefault(_ => Task.FromResult("fallback"));

            Assert.Null(result);
        }
    }
}
