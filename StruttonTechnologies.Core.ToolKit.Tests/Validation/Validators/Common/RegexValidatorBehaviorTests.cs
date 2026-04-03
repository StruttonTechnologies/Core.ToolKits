namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Common
{
    /// <summary>
    /// Contains behavior test scenarios for <see cref="RegexValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class RegexValidatorBehaviorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_WhenInputIsMissing_ReturnsRequiredFailure(string? input)
        {
            RegexValidator validator = new("^[A-Z]+$");

            ValidationResult result = validator.Validate(input!);

            Assert.False(result.IsValid);
            Assert.Equal("Value is required.", result.Message);
            Assert.Equal("Required", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("123")]
        public void Validate_WhenInputDoesNotMatchPattern_ReturnsRegexMismatchFailure(string input)
        {
            RegexValidator validator = new("^[A-Z]+$", "Only uppercase letters are allowed.");

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
            Assert.Equal("Only uppercase letters are allowed.", result.Message);
            Assert.Equal("RegexMismatch", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData("ABC")]
        [InlineData("XYZ")]
        public void Validate_WhenInputMatchesPattern_ReturnsSuccess(string input)
        {
            RegexValidator validator = new("^[A-Z]+$");

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }
    }
}
