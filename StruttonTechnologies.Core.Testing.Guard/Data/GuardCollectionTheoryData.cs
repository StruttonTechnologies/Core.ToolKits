using StruttonTechnologies.Core.ToolKit.Testing.Data;

namespace StruttonTechnologies.Core.Toolkit.Testing.Guard.Data
{
    /// <summary>
    /// Provides collection-based theory data commonly used when testing guard evaluators.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class GuardCollectionTheoryData
    {
        /// <summary>
        /// Gets empty integer collections commonly used for guard tests.
        /// </summary>
        public static IEnumerable<object[]> EmptyIntegers =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(Enumerable.Empty<int>()),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(Array.Empty<int>()),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>([]),
        ];

        /// <summary>
        /// Gets populated integer collections commonly used for guard tests.
        /// </summary>
        public static IEnumerable<object[]> PopulatedIntegers =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(new[] { 1 }),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(new[] { 1, 2 }),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>([1, 2, 3]),
        ];

        /// <summary>
        /// Gets empty string collections commonly used for guard tests.
        /// </summary>
        public static IEnumerable<object[]> EmptyStrings =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(Enumerable.Empty<string>()),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(Array.Empty<string>()),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>([]),
        ];

        /// <summary>
        /// Gets populated string collections commonly used for guard tests.
        /// </summary>
        public static IEnumerable<object[]> PopulatedStrings =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(new[] { "one" }),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(new[] { "one", "two" }),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(["one", "two", "three"]),
        ];
    }
}
