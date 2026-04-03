namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Contact
{
    /// <summary>
    /// Contains test scenarios for <see cref="WhitelistEmailValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class WhitelistEmailValidatorTests
    {
        [Fact]
        public void Constructor_WhenAllowedEmailsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WhitelistEmailValidator(null!));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_WhenInputIsMissing_ReturnsRequiredFailure(string? input)
        {
            WhitelistEmailValidator validator = new(["allowed@example.com"]);

            ValidationResult result = validator.Validate(input!);

            Assert.False(result.IsValid);
            Assert.Equal("Email is required.", result.Message);
            Assert.Equal("Required", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("allowed@example.com")]
        [InlineData("ALLOWED@EXAMPLE.COM")]
        public void Validate_WhenInputIsWhitelisted_ReturnsSuccess(string input)
        {
            WhitelistEmailValidator validator = new(["allowed@example.com"]);

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenInputIsNotWhitelisted_ReturnsFailure()
        {
            WhitelistEmailValidator validator = new(["allowed@example.com"]);

            ValidationResult result = validator.Validate("blocked@example.com");

            Assert.False(result.IsValid);
            Assert.Equal("Email is not authorized.", result.Message);
            Assert.Equal("NotWhitelisted", result.Code);
            Assert.Equal("input", result.Field);
        }
    }
}
