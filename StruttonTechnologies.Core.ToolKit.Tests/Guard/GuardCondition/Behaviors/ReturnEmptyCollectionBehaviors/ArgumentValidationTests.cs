namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.GuardCondition.Behaviors.ReturnEmptyCollectionBehaviors
{
    /// <summary>
    /// Contains argument validation test scenarios for empty collection return behaviors.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public Task ReturnEmptyArray_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnEmptyArray((Func<bool, Task<int[]>>)null!));
        }

        [Fact]
        public Task ReturnEmptyEnumerable_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnEmptyEnumerable((Func<bool, Task<IEnumerable<int>>>)null!));
        }

        [Fact]
        public Task ReturnEmptyList_WhenFactoryIsNull_ThrowsArgumentNullException()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() =>
                GuardTest.IsTrue(true).ReturnEmptyList((Func<bool, Task<List<int>>>)null!));
        }
    }
}
