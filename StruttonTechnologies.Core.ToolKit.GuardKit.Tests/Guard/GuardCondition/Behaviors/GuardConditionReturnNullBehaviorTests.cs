namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for <c>ReturnNull</c> behaviors on <see cref="GuardCondition{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GuardConditionReturnNullBehaviorTests
    {
        /// <summary>
        /// Contains test scenarios for <c>ReturnNull(Func{T, TResult})</c>.
        /// </summary>
        #region ReturnNull - Func<T, TResult>

        [Fact]
        public void ReturnNull_WhenMatched_ReturnsNull()
        {
            string? result = GuardTest.IsTrue(true).ReturnNull(_ => "fallback");

            Assert.Null(result);
        }

        [Fact]
        public void ReturnNull_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = GuardTest.IsTrue(false).ReturnNull(_ => "fallback");

            Assert.Equal("fallback", result);
        }

        [Fact]
        public void ReturnNull_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnNull((Func<bool, string>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>ReturnNull(Func{T, Task{TResult}})</c>.
        /// </summary>
        #region ReturnNull - Func<T, Task<TResult>>

        [Fact]
        public async Task ReturnNullAsync_WhenMatched_ReturnsNull()
        {
            string? result = await GuardTest.IsTrue(true).ReturnNull(_ => Task.FromResult("fallback"));

            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnNullAsync_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = await GuardTest.IsTrue(false).ReturnNull(_ => Task.FromResult("fallback"));

            Assert.Equal("fallback", result);
        }

        [Fact]
        public Task ReturnNullAsync_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnNull((Func<bool, Task<string>>)null!));
        }

        #endregion
    }
}
