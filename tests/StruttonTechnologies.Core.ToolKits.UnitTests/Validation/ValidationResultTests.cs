using StruttonTechnologies.Core.ToolKit.Validation.Extensions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Validation;

public sealed class ValidationResultTests
{
    [Fact]
    public void Success_CreatesValidResult()
    {
        var result = ValidationResult.Success("ok");

        Assert.True(result.IsValid);
        Assert.Equal("ok", result.Message);
        Assert.Equal(ValidationSeverity.Info, result.Severity);
    }

    [Fact]
    public void Warning_CreatesValidWarningResultWithDetails()
    {
        var result = ValidationResult.Warning(
            "check this",
            code: "Warn",
            field: "Name",
            suggestions: ["Fix it"],
            metadata: new Dictionary<string, object> { ["source"] = "unit" },
            traceId: "trace-1");

        Assert.True(result.IsValid);
        Assert.Equal("Warn", result.Code);
        Assert.Equal("Name", result.Field);
        Assert.Equal("Fix it", Assert.Single(result.Suggestions!));
        Assert.Equal("unit", result.Metadata!["source"]);
        Assert.Equal("trace-1", result.TraceId);
        Assert.Equal(ValidationSeverity.Warning, result.Severity);
    }

    [Fact]
    public void Failure_CreatesInvalidResultWithDetails()
    {
        var exception = new InvalidOperationException("bad");
        var result = ValidationResult.Failure(
            "failed",
            code: "Invalid",
            field: "Email",
            suggestions: ["Use a valid email"],
            metadata: new Dictionary<string, object> { ["attempt"] = 1 },
            exception: exception,
            traceId: "trace-2");

        Assert.False(result.IsValid);
        Assert.Equal("failed", result.Message);
        Assert.Equal("Invalid", result.Code);
        Assert.Equal("Email", result.Field);
        Assert.Same(exception, result.Exception);
        Assert.Equal("trace-2", result.TraceId);
        Assert.Equal(ValidationSeverity.Error, result.Severity);
    }

    [Fact]
    public void Copy_OverridesRequestedValuesAndPreservesOthers()
    {
        var original = ValidationResult.Failure("failed", code: "A", field: "One");

        var copy = original.Copy(isValid: true, message: "fixed", field: "Two");

        Assert.True(copy.IsValid);
        Assert.Equal("fixed", copy.Message);
        Assert.Equal("A", copy.Code);
        Assert.Equal("Two", copy.Field);
    }

    [Fact]
    public void ExtensionMethods_ReturnUpdatedCopies()
    {
        var exception = new Exception("boom");
        var result = ValidationResult.Failure("failed")
            .WithField("Email")
            .WithTraceId("trace")
            .WithSuggestion("Fix email")
            .WithMetadata("key", 42)
            .WithException(exception);

        Assert.Equal("Email", result.Field);
        Assert.Equal("trace", result.TraceId);
        Assert.Equal("Fix email", Assert.Single(result.Suggestions!));
        Assert.Equal(42, result.Metadata!["key"]);
        Assert.Same(exception, result.Exception);
    }
}
