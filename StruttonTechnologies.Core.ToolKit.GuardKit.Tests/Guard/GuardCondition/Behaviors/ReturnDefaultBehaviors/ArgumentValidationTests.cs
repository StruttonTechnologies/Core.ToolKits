namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnDefaultBehaviors
{
    /// <summary>
    /// Contains argument validation test scenarios for <c>ReturnDefault</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public void ReturnDefault_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnDefault<string>((Func<bool, string>)null!));
        }

        [Fact]
        public Task ReturnDefaultAsync_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnDefault((Func<bool, Task<string>>)null!));
        }
    }
}
