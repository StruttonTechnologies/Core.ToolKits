namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Models
{
    /// <summary>
    /// Contains test scenarios for validation result factory methods.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ValidationResultFactoryTests
    {
        [Fact]
        public void Success_WhenCalledWithoutArguments_ReturnsInformationalValidResult()
        {
            ValidationResult result = ValidationResult.Success();

            Assert.True(result.IsValid);
            Assert.Null(result.Message);
            Assert.Null(result.Code);
            Assert.Null(result.Field);
            Assert.Null(result.Suggestions);
            Assert.Null(result.Metadata);
            Assert.Null(result.Exception);
            Assert.Null(result.TraceId);
            Assert.Equal(ValidationSeverity.Info, result.Severity);
        }

        [Fact]
        public void Success_WhenCalledWithMessage_PreservesMessage()
        {
            ValidationResult result = ValidationResult.Success("Validation succeeded.");

            Assert.True(result.IsValid);
            Assert.Equal("Validation succeeded.", result.Message);
            Assert.Equal(ValidationSeverity.Info, result.Severity);
        }

        [Fact]
        public void Warning_WhenCalled_PreservesSuppliedValues()
        {
            Dictionary<string, object> metadata = new()
            {
                ["Source"] = "UI",
            };

            ValidationResult result = ValidationResult.Warning(
                message: "Minor issue.",
                code: "Warn01",
                field: "Email",
                suggestions: ["Review the value.", "Try again later."],
                metadata: metadata,
                traceId: "trace-123");

            Assert.True(result.IsValid);
            Assert.Equal("Minor issue.", result.Message);
            Assert.Equal("Warn01", result.Code);
            Assert.Equal("Email", result.Field);
            Assert.Equal(ValidationSeverity.Warning, result.Severity);
            Assert.Equal(["Review the value.", "Try again later."], result.Suggestions);
            Assert.NotNull(result.Metadata);
            Assert.Equal("UI", result.Metadata!["Source"]);
            Assert.Equal("trace-123", result.TraceId);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void Failure_WhenCalled_PreservesSuppliedValues()
        {
            Dictionary<string, object> metadata = new()
            {
                ["Attempt"] = 2,
            };

            InvalidOperationException exception = new("Something failed.");

            ValidationResult result = ValidationResult.Failure(
                message: "Validation failed.",
                code: "Fail01",
                field: "PhoneNumber",
                suggestions: ["Fix the number."],
                metadata: metadata,
                exception: exception,
                traceId: "trace-456",
                severity: ValidationSeverity.Error);

            Assert.False(result.IsValid);
            Assert.Equal("Validation failed.", result.Message);
            Assert.Equal("Fail01", result.Code);
            Assert.Equal("PhoneNumber", result.Field);
            Assert.Equal(["Fix the number."], result.Suggestions);
            Assert.NotNull(result.Metadata);
            Assert.Equal(2, result.Metadata!["Attempt"]);
            Assert.Same(exception, result.Exception);
            Assert.Equal("trace-456", result.TraceId);
            Assert.Equal(ValidationSeverity.Error, result.Severity);
        }

        [Fact]
        public void Warning_WhenSourceCollectionsAreMutated_ResultRemainsImmutable()
        {
            List<string> suggestions = ["Original suggestion"];
            Dictionary<string, object> metadata = new()
            {
                ["Original"] = true,
            };

            ValidationResult result = ValidationResult.Warning(
                message: "Warning.",
                suggestions: suggestions,
                metadata: metadata);

            suggestions.Add("Added later");
            metadata["Original"] = false;
            metadata["AddedLater"] = true;

            Assert.Equal(["Original suggestion"], result.Suggestions);
            Assert.NotNull(result.Metadata);
            Assert.Equal(true, result.Metadata!["Original"]);
            Assert.False(result.Metadata.ContainsKey("AddedLater"));
        }
    }
}
