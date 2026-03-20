namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains populated collection test scenarios for <c>GuardTest.HasItems</c>.
    /// </summary>
    public class PopulatedCollectionTests
    {
        /// <summary>
        /// Verifies that <c>GuardTest.HasItems</c> matches for populated collections.
        /// </summary>
        /// <param name="collection">
        /// The populated collection to evaluate.
        /// </param>
        [Theory]
        [InlineData(new[] { 1 })]
        [InlineData(new[] { 1, 2 })]
        [InlineData(new[] { 1, 2, 3 })]
        public void HasItems_WhenCollectionContainsItems_ReturnsMatched(IEnumerable<int> collection)
        {
            GuardCondition<IEnumerable<int>> result = GuardTest.HasItems(collection);

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
        [InlineData("one")]
        [InlineData("one", "two")]
        [InlineData("one", "two", "three")]
        public void HasItems_WithSelector_WhenSelectedCollectionContainsItems_ReturnsMatched(params string[] items)
        {
            EnumerableTestObject<string> value = new EnumerableTestObject<string> { Items = items };

            GuardCondition<EnumerableTestObject<string>> result = GuardTest.HasItems(value, x => x.Items);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }
    }
}
