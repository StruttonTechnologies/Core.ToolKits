using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValidationBehaviors
{
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void ReturnValidation_ShouldInvokeWhenNotMatched_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);

            var result = condition.ReturnValidation(
                "Should not use this message",
                "SHOULD_NOT_USE",
                "field",
                _ => ValidationResult.Success());

            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReturnValidation_WithoutValueParam_ShouldInvokeWhenNotMatched_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNullOrEmpty(testValue);

            var result = condition.ReturnValidation(
                "Should not use this message",
                "SHOULD_NOT_USE",
                "field",
                () => ValidationResult.Success());

            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReturnValidation_ShouldPassValueToFactory_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);
            string? capturedValue = null;

            var result = condition.ReturnValidation(
                "Not used",
                "NOT_USED",
                "field",
                v =>
                {
                    capturedValue = v;
                    return ValidationResult.Success();
                });

            Assert.Equal(testValue, capturedValue);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReturnValidation_ShouldReturnCustomValidationResult_WhenConditionIsNotMatched()
        {
            var testValue = 42;
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsZero(testValue);

            var customResult = ValidationResult.Failure("Custom error", "CUSTOM_CODE", "customField");

            var result = condition.ReturnValidation(
                "Not used",
                "NOT_USED",
                "field",
                _ => customResult);

            Assert.False(result.IsValid);
            Assert.Equal("Custom error", result.Message);
            Assert.Equal("CUSTOM_CODE", result.Code);
        }
    }
}
