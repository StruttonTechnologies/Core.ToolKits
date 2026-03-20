namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for synchronous <c>Return</c> behaviors on <see cref="GuardCondition{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GuardConditionReturnBehaviorTests
    {
        /// <summary>
        /// Contains test scenarios for <c>Return(TResult, Func{T, TResult})</c>.
        /// </summary>
        #region Return - TResult, Func<T, TResult>

        [Fact]
        public void Return_WithMatchedConstant_ReturnsMatchedValue()
        {
            string result = GuardTest.IsTrue(true).Return("matched", _ => "not-matched");

            Assert.Equal("matched", result);
        }

        [Fact]
        public void Return_WithMatchedConstant_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(false).Return("matched", value => value ? "matched" : "not-matched");

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public void Return_WithMatchedConstant_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return("matched", (Func<bool, string>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>Return(Func{TResult}, Func{T, TResult})</c>.
        /// </summary>
        #region Return - Func<TResult>, Func<T, TResult>

        [Fact]
        public void Return_WithMatchedFactory_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(true).Return(() => "matched", _ => "not-matched");

            Assert.Equal("matched", result);
        }

        [Fact]
        public void Return_WithMatchedFactory_WhenNotMatched_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(false).Return(() => "matched", value => value ? "matched" : "not-matched");

            Assert.Equal("not-matched", result);
        }

        [Fact]
        public void Return_WithMatchedFactory_WhenMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return((Func<string>)null!, _ => "not-matched"));
        }

        [Fact]
        public void Return_WithMatchedFactory_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return(() => "matched", null!));
        }

        #endregion
    }
}
