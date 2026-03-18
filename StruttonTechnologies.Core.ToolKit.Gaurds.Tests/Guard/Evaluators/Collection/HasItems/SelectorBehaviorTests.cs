namespace StruttonTechnologies.Core.ToolKit.Guards.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains selector-specific behavior tests for <c>Guard.HasItems</c>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SelectorBehaviorTests
    {
        /// <summary>
        /// Verifies that the selector overload works with a nested property selector.
        /// </summary>
        [Theory]
        [MemberData(nameof(HasItemsTestContext.NestedPopulatedSelectorObjects), MemberType = typeof(HasItemsTestContext))]
        public void HasItems_WithSelector_WhenNestedPropertyContainsItems_ReturnsMatched(ParentTestObject<EnumerableTestObject<int>> value)
        {
            GuardCondition<ParentTestObject<EnumerableTestObject<int>>> result =
                GuardEvaluator.HasItems(value, x => x.Child!.Items);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }

        /// <summary>
        /// Verifies that the selector overload does not match when a filtered collection is empty.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenFilteredCollectionIsEmpty_ReturnsNotMatched()
        {
            var value = new EnumerableTestObject<string>
            {
                Items = new[] { "one", "two", "three" },
            };

            GuardCondition<EnumerableTestObject<string>> result =
                GuardEvaluator.HasItems(value, x => x.Items!.Where(item => item.StartsWith('z')));

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        /// <summary>
        /// Verifies that the selector overload matches when a filtered collection contains items.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenFilteredCollectionContainsItems_ReturnsMatched()
        {
            var value = new EnumerableTestObject<string>
            {
                Items = new[] { "alpha", "beta", "gamma" },
            };

            GuardCondition<EnumerableTestObject<string>> result =
                GuardEvaluator.HasItems(value, x => x.Items!.Where(item => item.StartsWith('a')));

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }
    }
}
