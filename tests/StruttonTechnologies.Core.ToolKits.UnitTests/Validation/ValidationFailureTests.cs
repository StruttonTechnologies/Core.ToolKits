using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Validation;

public sealed class ValidationFailureTests
{
    [Fact]
    public void Error_CreatesErrorFailure()
    {
        var failure = ValidationFailure.Error(
            "bad",
            code: "Invalid",
            field: "Name",
            suggestions: ["Try again"],
            metadata: new Dictionary<string, object> { ["x"] = 5 });

        Assert.Equal("bad", failure.Message);
        Assert.Equal("Invalid", failure.Code);
        Assert.Equal("Name", failure.Field);
        Assert.Equal("Try again", Assert.Single(failure.Suggestions!));
        Assert.Equal(5, failure.Metadata!["x"]);
        Assert.Equal(ValidationSeverity.Error, failure.Severity);
    }

    [Fact]
    public void Warning_CreatesWarningFailure()
    {
        var failure = ValidationFailure.Warning("careful");

        Assert.Equal("careful", failure.Message);
        Assert.Equal(ValidationSeverity.Warning, failure.Severity);
    }

    [Fact]
    public void Create_UsesSpecifiedSeverity()
    {
        var failure = ValidationFailure.Create("info", ValidationSeverity.Info);

        Assert.Equal(ValidationSeverity.Info, failure.Severity);
    }

    [Fact]
    public void With_ReturnsUpdatedCopy()
    {
        var original = ValidationFailure.Error("bad", code: "A", field: "One");

        var updated = original.With(message: "worse", field: "Two", severity: ValidationSeverity.Warning);

        Assert.Equal("worse", updated.Message);
        Assert.Equal("A", updated.Code);
        Assert.Equal("Two", updated.Field);
        Assert.Equal(ValidationSeverity.Warning, updated.Severity);
    }
}
