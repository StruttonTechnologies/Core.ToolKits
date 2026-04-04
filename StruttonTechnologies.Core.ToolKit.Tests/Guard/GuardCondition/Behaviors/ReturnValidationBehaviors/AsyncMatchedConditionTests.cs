using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValidationBehaviors
{
    [ExcludeFromCodeCoverage]
    public class AsyncMatchedConditionTests
    {
        [Fact]
        public async Task ReturnValidationAsync_ShouldReturnFailure_WhenConditionIsMatched()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var result = await condition.ReturnValidationAsync(
                "Value cannot be null",
                "NULL_VALUE",
                "testField",
                _ => Task.FromResult(ValidationResult.Success()));

            Assert.False(result.IsValid);
            Assert.Equal("Value cannot be null", result.Message);
            Assert.Equal("NULL_VALUE", result.Code);
            Assert.Equal("testField", result.Field);
        }

        [Fact]
        public async Task ReturnValidationAsync_WithoutValueParam_ShouldReturnFailure_WhenConditionIsMatched()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNullOrEmpty("");

            var result = await condition.ReturnValidationAsync(
                "Value cannot be empty",
                "EMPTY_VALUE",
                "inputField",
                () => Task.FromResult(ValidationResult.Success()));

            Assert.False(result.IsValid);
            Assert.Equal("Value cannot be empty", result.Message);
            Assert.Equal("EMPTY_VALUE", result.Code);
            Assert.Equal("inputField", result.Field);
        }

        [Theory]
        [InlineData("ERROR_CODE_1", "Error 1")]
        [InlineData("ERROR_CODE_2", "Error 2")]
        [InlineData("VALIDATION_FAILED", "Validation failed")]
        public async Task ReturnValidationAsync_ShouldReturnFailureWithCorrectDetails_WhenConditionIsMatched(string code, string message)
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsTrue(true);

            var result = await condition.ReturnValidationAsync(
                message,
                code,
                "field",
                _ => Task.FromResult(ValidationResult.Success()));

            Assert.False(result.IsValid);
            Assert.Equal(message, result.Message);
            Assert.Equal(code, result.Code);
        }
    }
}
