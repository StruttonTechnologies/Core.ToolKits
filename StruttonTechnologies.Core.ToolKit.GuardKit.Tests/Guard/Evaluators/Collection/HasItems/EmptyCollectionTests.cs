namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains empty collection test scenarios for <c>GuardTest.HasItems</c>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EmptyCollectionTests
    {
        /// <summary>
        /// Verifies that <c>GuardTest.HasItems</c> does not match for empty collections.
        /// </summary>
        /// <param name="collection">
        /// The empty collection to evaluate.
        /// </param>
        [Theory]
        [InlineData(new int[] { })]
        public void HasItems_WhenCollectionIsEmpty_ReturnsNotMatched(IEnumerable<int> collection)
        {
            GuardCondition<IEnumerable<int>> result = GuardTest.HasItems(collection);

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
        [InlineData("A")]
        [InlineData("Hello")]
        public void HasItems_WithSelector_WhenSelectedCollectionHasItems_ReturnsMatched(string item)
        {
            EnumerableTestObject<string> value = new EnumerableTestObject<string>
            {
                Items = new[] { item }
            };

            GuardCondition<EnumerableTestObject<string>> result = GuardTest.HasItems(value, x => x.Items);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }
    }
}
