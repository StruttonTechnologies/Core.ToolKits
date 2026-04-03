namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Common
{
    /// <summary>
    /// Contains test scenarios for <see cref="IdValidator{TKey}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class IdValidatorTests
    {
        [Fact]
        public void Validate_WhenGuidIsDefault_ReturnsFailure()
        {
            IdValidator<Guid> validator = new();

            ValidationResult result = validator.Validate(Guid.Empty);

            Assert.False(result.IsValid);
            Assert.Equal("ID must be set and non-default.", result.Message);
            Assert.Equal("InvalidId", result.Code);
            Assert.Equal("input", result.Field);
            Assert.Equal(ValidationSeverity.Error, result.Severity);
        }

        [Fact]
        public void Validate_WhenGuidIsNotDefault_ReturnsSuccess()
        {
            IdValidator<Guid> validator = new();

            ValidationResult result = validator.Validate(Guid.NewGuid());

            Assert.True(result.IsValid);
            Assert.Equal(ValidationSeverity.Info, result.Severity);
        }
    }
}
