namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnBehaviors
{
    /// <summary>
    /// Contains not-matched-condition test scenarios for <c>Return</c> and <c>ReturnAsync</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void Return_WithMatchedConstant_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(false).Return("matched", value => value ? "matched" : "not-matched");

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public void Return_WithMatchedFactory_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(false).Return(() => "matched", value => value ? "matched" : "not-matched");

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedConstant_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(false)
                .ReturnAsync("matched", value => Task.FromResult(value ? "matched" : "not-matched"));

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedFactory_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(false)
                .ReturnAsync(() => Task.FromResult("matched"), value => Task.FromResult(value ? "matched" : "not-matched"));

            Assert.Equal("not-matched", result);
        }
    }
}
