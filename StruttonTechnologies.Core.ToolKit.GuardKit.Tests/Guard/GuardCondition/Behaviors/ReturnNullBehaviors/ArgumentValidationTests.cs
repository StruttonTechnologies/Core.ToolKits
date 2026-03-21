namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnNullBehaviors
{
    /// <summary>
    /// Contains argument validation test scenarios for <c>ReturnNull</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public void ReturnNull_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnNull((Func<bool, string>)null!));
        }

        [Fact]
        public Task ReturnNullAsync_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnNull((Func<bool, Task<string>>)null!));
        }
    }
}
