using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValidationBehaviors
{
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public void ReturnValidation_ShouldThrowArgumentNullException_WhenMessageIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                condition.ReturnValidation(
                    null!,
                    "ERROR_CODE",
                    "field",
                    _ => ValidationResult.Success()));

            Assert.Equal("message", exception.ParamName);
        }

        [Fact]
        public void ReturnValidation_ShouldThrowArgumentNullException_WhenCodeIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                condition.ReturnValidation(
                    "Error message",
                    null!,
                    "field",
                    _ => ValidationResult.Success()));

            Assert.Equal("code", exception.ParamName);
        }

        [Fact]
        public void ReturnValidation_ShouldThrowArgumentNullException_WhenFieldIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                condition.ReturnValidation(
                    "Error message",
                    "ERROR_CODE",
                    null!,
                    _ => ValidationResult.Success()));

            Assert.Equal("field", exception.ParamName);
        }

        [Fact]
        public void ReturnValidation_ShouldThrowArgumentNullException_WhenWhenNotMatchedIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                condition.ReturnValidation(
                    "Error message",
                    "ERROR_CODE",
                    "field",
                    (Func<string, ValidationResult>)null!));

            Assert.Equal("whenNotMatched", exception.ParamName);
        }

        [Fact]
        public void ReturnValidation_WithoutValue_ShouldThrowArgumentNullException_WhenWhenNotMatchedIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                condition.ReturnValidation(
                    "Error message",
                    "ERROR_CODE",
                    "field",
                    (Func<ValidationResult>)null!));

            Assert.Equal("whenNotMatched", exception.ParamName);
        }
    }
}
