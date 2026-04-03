namespace StruttonTechnologies.Core.ToolKit.TestingKit.Tests.GuardTests.Conditions
{
    public sealed class GuardConditionTestHelperTests
    {
        [Fact]
        public void IsMatched_ReturnsTrue_WhenConditionMatched()
        {
            GuardCondition<string> condition = Guard.IsNull<string>(null);

            bool result = GuardTestHelper.IsMatched(condition);

            Assert.True(result);
        }

        [Fact]
        public void IsMatched_ReturnsFalse_WhenConditionDidNotMatch()
        {
            GuardCondition<string> condition = Guard.IsNull("value");

            bool result = GuardTestHelper.IsMatched(condition);

            Assert.False(result);
        }

        [Fact]
        public void IsNotMatched_ReturnsTrue_WhenConditionDidNotMatch()
        {
            GuardCondition<string> condition = Guard.IsNull("value");

            bool result = GuardTestHelper.IsNotMatched(condition);

            Assert.True(result);
        }

        [Fact]
        public void IsNotMatched_ReturnsFalse_WhenConditionMatched()
        {
            GuardCondition<string> condition = Guard.IsNull<string>(null);

            bool result = GuardTestHelper.IsNotMatched(condition);

            Assert.False(result);
        }

        [Fact]
        public void IsMatched_And_IsNotMatched_AreLogicalOpposites()
        {
            GuardCondition<string> matchedCondition = Guard.IsNull<string>(null);
            GuardCondition<string> notMatchedCondition = Guard.IsNull("value");

            Assert.NotEqual(GuardTestHelper.IsMatched(matchedCondition), GuardTestHelper.IsNotMatched(matchedCondition));
            Assert.NotEqual(GuardTestHelper.IsMatched(notMatchedCondition), GuardTestHelper.IsNotMatched(notMatchedCondition));
        }
    }
}
