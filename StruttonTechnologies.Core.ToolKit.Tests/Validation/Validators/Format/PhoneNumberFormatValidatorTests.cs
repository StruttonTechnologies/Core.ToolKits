namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Format
{
    /// <summary>
    /// Contains test scenarios for <see cref="PhoneNumberFormatValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class PhoneNumberFormatValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_WhenInputIsMissing_ReturnsRequiredFailure(string? input)
        {
            PhoneNumberFormatValidator validator = new();

            ValidationResult result = validator.Validate(input!);

            Assert.False(result.IsValid);
            Assert.Equal("Phone number is required.", result.Message);
            Assert.Equal("Required", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("+0123456789")]
        [InlineData("+1 (555) 123-4567")]
        [InlineData("abcdefg")]
        public void Validate_WhenInputHasInvalidFormat_ReturnsFailure(string input)
        {
            PhoneNumberFormatValidator validator = new();

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
            Assert.Equal("Phone number must be in valid international format (E.164).", result.Message);
            Assert.Equal("InvalidFormat", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("15551234567")]
        [InlineData("+15551234567")]
        [InlineData("441234567890")]
        public void Validate_WhenInputHasValidFormat_ReturnsSuccess(string input)
        {
            PhoneNumberFormatValidator validator = new();

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }
    }
}
