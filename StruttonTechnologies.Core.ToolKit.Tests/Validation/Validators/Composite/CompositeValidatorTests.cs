namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.Validators.Composite
{
    /// <summary>
    /// Contains test scenarios for <see cref="CompositeValidator{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class CompositeValidatorTests
    {
        [Fact]
        public void Constructor_WhenValidatorsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CompositeValidator<string>(null!));
        }

        [Fact]
        public void Validate_WhenAllValidatorsPass_ReturnsSuccess()
        {
            CompositeValidator<string> validator = new([
                new PassThroughValidator(),
                new PassThroughValidator(),
            ]);

            ValidationResult result = validator.Validate("value");

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenValidatorFails_ReturnsFirstFailure()
        {
            ValidationResult expected = ValidationResult.Failure("First failure.", code: "Fail01");
            CompositeValidator<string> validator = new([
                new PassThroughValidator(),
                new FailingValidator(expected),
                new FailingValidator(ValidationResult.Failure("Second failure.", code: "Fail02")),
            ]);

            ValidationResult result = validator.Validate("value");

            Assert.Same(expected, result);
        }

        [Fact]
        public void Validate_WhenFirstValidatorFails_DoesNotInvokeRemainingValidators()
        {
            CountingValidator first = new(ValidationResult.Failure("Stop."));
            CountingValidator second = new(ValidationResult.Success());
            CompositeValidator<string> validator = new([first, second]);

            ValidationResult result = validator.Validate("value");

            Assert.False(result.IsValid);
            Assert.Equal(1, first.CallCount);
            Assert.Equal(0, second.CallCount);
        }

        private sealed class PassThroughValidator : IValidator<string>
        {
            public ValidationResult Validate(string input) => ValidationResult.Success();
        }

        private sealed class FailingValidator(ValidationResult result) : IValidator<string>
        {
            public ValidationResult Validate(string input) => result;
        }

        private sealed class CountingValidator(ValidationResult result) : IValidator<string>
        {
            public int CallCount { get; private set; }

            public ValidationResult Validate(string input)
            {
                this.CallCount++;
                return result;
            }
        }
    }
}
