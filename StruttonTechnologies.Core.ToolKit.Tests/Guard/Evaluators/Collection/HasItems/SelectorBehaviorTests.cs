namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Contains selector-specific behavior tests for <c>GuardTest.HasItems</c>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SelectorBehaviorTests
    {
        /// <summary>
        /// Verifies that the selector overload works with a nested property selector.
        /// </summary>
        /// <summary>
        /// Verifies that the selector overload works with a nested property selector.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(1, 2)]
        [InlineData(1, 2, 3)]
        public void HasItems_WithSelector_WhenNestedPropertyContainsItems_ReturnsMatched(params int[] items)
        {
            ParentTestObject<EnumerableTestObject<int>> value = new ParentTestObject<EnumerableTestObject<int>>
            {
                Child = new EnumerableTestObject<int>
                {
                    Items = items,
                },
            };

            GuardCondition<ParentTestObject<EnumerableTestObject<int>>> result =
                GuardTest.HasItems(value, x => x.Child!.Items);

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }

        /// <summary>
        /// Verifies that the selector overload does not match when a filtered collection is empty.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenFilteredCollectionIsEmpty_ReturnsNotMatched()
        {
            EnumerableTestObject<string> value = new EnumerableTestObject<string>
            {
                Items = new[] { "one", "two", "three" },
            };

            GuardCondition<EnumerableTestObject<string>> result =
                GuardTest.HasItems(value, x => x.Items!.Where(item => item.StartsWith('z')));

            bool matched = result.Return(true, _ => false);

            Assert.False(matched);
        }

        /// <summary>
        /// Verifies that the selector overload matches when a filtered collection contains items.
        /// </summary>
        [Fact]
        public void HasItems_WithSelector_WhenFilteredCollectionContainsItems_ReturnsMatched()
        {
            EnumerableTestObject<string> value = new EnumerableTestObject<string>
            {
                Items = new[] { "alpha", "beta", "gamma" },
            };

            GuardCondition<EnumerableTestObject<string>> result =
                GuardTest.HasItems(value, x => x.Items!.Where(item => item.StartsWith('a')));

            bool matched = result.Return(true, _ => false);

            Assert.True(matched);
        }
    }
}
