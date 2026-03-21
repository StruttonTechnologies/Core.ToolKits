namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnEmptyCollectionBehaviors
{
    /// <summary>
    /// Contains not-matched-condition test scenarios for empty collection return behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public async Task ReturnEmptyArray_WhenNotMatched_ReturnsFactoryValue()
        {
            int[] result = await GuardTest.IsTrue(false).ReturnEmptyArray(_ => Task.FromResult(new[] { 1, 2, 3 }));

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public async Task ReturnEmptyEnumerable_WhenNotMatched_ReturnsFactoryValue()
        {
            IEnumerable<int> result = await GuardTest.IsTrue(false).ReturnEmptyEnumerable(_ => Task.FromResult<IEnumerable<int>>(new[] { 1, 2, 3 }));

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public async Task ReturnEmptyList_WhenNotMatched_ReturnsFactoryValue()
        {
            List<int> result = await GuardTest.IsTrue(false).ReturnEmptyList(_ => Task.FromResult(new List<int> { 1, 2, 3 }));

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }
    }
}
