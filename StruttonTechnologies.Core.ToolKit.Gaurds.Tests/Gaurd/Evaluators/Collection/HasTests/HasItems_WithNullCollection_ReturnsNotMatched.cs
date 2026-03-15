using StruttonTechnologies.Core.ToolKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithNullCollection_ReturnsNotMatched
{
    [Fact]
    public void Test()
    {
        IEnumerable<int>? value = null;

        GuardCondition<IEnumerable<int>> result = Guard.HasItems(value);

        bool actual = result.Return(true, _ => false);
        Assert.False(actual);
    }
}
