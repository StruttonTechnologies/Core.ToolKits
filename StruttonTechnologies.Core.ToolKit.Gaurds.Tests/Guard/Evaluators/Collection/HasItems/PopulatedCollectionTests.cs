namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains populated collection test scenarios for <c>Guard.HasItems</c>.
    /// </summary>
    public class PopulatedCollectionTests
    {
        /// <summary>
        /// Verifies that <c>Guard.HasItems</c> matches for populated collections.
        /// </summary>
        /// <param name="collection">
        /// The populated collection to evaluate.
        /// </param>
        [Theory]
        [MemberData(nameof(EnumerableTheoryData.PopulatedIntegers), MemberType = typeof(EnumerableTheoryData))]
        public void HasItems_WhenCollectionContainsItems_ReturnsMatched(IEnumerable<int> collection)
        {
            GuardCondition<IEnumerable<int>> result = GuardEvaluator.HasItems(collection);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }

        /// <summary>
        /// Verifies that the selector overload matches when the selected collection contains items.
        /// </summary>
        /// <param name="value">
        /// The object whose selected collection contains items.
        /// </param>
        [Theory]
        [MemberData(nameof(HasItemsTestContext.PopulatedSelectorObjects), MemberType = typeof(HasItemsTestContext))]
        public void HasItems_WithSelector_WhenSelectedCollectionContainsItems_ReturnsMatched(EnumerableTestObject<string> value)
        {
            GuardCondition<EnumerableTestObject<string>> result = GuardEvaluator.HasItems(value, x => x.Items);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }
    }
}
