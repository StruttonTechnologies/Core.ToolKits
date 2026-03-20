namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for <c>ReturnDefault</c> behaviors on <see cref="GuardCondition{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GuardConditionReturnDefaultBehaviorTests
    {
        /// <summary>
        /// Contains test scenarios for <c>ReturnDefault(Func{T, TResult})</c>.
        /// </summary>
        #region ReturnDefault - Func<T, TResult>

        [Fact]
        public void ReturnDefault_WhenMatched_ReturnsDefault()
        {
            string? result = GuardTest.IsTrue(true).ReturnDefault<string>(_ => "fallback");

            Assert.Null(result);
        }

        [Fact]
        public void ReturnDefault_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = GuardTest.IsTrue(false).ReturnDefault<string>(_ => "fallback");

            Assert.Equal("fallback", result);
        }

        [Fact]
        public void ReturnDefault_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnDefault<string>((Func<bool, string>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>ReturnDefault(Func{T, Task{TResult}})</c>.
        /// </summary>
        #region ReturnDefault - Func<T, Task<TResult>>

        [Fact]
        public async Task ReturnDefaultAsync_WhenMatched_ReturnsDefault()
        {
            string? result = await GuardTest.IsTrue(true).ReturnDefault(_ => Task.FromResult("fallback"));

            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnDefaultAsync_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = await GuardTest.IsTrue(false).ReturnDefault(_ => Task.FromResult("fallback"));

            Assert.Equal("fallback", result);
        }

        [Fact]
        public Task ReturnDefaultAsync_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnDefault((Func<bool, Task<string>>)null!));
        }

        #endregion
    }
}
