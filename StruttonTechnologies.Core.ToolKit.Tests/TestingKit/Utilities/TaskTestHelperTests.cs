using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Testing.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Utilities
{
    [ExcludeFromCodeCoverage]
    public class TaskTestHelperTests
    {
        [Fact]
        public async Task WaitAsync_Generic_ShouldThrowArgumentNullException_WhenTaskIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await TaskTestHelper.WaitAsync<int>(null!, TimeSpan.FromSeconds(1)));
        }

        [Fact]
        public async Task WaitAsync_Generic_ShouldReturnValue_WhenTaskCompletesWithinTimeout()
        {
            var task = Task.FromResult(42);

            var result = await TaskTestHelper.WaitAsync(task, TimeSpan.FromSeconds(1));

            Assert.Equal(42, result);
        }

        [Fact]
        public async Task WaitAsync_Generic_ShouldThrowTaskCanceledException_WhenTimeoutExpires()
        {
            var task = Task.Delay(TimeSpan.FromSeconds(10), TestContext.Current.CancellationToken).ContinueWith(_ => 42);

            await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await TaskTestHelper.WaitAsync(task, TimeSpan.FromMilliseconds(100)));
        }

        [Fact]
        public async Task WaitAsync_NonGeneric_ShouldThrowArgumentNullException_WhenTaskIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await TaskTestHelper.WaitAsync(null!, TimeSpan.FromSeconds(1)));
        }

        [Fact]
        public async Task WaitAsync_NonGeneric_ShouldComplete_WhenTaskCompletesWithinTimeout()
        {
            var task = Task.CompletedTask;

            await TaskTestHelper.WaitAsync(task, TimeSpan.FromSeconds(1));

            Assert.True(task.IsCompleted);
        }

        [Fact]
        public async Task WaitAsync_NonGeneric_ShouldThrowTaskCanceledException_WhenTimeoutExpires()
        {
            var task = Task.Delay(TimeSpan.FromSeconds(10), TestContext.Current.CancellationToken);

            await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await TaskTestHelper.WaitAsync(task, TimeSpan.FromMilliseconds(100)));
        }
    }
}
