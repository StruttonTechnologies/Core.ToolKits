using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValidationBehaviors
{
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void ReturnValidation_ShouldReturnFailure_WhenConditionIsMatched()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var result = condition.ReturnValidation(
                "Value cannot be null",
                "NULL_VALUE",
                "testField",
                _ => ValidationResult.Success());

            Assert.False(result.IsValid);
            Assert.Equal("Value cannot be null", result.Message);
            Assert.Equal("NULL_VALUE", result.Code);
            Assert.Equal("testField", result.Field);
        }

        [Fact]
        public void ReturnValidation_WithoutValueParam_ShouldReturnFailure_WhenConditionIsMatched()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNullOrEmpty("");

            var result = condition.ReturnValidation(
                "Value cannot be empty",
                "EMPTY_VALUE",
                "inputField",
                () => ValidationResult.Success());

            Assert.False(result.IsValid);
            Assert.Equal("Value cannot be empty", result.Message);
            Assert.Equal("EMPTY_VALUE", result.Code);
            Assert.Equal("inputField", result.Field);
        }

        [Theory]
        [InlineData("ERROR_CODE_1", "Error 1")]
        [InlineData("ERROR_CODE_2", "Error 2")]
        [InlineData("VALIDATION_FAILED", "Validation failed")]
        public void ReturnValidation_ShouldReturnFailureWithCorrectDetails_WhenConditionIsMatched(string code, string message)
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsTrue(true);

            var result = condition.ReturnValidation(
                message,
                code,
                "field",
                _ => ValidationResult.Success());

            Assert.False(result.IsValid);
            Assert.Equal(message, result.Message);
            Assert.Equal(code, result.Code);
        }
    }
}
