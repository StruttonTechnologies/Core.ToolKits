namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Format
{
    /// <summary>
    /// Contains test scenarios for <see cref="EmailFormatValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class EmailFormatValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_WhenInputIsMissing_ReturnsRequiredFailure(string? input)
        {
            EmailFormatValidator validator = new();

            ValidationResult result = validator.Validate(input!);

            Assert.False(result.IsValid);
            Assert.Equal("Email is required.", result.Message);
            Assert.Equal("Required", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("plainaddress")]
        [InlineData("missing-at.example.com")]
        [InlineData("test@")]
        [InlineData("test @example.com")]
        public void Validate_WhenInputHasInvalidFormat_ReturnsFailure(string input)
        {
            EmailFormatValidator validator = new();

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
            Assert.Equal("Invalid email format.", result.Message);
            Assert.Equal("InvalidFormat", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("user@example.com")]
        [InlineData("first.last@example.co.uk")]
        public void Validate_WhenInputHasValidFormat_ReturnsSuccess(string input)
        {
            EmailFormatValidator validator = new();

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }
    }
}
