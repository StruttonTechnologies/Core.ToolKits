using StruttonTechnologies.Core.ToolKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithSelector_WhenSelectorReturnsCollectionWithMultipleItems_ReturnsMatched
{
    [Fact]
    public void Test()
    {
        TestObject value = new TestObject { Items = [1, 2, 3] };

        GuardCondition<TestObject> result = Guard.HasItems(value, obj => obj.Items);

        bool actual = result.Return(true, _ => false);
        Assert.True(actual);
    }

    private class TestObject
    {
        public IEnumerable<int>? Items { get; set; }
    }
}
