namespace StruttonTechnologies.Core.ToolKit.Gaurds.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains null-input test scenarios for <c>Guard.HasItems</c>.
    /// </summary>
    public class NullInputTests
    {
        /// <summary>
        /// Verifies that <c>Guard.HasItems</c> does not match when the collection is <see langword="null"/>.
        /// </summary>
        [Fact]
        public void HasItems_WhenCollectionIsNull_ReturnsNotMatched()
        {
            IEnumerable<int>? collection = null;

            GuardCondition<IEnumerable<int>> result = GuardEvaluator.HasItems(collection);

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        /// <summary>
        /// Verifies that the selector overload does not match when the object is <see langword="null"/>.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenObjectIsNull_ReturnsNotMatched()
        {
            EnumerableTestObject<string>? value = null;

            GuardCondition<EnumerableTestObject<string>> result = GuardEvaluator.HasItems(value, x => x.Items);

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        /// <summary>
        /// Verifies that the selector overload does not match when the selected collection is <see langword="null"/>.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenSelectedCollectionIsNull_ReturnsNotMatched()
        {
            EnumerableTestObject<string> value = new EnumerableTestObject<string>
            {
                Items = null,
            };

            GuardCondition<EnumerableTestObject<string>> result = GuardEvaluator.HasItems(value, x => x.Items);

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        /// <summary>
        /// Verifies that the selector overload throws when the selector is <see langword="null"/>.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            EnumerableTestObject<string> value = new EnumerableTestObject<string>
            {
                Items = new[] { "one" },
            };

            Func<EnumerableTestObject<string>, IEnumerable<string>?> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => GuardEvaluator.HasItems(value, selector));

            Assert.Equal("selector", exception.ParamName);
        }
    }
}
