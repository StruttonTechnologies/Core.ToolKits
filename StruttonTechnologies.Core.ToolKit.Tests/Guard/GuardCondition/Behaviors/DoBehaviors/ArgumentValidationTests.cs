namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.DoBehaviors
{
    /// <summary>
    /// Contains argument validation test scenarios for <c>Do</c> and <c>DoAsync</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public void Do_WithValueAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Do((Action<bool>)null!));
        }

        [Fact]
        public void Do_WithParameterlessAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Do((Action)null!));
        }

        [Fact]
        public Task DoAsync_WithValueAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).DoAsync((Func<bool, Task>)null!));
        }

        [Fact]
        public Task DoAsync_WithParameterlessAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).DoAsync((Func<Task>)null!));
        }
    }
}
