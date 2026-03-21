namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Format
{
    /// <summary>
    /// Contains test scenarios for <see cref="BlacklistPhoneValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class BlacklistPhoneValidatorTests
    {
        [Fact]
        public void Constructor_WhenBlacklistedNumbersIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BlacklistPhoneValidator(null!));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_WhenInputIsMissing_ReturnsRequiredFailure(string? input)
        {
            BlacklistPhoneValidator validator = new(["+15551234567"]);

            ValidationResult result = validator.Validate(input!);

            Assert.False(result.IsValid);
            Assert.Equal("Phone number is required.", result.Message);
            Assert.Equal("Required", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("+15551234567")]
        [InlineData("+15550000000")]
        public void Validate_WhenInputIsNotBlacklisted_ReturnsSuccess(string input)
        {
            BlacklistPhoneValidator validator = new(["+19998887777"]);

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("+15551234567")]
        [InlineData("+15551234567")]
        public void Validate_WhenInputIsBlacklisted_ReturnsFailure(string input)
        {
            BlacklistPhoneValidator validator = new(["+15551234567"]);

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
            Assert.Equal("Phone number is not allowed.", result.Message);
            Assert.Equal("Blacklisted", result.Code);
            Assert.Equal("input", result.Field);
        }
    }
}
