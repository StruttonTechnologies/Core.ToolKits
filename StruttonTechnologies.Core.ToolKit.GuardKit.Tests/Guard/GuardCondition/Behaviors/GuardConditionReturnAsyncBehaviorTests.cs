namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for asynchronous <c>Return</c> behaviors on <see cref="GuardCondition{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GuardConditionReturnAsyncBehaviorTests
    {
        /// <summary>
        /// Contains test scenarios for <c>Return(TResult, Func{T, Task{TResult}})</c>.
        /// </summary>
        #region Return - TResult, Func<T, Task<TResult>>

        [Fact]
        public async Task ReturnAsync_WithMatchedConstant_ReturnsMatchedValue()
        {
            string result = await GuardTest.IsTrue(true).Return("matched", _ => Task.FromResult("not-matched"));

            Assert.Equal("matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedConstant_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(false).Return("matched", value => Task.FromResult(value ? "matched" : "not-matched"));

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public Task ReturnAsync_WithMatchedConstant_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return("matched", (Func<bool, Task<string>>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>Return(Func{Task{TResult}}, Func{T, Task{TResult}})</c>.
        /// </summary>
        #region Return - Func<Task<TResult>>, Func<T, Task<TResult>>

        [Fact]
        public async Task ReturnAsync_WithMatchedFactory_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(true).Return(() => Task.FromResult("matched"), _ => Task.FromResult("not-matched"));

            Assert.Equal("matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedFactory_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(false).Return(() => Task.FromResult("matched"), value => Task.FromResult(value ? "matched" : "not-matched"));

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public Task ReturnAsync_WithMatchedFactory_WhenMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return((Func<Task<string>>)null!, _ => Task.FromResult("not-matched")));
        }

        [Fact]
        public Task ReturnAsync_WithMatchedFactory_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return(() => Task.FromResult("matched"), null!));
        }

        #endregion
    }
}
