namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.GuardTests.Assertions
{
    [ExcludeFromCodeCoverage]
    public sealed class GuardConditionAssertionsTests
    {
        [Fact]
        public void AssertMatched_DoesNotThrow_WhenConditionMatched()
        {
            GuardCondition<string> condition = Guard.IsNull<string>(null);

            GuardAssertions.AssertMatched(condition);
        }

        [Fact]
        public void AssertMatched_Throws_WhenConditionDidNotMatch()
        {
            GuardCondition<string> condition = Guard.IsNull("value");

            Assert.ThrowsAny<Exception>(() => GuardAssertions.AssertMatched(condition));
        }

        [Fact]
        public void AssertNotMatched_DoesNotThrow_WhenConditionDidNotMatch()
        {
            GuardCondition<string> condition = Guard.IsNull("value");

            GuardAssertions.AssertNotMatched(condition);
        }

        [Fact]
        public void AssertNotMatched_Throws_WhenConditionMatched()
        {
            GuardCondition<string> condition = Guard.IsNull<string>(null);

            Assert.ThrowsAny<Exception>(() => GuardAssertions.AssertNotMatched(condition));
        }
    }
}
