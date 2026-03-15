using StruttonTechnologies.Core.ToolKit.Guards;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection.HasTests
{
    public class HasItems_WithSingleItem_ReturnsMatched
    {
        [Fact]
        public void Test()
        {
            int[] value = new[] { 1 };

            GuardCondition<IEnumerable<int>> result = Guard.HasItems(value);

            bool actual = result.Return(true, _ => false);
            Assert.True(actual);
        }
    }
}
