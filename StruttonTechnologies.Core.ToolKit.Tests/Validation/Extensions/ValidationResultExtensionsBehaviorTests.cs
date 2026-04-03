namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Extensions
{
    /// <summary>
    /// Contains behavior test scenarios for <see cref="ValidationResultExtensions"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ValidationResultExtensionsBehaviorTests
    {
        [Fact]
        public void WithField_WhenCalled_ReturnsNewResultWithUpdatedField()
        {
            ValidationResult original = ValidationResult.Failure("Failure.");

            ValidationResult updated = original.WithField("Email");

            Assert.NotSame(original, updated);
            Assert.Equal("Email", updated.Field);
            Assert.Equal(original.Message, updated.Message);
        }

        [Fact]
        public void WithTraceId_WhenCalled_ReturnsNewResultWithUpdatedTraceId()
        {
            ValidationResult original = ValidationResult.Warning("Warning.");

            ValidationResult updated = original.WithTraceId("trace-789");

            Assert.NotSame(original, updated);
            Assert.Equal("trace-789", updated.TraceId);
            Assert.Equal(original.Message, updated.Message);
        }

        [Fact]
        public void WithSuggestion_WhenResultHasNoSuggestions_AddsFirstSuggestion()
        {
            ValidationResult updated = ValidationResult.Success().WithSuggestion("Suggestion01");

            Assert.Equal(["Suggestion01"], updated.Suggestions);
        }

        [Fact]
        public void WithSuggestion_WhenResultAlreadyHasSuggestions_AppendsSuggestion()
        {
            ValidationResult original = ValidationResult.Warning("Warning.", suggestions: ["Suggestion01"]);

            ValidationResult updated = original.WithSuggestion("Suggestion02");

            Assert.Equal(["Suggestion01", "Suggestion02"], updated.Suggestions);
            Assert.Equal(["Suggestion01"], original.Suggestions);
        }

        [Fact]
        public void WithMetadata_WhenResultHasNoMetadata_AddsMetadataEntry()
        {
            ValidationResult updated = ValidationResult.Success().WithMetadata("Key01", 123);

            Assert.NotNull(updated.Metadata);
            Assert.Equal(123, updated.Metadata!["Key01"]);
        }

        [Fact]
        public void WithMetadata_WhenKeyAlreadyExists_ReplacesMetadataValue()
        {
            ValidationResult original = ValidationResult.Warning(
                "Warning.",
                metadata: new Dictionary<string, object> { ["Key01"] = "Original" });

            ValidationResult updated = original.WithMetadata("Key01", "Updated");

            Assert.NotNull(updated.Metadata);
            Assert.Equal("Updated", updated.Metadata!["Key01"]);
            Assert.Equal("Original", original.Metadata!["Key01"]);
        }

        [Fact]
        public void WithException_WhenCalled_ReturnsNewResultWithException()
        {
            ValidationResult original = ValidationResult.Failure("Failure.");
            InvalidOperationException exception = new("Boom.");

            ValidationResult updated = original.WithException(exception);

            Assert.NotSame(original, updated);
            Assert.Same(exception, updated.Exception);
            Assert.Equal(original.Message, updated.Message);
        }
    }
}
