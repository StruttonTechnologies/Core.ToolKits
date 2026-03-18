namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for <see cref="GuardCondition{T}"/> behaviors.
    /// </summary>
    public class GuardConditionBehaviorTests
    {
        [Fact]
        public void Do_WithValueAction_WhenMatched_ExecutesAction()
        {
            int captured = 0;

            GuardTest.IsTrue(true).Do(value => captured = value ? 1 : -1);

            Assert.Equal(1, captured);
        }

        [Fact]
        public void Do_WithParameterlessAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            GuardTest.IsTrue(false).Do(() => executed = true);

            Assert.False(executed);
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
        public async Task DoAsync_WithParameterlessAction_WhenNotMatched_DoesNotExecuteAction()
        {
            bool executed = false;

            await GuardTest.IsTrue(false).DoAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            Assert.False(executed);
        }

        [Fact]
        public void Return_WithMatchedConstant_ReturnsMatchedValue()
        {
            string result = GuardTest.IsTrue(true).Return("matched", _ => "not-matched");

            Assert.Equal("matched", result);
        }

        [Fact]
        public void Return_WithMatchedFactory_ReturnsFactoryValue()
        {
            string result = GuardTest.IsTrue(true).Return(() => "matched", _ => "not-matched");

            Assert.Equal("matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedConstant_ReturnsMatchedValue()
        {
            string result = await GuardTest.IsTrue(true).Return("matched", _ => Task.FromResult("not-matched"));

            Assert.Equal("matched", result);
        }

        [Fact]
        public async Task ReturnAsync_WithMatchedFactory_ReturnsFactoryValue()
        {
            string result = await GuardTest.IsTrue(true).Return(() => Task.FromResult("matched"), _ => Task.FromResult("not-matched"));

            Assert.Equal("matched", result);
        }

        [Fact]
        public void ReturnDefault_WhenMatched_ReturnsDefault()
        {
            string? result = GuardTest.IsTrue(true).ReturnDefault<string>(_ => "fallback");

            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnDefaultAsync_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = await GuardTest.IsTrue(false).ReturnDefault(_ => Task.FromResult("fallback"));

            Assert.Equal("fallback", result);
        }

        [Fact]
        public void ReturnNull_WhenMatched_ReturnsNull()
        {
            string? result = GuardTest.IsTrue(true).ReturnNull(_ => "fallback");

            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnNullAsync_WhenNotMatched_ReturnsFactoryValue()
        {
            string? result = await GuardTest.IsTrue(false).ReturnNull(_ => Task.FromResult("fallback"));

            Assert.Equal("fallback", result);
        }

        [Fact]
        public async Task ReturnEmptyArray_WhenMatched_ReturnsEmptyArray()
        {
            int[] result = await GuardTest.IsTrue(true).ReturnEmptyArray(_ => Task.FromResult(new[] { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyEnumerable_WhenMatched_ReturnsEmptyEnumerable()
        {
            IEnumerable<int> result = await GuardTest.IsTrue(true).ReturnEmptyEnumerable(_ => Task.FromResult<IEnumerable<int>>(new[] { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyList_WhenMatched_ReturnsEmptyList()
        {
            List<int> result = await GuardTest.IsTrue(true).ReturnEmptyList(_ => Task.FromResult(new List<int> { 1, 2, 3 }));

            Assert.Empty(result);
        }
    }
}
