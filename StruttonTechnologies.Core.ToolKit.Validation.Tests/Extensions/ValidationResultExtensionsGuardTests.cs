namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Extensions
{
    /// <summary>
    /// Contains guard clause test scenarios for <see cref="ValidationResultExtensions"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ValidationResultExtensionsGuardTests
    {
        [Fact]
        public void WithField_WhenResultIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResultExtensions.WithField(null!, "Field01"));
        }

        [Fact]
        public void WithField_WhenFieldIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResult.Success().WithField(null!));
        }

        [Fact]
        public void WithTraceId_WhenResultIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResultExtensions.WithTraceId(null!, "trace-001"));
        }

        [Fact]
        public void WithTraceId_WhenTraceIdIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResult.Success().WithTraceId(null!));
        }

        [Fact]
        public void WithSuggestion_WhenResultIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResultExtensions.WithSuggestion(null!, "Suggestion01"));
        }

        [Fact]
        public void WithSuggestion_WhenSuggestionIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResult.Success().WithSuggestion(null!));
        }

        [Fact]
        public void WithMetadata_WhenResultIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResultExtensions.WithMetadata(null!, "Key01", "Value01"));
        }

        [Fact]
        public void WithMetadata_WhenKeyIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResult.Success().WithMetadata(null!, "Value01"));
        }

        [Fact]
        public void WithException_WhenResultIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResultExtensions.WithException(null!, new InvalidOperationException()));
        }

        [Fact]
        public void WithException_WhenExceptionIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationResult.Success().WithException(null!));
        }
    }
}
