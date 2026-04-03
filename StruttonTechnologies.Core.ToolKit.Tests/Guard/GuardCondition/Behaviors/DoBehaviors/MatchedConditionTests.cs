namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.DoBehaviors
{
    /// <summary>
    /// Contains matched-condition test scenarios for <c>Do</c> and <c>DoAsync</c> behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MatchedConditionTests
    {
        [Fact]
        public void Do_WithValueAction_WhenMatched_ExecutesAction()
        {
            int captured = 0;

            GuardTest.IsTrue(true).Do(value => captured = value ? 1 : -1);

            Assert.Equal(1, captured);
        }

        [Fact]
        public void Do_WithParameterlessAction_WhenMatched_ExecutesAction()
        {
            bool executed = false;

            GuardTest.IsTrue(true).Do(() => executed = true);

            Assert.True(executed);
        }

        [Fact]
        public async Task DoAsync_WithValueAction_WhenMatched_ExecutesAction()
        {
            int captured = 0;

            await GuardTest.IsTrue(true).DoAsync(value =>
            {
                captured = value ? 1 : -1;
                return Task.CompletedTask;
            });

            Assert.Equal(1, captured);
        }

        [Fact]
        public async Task DoAsync_WithParameterlessAction_WhenMatched_ExecutesAction()
        {
            bool executed = false;

            await GuardTest.IsTrue(true).DoAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            Assert.True(executed);
        }
    }
}
