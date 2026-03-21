namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Common
{
    /// <summary>
    /// Contains test scenarios for <see cref="NotDefaultValidator{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class NotDefaultValidatorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(false ? 1 : 0)]
        public void Validate_WhenIntIsDefault_ReturnsFailure(int value)
        {
            NotDefaultValidator<int> validator = new();

            ValidationResult result = validator.Validate(value);

            Assert.False(result.IsValid);
            Assert.Equal("Value must not be the default for its type.", result.Message);
            Assert.Equal("NotDefault", result.Code);
            Assert.Equal("input", result.Field);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-25)]
        public void Validate_WhenIntIsNotDefault_ReturnsSuccess(int value)
        {
            NotDefaultValidator<int> validator = new();

            ValidationResult result = validator.Validate(value);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenStringIsNull_ReturnsFailure()
        {
            NotDefaultValidator<string?> validator = new();

            ValidationResult result = validator.Validate(null);

            Assert.False(result.IsValid);
            Assert.Equal("NotDefault", result.Code);
        }
    }
}
