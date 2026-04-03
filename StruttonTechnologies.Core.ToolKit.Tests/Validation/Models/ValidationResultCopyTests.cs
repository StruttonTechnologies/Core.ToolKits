namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Models
{
    /// <summary>
    /// Contains test scenarios for <see cref="ValidationResult.Copy"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ValidationResultCopyTests
    {
        [Fact]
        public void Copy_WhenNoOverridesAreProvided_ReturnsEquivalentResult()
        {
            ValidationResult original = ValidationResult.Failure(
                message: "Original",
                code: "Code01",
                field: "Field01",
                suggestions: ["Suggestion01"],
                metadata: new Dictionary<string, object> { ["Key01"] = "Value01" },
                exception: new InvalidOperationException("Boom"),
                traceId: "trace-original",
                severity: ValidationSeverity.Error);

            ValidationResult copy = original.Copy();

            Assert.NotSame(original, copy);
            Assert.Equal(original.IsValid, copy.IsValid);
            Assert.Equal(original.Message, copy.Message);
            Assert.Equal(original.Code, copy.Code);
            Assert.Equal(original.Field, copy.Field);
            Assert.Equal(original.Severity, copy.Severity);
            Assert.Equal(original.TraceId, copy.TraceId);
            Assert.Equal(original.Suggestions, copy.Suggestions);
            Assert.NotNull(copy.Metadata);
            Assert.Equal(original.Metadata!["Key01"], copy.Metadata!["Key01"]);
            Assert.Same(original.Exception, copy.Exception);
        }

        [Fact]
        public void Copy_WhenOverridesAreProvided_AppliesOverrides()
        {
            ValidationResult original = ValidationResult.Warning("Original warning", code: "Warn01", field: "Field01");
            Dictionary<string, object> metadata = new()
            {
                ["Key02"] = "Value02",
            };
            List<string> suggestions = ["Suggestion02"];
            ArgumentException exception = new("Replacement exception.");

            ValidationResult copy = original.Copy(
                isValid: false,
                message: "Updated",
                code: "Code02",
                field: "Field02",
                suggestions: suggestions,
                metadata: metadata,
                exception: exception,
                traceId: "trace-updated",
                severity: ValidationSeverity.Error);

            Assert.False(copy.IsValid);
            Assert.Equal("Updated", copy.Message);
            Assert.Equal("Code02", copy.Code);
            Assert.Equal("Field02", copy.Field);
            Assert.Equal(["Suggestion02"], copy.Suggestions);
            Assert.NotNull(copy.Metadata);
            Assert.Equal("Value02", copy.Metadata!["Key02"]);
            Assert.Same(exception, copy.Exception);
            Assert.Equal("trace-updated", copy.TraceId);
            Assert.Equal(ValidationSeverity.Error, copy.Severity);
        }

        [Fact]
        public void Copy_WhenOverrideCollectionsAreMutated_CopyRemainsImmutable()
        {
            List<string> suggestions = ["Suggestion01"];
            Dictionary<string, object> metadata = new()
            {
                ["Key01"] = "Value01",
            };

            ValidationResult result = ValidationResult.Success().Copy(suggestions: suggestions, metadata: metadata);

            suggestions.Add("Suggestion02");
            metadata["Key01"] = "Changed";
            metadata["Key02"] = "Value02";

            Assert.Equal(["Suggestion01"], result.Suggestions);
            Assert.NotNull(result.Metadata);
            Assert.Equal("Value01", result.Metadata!["Key01"]);
            Assert.False(result.Metadata.ContainsKey("Key02"));
        }
    }
}
