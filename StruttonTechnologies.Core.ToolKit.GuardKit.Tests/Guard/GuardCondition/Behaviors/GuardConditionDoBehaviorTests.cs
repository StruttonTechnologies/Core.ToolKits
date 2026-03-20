namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for side-effect behaviors on <see cref="GuardCondition{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GuardConditionDoBehaviorTests
    {
        /// <summary>
        /// Contains test scenarios for <c>Do(Action{T})</c>.
        /// </summary>
        #region Do - Action<T>

        [Fact]
        public void Do_WithValueAction_WhenMatched_ExecutesAction()
        {
            int captured = 0;

            GuardTest.IsTrue(true).Do(value => captured = value ? 1 : -1);

            Assert.Equal(1, captured);
        }

        [Fact]
        public void Do_WithValueAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            GuardTest.IsTrue(false).Do(_ => executed = true);

            Assert.False(executed);
        }

        [Fact]
        public void Do_WithValueAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Do((Action<bool>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>Do(Action)</c>.
        /// </summary>
        #region Do - Action

        [Fact]
        public void Do_WithParameterlessAction_WhenMatched_ExecutesAction()
        {
            bool executed = false;

            GuardTest.IsTrue(true).Do(() => executed = true);

            Assert.True(executed);
        }

        [Fact]
        public void Do_WithParameterlessAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            GuardTest.IsTrue(false).Do(() => executed = true);

            Assert.False(executed);
        }

        [Fact]
        public void Do_WithParameterlessAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).Do((Action)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>DoAsync(Func{T, Task})</c>.
        /// </summary>
        #region DoAsync - Func<T, Task>

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
        public Task DoAsync_WithValueAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).DoAsync((Func<bool, Task>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>DoAsync(Func{Task})</c>.
        /// </summary>
        #region DoAsync - Func<Task>

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

        [Fact]
        public Task DoAsync_WithParameterlessAction_WhenActionIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).DoAsync((Func<Task>)null!));
        }

        #endregion
    }
}
