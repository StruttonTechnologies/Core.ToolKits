using StruttonTechnologies.Core.ToolKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithEmptyCollection_ReturnsNotMatched
{
    [Fact]
    public void Test()
    {
        IEnumerable<int> value = Enumerable.Empty<int>();

        GuardCondition<IEnumerable<int>> result = Guard.HasItems(value);

        bool actual = result.Return(true, _ => false);
        Assert.False(actual);
    }
}
