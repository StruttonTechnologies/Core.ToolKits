namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.DoBehaviors
{
    /// <summary>
    /// Contains not-matched-condition test scenarios for <c>Do</c> and <c>DoAsync</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotMatchedConditionTests
    {
        [Fact]
        public void Do_WithValueAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            GuardTest.IsTrue(false).Do(_ => executed = true);

            Assert.False(executed);
        }

        [Fact]
        public void Do_WithParameterlessAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            GuardTest.IsTrue(false).Do(() => executed = true);

            Assert.False(executed);
        }

        [Fact]
        public async Task DoAsync_WithValueAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            Task result = GuardTest.IsTrue(false).DoAsync(_ =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            await result;

            Assert.False(executed);
            Assert.Same(Task.CompletedTask, result);
        }

        [Fact]
        public async Task DoAsync_WithParameterlessAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            Task result = GuardTest.IsTrue(false).DoAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            await result;

            Assert.False(executed);
            Assert.Same(Task.CompletedTask, result);
        }
    }
}
