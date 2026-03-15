namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Gaurd.Evaluators.Collection;

public class HasItems_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException
{
    [Fact]
    public void Test()
    {
        TestObject value = new TestObject { Items = [1, 2] };

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.HasItems<TestObject, int>(value, null!));

        Assert.Equal("selector", exception.ParamName);
    }

    private class TestObject
    {
        public IEnumerable<int>? Items { get; set; }
    }
}
