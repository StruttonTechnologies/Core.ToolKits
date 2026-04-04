using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValidationBehaviors
{
    [ExcludeFromCodeCoverage]
    public class AsyncNotMatchedConditionTests
    {
        [Fact]
        public async Task ReturnValidationAsync_ShouldInvokeWhenNotMatched_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);

            var result = await condition.ReturnValidationAsync(
                "Should not use this message",
                "SHOULD_NOT_USE",
                "field",
                _ => Task.FromResult(ValidationResult.Success()));

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ReturnValidationAsync_WithoutValueParam_ShouldInvokeWhenNotMatched_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNullOrEmpty(testValue);

            var result = await condition.ReturnValidationAsync(
                "Should not use this message",
                "SHOULD_NOT_USE",
                "field",
                () => Task.FromResult(ValidationResult.Success()));

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ReturnValidationAsync_ShouldPassValueToFactory_WhenConditionIsNotMatched()
        {
            var testValue = "test value";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);
            string? capturedValue = null;

            var result = await condition.ReturnValidationAsync(
                "Not used",
                "NOT_USED",
                "field",
                async v =>
                {
                    capturedValue = v;
                    await Task.Delay(1);
                    return ValidationResult.Success();
                });

            Assert.Equal(testValue, capturedValue);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ReturnValidationAsync_ShouldReturnCustomValidationResult_WhenConditionIsNotMatched()
        {
            var testValue = 42;
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsZero(testValue);

            var customResult = ValidationResult.Failure("Custom error", "CUSTOM_CODE", "customField");

            var result = await condition.ReturnValidationAsync(
                "Not used",
                "NOT_USED",
                "field",
                async _ =>
                {
                    await Task.Delay(1);
                    return customResult;
                });

            Assert.False(result.IsValid);
            Assert.Equal("Custom error", result.Message);
            Assert.Equal("CUSTOM_CODE", result.Code);
        }

        [Fact]
        public async Task ReturnValidationAsync_ShouldAwaitAsyncOperation_WhenConditionIsNotMatched()
        {
            var testValue = "test";
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull(testValue);
            var wasAwaited = false;

            var result = await condition.ReturnValidationAsync(
                "Not used",
                "NOT_USED",
                "field",
                async _ =>
                {
                    await Task.Delay(10);
                    wasAwaited = true;
                    return ValidationResult.Success();
                });

            Assert.True(wasAwaited);
            Assert.True(result.IsValid);
        }
    }
}
