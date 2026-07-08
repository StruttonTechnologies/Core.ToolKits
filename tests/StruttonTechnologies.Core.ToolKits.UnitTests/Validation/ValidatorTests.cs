using StruttonTechnologies.Core.ToolKit.Validation.Abstractions;
using StruttonTechnologies.Core.ToolKit.Validation.Models;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Common;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Composite;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Contact;
using StruttonTechnologies.Core.ToolKit.Validation.Validators.Format;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Validation;

public sealed class ValidatorTests
{
    [Theory]
    [InlineData("test@example.com", true, null)]
    [InlineData("", false, "Required")]
    [InlineData("not-an-email", false, "InvalidFormat")]
    public void EmailFormatValidator_ValidatesExpectedInputs(string input, bool expectedValid, string? expectedCode)
    {
        var result = new EmailFormatValidator().Validate(input);

        Assert.Equal(expectedValid, result.IsValid);
        Assert.Equal(expectedCode, result.Code);
    }

    [Theory]
    [InlineData("555-555-5555", true, null)]
    [InlineData("", false, "Required")]
    [InlineData("abc", false, "InvalidFormat")]
    public void PhoneNumberFormatValidator_ValidatesExpectedInputs(string input, bool expectedValid, string? expectedCode)
    {
        var result = new PhoneNumberFormatValidator().Validate(input);

        Assert.Equal(expectedValid, result.IsValid);
        Assert.Equal(expectedCode, result.Code);
    }

    [Theory]
    [InlineData("97754", true, null)]
    [InlineData("", false, "Required")]
    [InlineData("abcde", false, "InvalidFormat")]
    public void UsZipCodeFormatValidator_ValidatesExpectedInputs(string input, bool expectedValid, string? expectedCode)
    {
        var result = new UsZipCodeFormatValidator().Validate(input);

        Assert.Equal(expectedValid, result.IsValid);
        Assert.Equal(expectedCode, result.Code);
    }

    [Fact]
    public void RegexValidator_ReturnsFailureWhenPatternDoesNotMatch()
    {
        var result = new RegexValidator("^[0-9]+$").Validate("abc");

        Assert.False(result.IsValid);
        Assert.Equal("RegexMismatch", result.Code);
    }

    [Fact]
    public void RegexValidator_ReturnsSuccessWhenPatternMatches()
    {
        var result = new RegexValidator("^[0-9]+$").Validate("123");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void RegexValidator_RejectsBlankPattern()
    {
        Assert.Throws<ArgumentException>(() => new RegexValidator(" "));
    }

    [Fact]
    public void NotDefaultValidator_FailsForDefaultValue()
    {
        var result = new NotDefaultValidator<Guid>().Validate(Guid.Empty);

        Assert.False(result.IsValid);
        Assert.Equal("NotDefault", result.Code);
    }

    [Fact]
    public void IdValidator_SucceedsForNonDefaultValue()
    {
        var result = new IdValidator<Guid>().Validate(Guid.NewGuid());

        Assert.True(result.IsValid);
    }

    [Fact]
    public void CompositeValidator_ReturnsFirstFailure()
    {
        var validator = new CompositeValidator<string>([
            new StubValidator<string>(ValidationResult.Success()),
            new StubValidator<string>(ValidationResult.Failure("failed", code: "Stop")),
            new StubValidator<string>(ValidationResult.Failure("second", code: "Later"))
        ]);

        var result = validator.Validate("value");

        Assert.False(result.IsValid);
        Assert.Equal("Stop", result.Code);
    }

    [Fact]
    public void WhitelistEmailValidator_UsesNormalizedEmailComparison()
    {
        var validator = new WhitelistEmailValidator(["Test@Example.com"]);

        var result = validator.Validate("test@example.com");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void BlacklistPhoneValidator_RejectsBlacklistedNormalizedNumber()
    {
        var validator = new BlacklistPhoneValidator(["555-555-5555"]);

        var result = validator.Validate("(555) 555-5555");

        Assert.False(result.IsValid);
        Assert.Equal("Blacklisted", result.Code);
    }

    private sealed class StubValidator<T>(ValidationResult result) : IValidator<T>
    {
        public ValidationResult Validate(T input) => result;
    }
}
