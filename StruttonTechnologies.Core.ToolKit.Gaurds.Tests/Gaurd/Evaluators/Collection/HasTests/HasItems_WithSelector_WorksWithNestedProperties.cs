using StruttonTechnologies.Core.ToolKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithSelector_WorksWithNestedProperties
{
    [Fact]
    public void Test()
    {
        ComplexObject value = new ComplexObject
        {
            Container = new TestObject { Items = [1, 2, 3] }
        };

        GuardCondition<ComplexObject> result = Guard.HasItems(value, obj => obj.Container?.Items);

        bool actual = result.Return(true, _ => false);
        Assert.True(actual);
    }

    private class TestObject
    {
        public IEnumerable<int>? Items { get; set; }
    }

    private class ComplexObject
    {
        public TestObject? Container { get; set; }
    }
}
