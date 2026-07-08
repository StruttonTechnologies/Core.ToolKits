using StruttonTechnologies.Core.ToolKit.Exceptions;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Exceptions;

public sealed class ExceptionTests
{
    [Fact]
    public void DatabaseException_StoresEntityAndOperation()
    {
        var exception = new DatabaseException("failed", "User", "Insert");

        Assert.Equal("failed", exception.Message);
        Assert.Equal("User", exception.EntityName);
        Assert.Equal("Insert", exception.Operation);
    }

    [Fact]
    public void ValidationException_StoresFilteredErrors()
    {
        var exception = new ValidationException(["One", "", "Two"]);

        Assert.Equal(["One", "Two"], exception.ValidationErrors);
    }

    [Fact]
    public void ExceptionExtensions_ReturnInnermostExceptionAndMessages()
    {
        var inner = new InvalidOperationException("inner");
        var outer = new Exception("outer", inner);

        Assert.Same(inner, outer.GetInnermostException());
        Assert.Equal("inner", outer.GetInnermostMessage());
        Assert.Equal(["outer", "inner"], outer.FlattenMessages());
    }
}
