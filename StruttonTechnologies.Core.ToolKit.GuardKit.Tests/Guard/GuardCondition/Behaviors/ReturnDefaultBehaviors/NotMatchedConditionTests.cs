namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnDefaultBehaviors
{
    /// <summary>
    /// Contains not-matched-condition test scenarios for <c>ReturnDefault</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void ReturnDefault_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = GuardTest.IsTrue(false).ReturnDefault<string>(_ => "fallback");

            Assert.Equal("fallback", result);
        }

        [Fact]
        public async Task ReturnDefaultAsync_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = await GuardTest.IsTrue(false).ReturnDefault(_ => Task.FromResult("fallback"));

            Assert.Equal("fallback", result);
        }
    }
}
