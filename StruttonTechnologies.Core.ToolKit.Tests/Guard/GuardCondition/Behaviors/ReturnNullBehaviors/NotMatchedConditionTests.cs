namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnNullBehaviors
{
    /// <summary>
    /// Contains not-matched-condition test scenarios for <c>ReturnNull</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void ReturnNull_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = GuardTest.IsTrue(false).ReturnNull(_ => "fallback");

            Assert.Equal("fallback", result);
        }

        [Fact]
        public async Task ReturnNullAsync_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = await GuardTest.IsTrue(false).ReturnNull(_ => Task.FromResult("fallback"));

            Assert.Equal("fallback", result);
        }
    }
}
