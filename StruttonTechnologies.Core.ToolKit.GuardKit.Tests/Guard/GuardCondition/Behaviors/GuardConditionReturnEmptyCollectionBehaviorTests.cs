namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors
{
    /// <summary>
    /// Contains test scenarios for empty collection return behaviors on <see cref="GuardCondition{T}"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GuardConditionReturnEmptyCollectionBehaviorTests
    {
        /// <summary>
        /// Contains test scenarios for <c>ReturnEmptyArray</c>.
        /// </summary>
        #region ReturnEmptyArray - Func<T, Task<TResult[]>>

        [Fact]
        public async Task ReturnEmptyArray_WhenMatched_ReturnsEmptyArray()
        {
            int[] result = await GuardTest.IsTrue(true).ReturnEmptyArray(_ => Task.FromResult(new[] { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyArray_WhenNotMatched_ReturnsFactoryValue()
        {
            int[] result = await GuardTest.IsTrue(false).ReturnEmptyArray(_ => Task.FromResult(new[] { 1, 2, 3 }));

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public Task ReturnEmptyArray_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnEmptyArray((Func<bool, Task<int[]>>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>ReturnEmptyEnumerable</c>.
        /// </summary>
        #region ReturnEmptyEnumerable - Func<T, Task<IEnumerable<TResult>>>

        [Fact]
        public async Task ReturnEmptyEnumerable_WhenMatched_ReturnsEmptyEnumerable()
        {
            IEnumerable<int> result = await GuardTest.IsTrue(true).ReturnEmptyEnumerable(_ => Task.FromResult<IEnumerable<int>>(new[] { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyEnumerable_WhenNotMatched_ReturnsFactoryValue()
        {
            IEnumerable<int> result = await GuardTest.IsTrue(false).ReturnEmptyEnumerable(_ => Task.FromResult<IEnumerable<int>>(new[] { 1, 2, 3 }));

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public Task ReturnEmptyEnumerable_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnEmptyEnumerable((Func<bool, Task<IEnumerable<int>>>)null!));
        }

        #endregion

        /// <summary>
        /// Contains test scenarios for <c>ReturnEmptyList</c>.
        /// </summary>
        #region ReturnEmptyList - Func<T, Task<List<TResult>>>

        [Fact]
        public async Task ReturnEmptyList_WhenMatched_ReturnsEmptyList()
        {
            List<int> result = await GuardTest.IsTrue(true).ReturnEmptyList(_ => Task.FromResult(new List<int> { 1, 2, 3 }));

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyList_WhenNotMatched_ReturnsFactoryValue()
        {
            List<int> result = await GuardTest.IsTrue(false).ReturnEmptyList(_ => Task.FromResult(new List<int> { 1, 2, 3 }));

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public Task ReturnEmptyList_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnEmptyList((Func<bool, Task<List<int>>>)null!));
        }

        #endregion
    }
}
