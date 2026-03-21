namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnBehaviors
{
    /// <summary>
    /// Contains matched-condition test scenarios for <c>Return</c> and <c>ReturnAsync</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void Return_WithMatchedConstant_ReturnsMatchedValue()
        {
            string result = GuardTest.IsTrue(true).Return("matched", _ => "not-matched");

            Assert.Equal("matched", result);
        }

        [Fact]
        public void Return_WithMatchedFactory_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(true).Return(() => "matched", _ => "not-matched");

            Assert.Equal("matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedConstant_ReturnsMatchedValue()
        {
            string result = await GuardTest.IsTrue(true)
                .ReturnAsync("matched", _ => Task.FromResult("not-matched"));

            Assert.Equal("matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedFactory_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(true)
                .ReturnAsync(() => Task.FromResult("matched"), _ => Task.FromResult("not-matched"));

            Assert.Equal("matched", result);
        }
    }
}
