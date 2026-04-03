using System;
using System.Diagnostics.CodeAnalysis;

using GuardHelpers = global::StruttonTechnologies.Core.ToolKit.GuardKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Guard.Assertions
{
    [ExcludeFromCodeCoverage]
    public sealed class GuardConditionAssertionsTests
    {
        [Fact]
        public void AssertMatched_DoesNotThrow_WhenConditionMatched()
        {
            GuardCondition<string> condition = GuardHelpers.IsNull<string>(null);

            GuardAssertions.AssertMatched(condition);
        }

        [Fact]
        public void AssertMatched_Throws_WhenConditionDidNotMatch()
        {
            GuardCondition<string> condition = GuardHelpers.IsNull("value");

            Assert.ThrowsAny<global::System.Exception>(() => GuardAssertions.AssertMatched(condition));
        }

        [Fact]
        public void AssertNotMatched_DoesNotThrow_WhenConditionDidNotMatch()
        {
            GuardCondition<string> condition = GuardHelpers.IsNull("value");

            GuardAssertions.AssertNotMatched(condition);
        }

        [Fact]
        public void AssertNotMatched_Throws_WhenConditionMatched()
        {
            GuardCondition<string> condition = GuardHelpers.IsNull<string>(null);

            Assert.ThrowsAny<global::System.Exception>(() => GuardAssertions.AssertNotMatched(condition));
        }
    }
}
