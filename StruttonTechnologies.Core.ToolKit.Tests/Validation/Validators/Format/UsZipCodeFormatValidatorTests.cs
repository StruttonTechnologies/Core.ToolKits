namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Format
{
    /// <summary>
    /// Contains test scenarios for <see cref="UsZipCodeFormatValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class UsZipCodeFormatValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_WhenInputIsMissing_ReturnsRequiredFailure(string? input)
        {
            UsZipCodeFormatValidator validator = new();

            ValidationResult result = validator.Validate(input!);

            Assert.False(result.IsValid);
            Assert.Equal("ZIP code is required.", result.Message);
            Assert.Equal("Required", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("123456")]
        [InlineData("ABCDE")]
        [InlineData("12345-678")]
        public void Validate_WhenInputHasInvalidFormat_ReturnsFailure(string input)
        {
            UsZipCodeFormatValidator validator = new();

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
            Assert.Equal("Invalid ZIP code format.", result.Message);
            Assert.Equal("InvalidFormat", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-6789")]
        public void Validate_WhenInputHasValidFormat_ReturnsSuccess(string input)
        {
            UsZipCodeFormatValidator validator = new();

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }
    }
}
