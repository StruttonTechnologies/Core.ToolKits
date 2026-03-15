using StruttonTechnologies.Core.ToolKit.Guards;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithSelector_ReturnsOriginalObjectInGuardCondition
{
    [Fact]
    public void Test()
    {
        TestObject value = new TestObject { Items = [1, 2], Name = "Test" };

        GuardCondition<TestObject> result = Guard.HasItems(value, obj => obj.Items);

        TestObject returnedObject = result.Return(
            matchedFactory: () => value,
            notMatchedFactory: _ => new TestObject { Name = "NotMatched" }
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
