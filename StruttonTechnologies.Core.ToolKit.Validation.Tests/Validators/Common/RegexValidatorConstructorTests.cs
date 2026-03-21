namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Common
{
    /// <summary>
    /// Contains constructor test scenarios for <see cref="RegexValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class RegexValidatorConstructorTests
    {
        [Fact]
        public void Constructor_WhenPatternIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RegexValidator(null!));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WhenPatternIsEmptyOrWhitespace_ThrowsArgumentException(string pattern)
        {
            Assert.Throws<ArgumentException>(() => new RegexValidator(pattern));
        }

        [Fact]
        public void Constructor_WhenErrorMessageIsNotProvided_UsesDefaultMessage()
        {
            RegexValidator validator = new("^[A-Z]+$");

            ValidationResult result = validator.Validate("abc");

            Assert.False(result.IsValid);
            Assert.Equal("Value does not match the required format.", result.Message);
        }
    }
}
