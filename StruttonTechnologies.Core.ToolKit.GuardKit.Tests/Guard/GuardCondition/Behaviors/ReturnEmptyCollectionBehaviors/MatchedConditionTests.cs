namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnEmptyCollectionBehaviors
{
    /// <summary>
    /// Contains matched-condition test scenarios for empty collection return behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public async Task ReturnEmptyArray_WhenMatched_ReturnsEmptyArray()
        {
            int[] result = await GuardTest.IsTrue(true).ReturnEmptyArray(_ => Task.FromResult(new[] { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyEnumerable_WhenMatched_ReturnsEmptyEnumerable()
        {
            IEnumerable<int> result = await GuardTest.IsTrue(true).ReturnEmptyEnumerable(_ => Task.FromResult<IEnumerable<int>>(new[] { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyList_WhenMatched_ReturnsEmptyList()
        {
            List<int> result = await GuardTest.IsTrue(true).ReturnEmptyList(_ => Task.FromResult(new List<int> { 1, 2, 3 }));

            Assert.Empty(result);
        }
    }
}
