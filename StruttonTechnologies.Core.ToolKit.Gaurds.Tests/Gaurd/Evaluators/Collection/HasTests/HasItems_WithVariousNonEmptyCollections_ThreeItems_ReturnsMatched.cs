using StruttonTechnologies.Core.ToolKit.Guards;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithVariousNonEmptyCollections_ThreeItems_ReturnsMatched
{
    [Fact]
    public void Test()
    {
        string[] value = ["a", "b", "c"];

        GuardCondition<IEnumerable<string>> result = Guard.HasItems(value);

        bool actual = result.Return(true, _ => false);
        Assert.True(actual);
    }
}
