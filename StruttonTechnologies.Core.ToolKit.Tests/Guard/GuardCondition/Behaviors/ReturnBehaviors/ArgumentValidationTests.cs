namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnBehaviors
{
    /// <summary>
    /// Contains argument validation test scenarios for <c>Return</c> and <c>ReturnAsync</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public void Return_WithMatchedConstant_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Return("matched", (Func<bool, string>)null!));
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

        [Fact]
        public Task ReturnAsync_WithMatchedConstant_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true)
                    .ReturnAsync("matched", (Func<bool, Task<string>>)null!));
        }

        [Fact]
        public Task ReturnAsync_WithMatchedFactory_WhenMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true)
                    .ReturnAsync((Func<Task<string>>)null!, _ => Task.FromResult("not-matched")));
        }

        [Fact]
        public Task ReturnAsync_WithMatchedFactory_WhenNotMatchedFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true)
                    .ReturnAsync(() => Task.FromResult("matched"), (Func<bool, Task<string>>)null!));
        }
    }
}
