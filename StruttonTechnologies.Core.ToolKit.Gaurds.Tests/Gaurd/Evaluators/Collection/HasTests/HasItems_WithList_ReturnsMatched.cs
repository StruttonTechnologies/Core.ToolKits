using StruttonTechnologies.Core.ToolKit.Guards;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithList_ReturnsMatched
{
    [Fact]
    public void Test()
    {
        List<double> value = [1.5, 2.5];

        GuardCondition<IEnumerable<double>> result = Guard.HasItems(value);

        bool actual = result.Return(true, _ => false);
        Assert.True(actual);
    }
}
