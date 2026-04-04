using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Validation.Models;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValidationBehaviors
{
    [ExcludeFromCodeCoverage]
    public class AsyncArgumentValidationTests
    {
        [Fact]
        public async Task ReturnValidationAsync_ShouldThrowArgumentNullException_WhenMessageIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await condition.ReturnValidationAsync(
                    null!,
                    "ERROR_CODE",
                    "field",
                    _ => Task.FromResult(ValidationResult.Success())));

            Assert.Equal("message", exception.ParamName);
        }

        [Fact]
        public async Task ReturnValidationAsync_ShouldThrowArgumentNullException_WhenCodeIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await condition.ReturnValidationAsync(
                    "Error message",
                    null!,
                    "field",
                    _ => Task.FromResult(ValidationResult.Success())));

            Assert.Equal("code", exception.ParamName);
        }

        [Fact]
        public async Task ReturnValidationAsync_ShouldThrowArgumentNullException_WhenFieldIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await condition.ReturnValidationAsync(
                    "Error message",
                    "ERROR_CODE",
                    null!,
                    _ => Task.FromResult(ValidationResult.Success())));

            Assert.Equal("field", exception.ParamName);
        }

        [Fact]
        public async Task ReturnValidationAsync_ShouldThrowArgumentNullException_WhenWhenNotMatchedIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await condition.ReturnValidationAsync(
                    "Error message",
                    "ERROR_CODE",
                    "field",
                    (Func<string, Task<ValidationResult>>)null!));

            Assert.Equal("whenNotMatched", exception.ParamName);
        }

        [Fact]
        public async Task ReturnValidationAsync_WithoutValue_ShouldThrowArgumentNullException_WhenWhenNotMatchedIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await condition.ReturnValidationAsync(
                    "Error message",
                    "ERROR_CODE",
                    "field",
                    (Func<Task<ValidationResult>>)null!));

            Assert.Equal("whenNotMatched", exception.ParamName);
        }
    }
}
