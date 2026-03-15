using StruttonTechnologies.Core.ToolKit.Guard;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithSelector_WhenNotMatched_ReturnsOriginalObjectInGuardCondition
{
    [Fact]
    public void Test()
    {
        TestObject value = new TestObject { Items = [], Name = "Test" };

        GuardCondition<TestObject> result = Guard.HasItems(value, obj => obj.Items);

        TestObject returnedObject = result.Return(
            matchedFactory: () => new TestObject { Name = "Matched" },
            notMatchedFactory: obj => obj
        );

        Assert.Same(value, returnedObject);
        Assert.Equal("Test", returnedObject.Name);
    }

    private class TestObject
    {
        public IEnumerable<int>? Items { get; set; }
        public string? Name { get; set; }
    }
}
