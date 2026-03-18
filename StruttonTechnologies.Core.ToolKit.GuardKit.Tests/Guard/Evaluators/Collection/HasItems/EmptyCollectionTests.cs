using StruttonTechnologies.Core.ToolKit.GuardKit;
using StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Collection.HasItems;

namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains empty collection test scenarios for <c>Guard.HasItems</c>.
    /// </summary>
    public class EmptyCollectionTests
    {
        /// <summary>
        /// Verifies that <c>Guard.HasItems</c> does not match for empty collections.
        /// </summary>
        /// <param name="collection">
        /// The empty collection to evaluate.
        /// </param>
        [Theory]
        [MemberData(nameof(EnumerableTheoryData.EmptyIntegers), MemberType = typeof(EnumerableTheoryData))]
        public void HasItems_WhenCollectionIsEmpty_ReturnsNotMatched(IEnumerable<int> collection)
        {
            GuardCondition<IEnumerable<int>> result = Guard.HasItems(collection);

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        /// <summary>
        /// Verifies that the selector overload does not match when the selected collection is empty.
        /// </summary>
        /// <param name="value">
        /// The object whose selected collection is empty.
        /// </param>
        [Theory]
        [MemberData(nameof(HasItemsTestContext.EmptySelectorObjects), MemberType = typeof(HasItemsTestContext))]
        public void HasItems_WithSelector_WhenSelectedCollectionIsEmpty_ReturnsNotMatched(EnumerableTestObject<string> value)
        {
            GuardCondition<EnumerableTestObject<string>> result = Guard.HasItems(value, x => x.Items);

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }
    }
}
