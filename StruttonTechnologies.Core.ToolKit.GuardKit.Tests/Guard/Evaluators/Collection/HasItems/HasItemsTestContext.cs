namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Collection.HasItems
{
    /// <summary>
    /// Provides test data specific to <c>Guard.HasItems</c>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class HasItemsTestContext
    {
        /// <summary>
        /// Gets objects whose selected collections are empty.
        /// </summary>
        public static IEnumerable<object[]> EmptySelectorObjects =>
        [
            TheoryDataBuilder.CreateRow(new EnumerableTestObject<string>
            {
                Items = Enumerable.Empty<string>(),
            }),
            TheoryDataBuilder.CreateRow(new EnumerableTestObject<string>
            {
                Items = Array.Empty<string>(),
            }),
            TheoryDataBuilder.CreateRow(new EnumerableTestObject<string>
            {
                Items = [],
            }),
        ];

        /// <summary>
        /// Gets objects whose selected collections contain items.
        /// </summary>
        public static IEnumerable<object[]> PopulatedSelectorObjects =>
        [
            TheoryDataBuilder.CreateRow(new EnumerableTestObject<string>
            {
                Items = new[] { "one" },
            }),
            TheoryDataBuilder.CreateRow(new EnumerableTestObject<string>
            {
                Items = new[] { "one", "two" },
            }),
            TheoryDataBuilder.CreateRow(new EnumerableTestObject<string>
            {
                Items = ["one", "two", "three"],
            }),
        ];

        /// <summary>
        /// Gets parent objects whose child value collections contain items.
        /// </summary>
        public static IEnumerable<object[]> NestedPopulatedSelectorObjects =>
        [
            TheoryDataBuilder.CreateRow(new ParentTestObject<EnumerableTestObject<int>>
            {
                Child = new EnumerableTestObject<int>
                {
                    Items = new[] { 1, 2, 3 },
                },
            }),
        ];
    }
}
