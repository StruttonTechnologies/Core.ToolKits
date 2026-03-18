using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Data
{
    /// <summary>
    /// Provides common enumerable-based theory data sets.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class EnumerableTheoryData
    {
        /// <summary>
        /// Gets empty enumerable collections of integers.
        /// </summary>
        public static IEnumerable<object[]> EmptyIntegers =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(Enumerable.Empty<int>()),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(Array.Empty<int>()),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>([]),
        ];

        /// <summary>
        /// Gets populated enumerable collections of integers.
        /// </summary>
        public static IEnumerable<object[]> PopulatedIntegers =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(new[] { 1 }),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(new[] { 1, 2 }),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>([1, 2, 3]),
            TheoryDataBuilder.CreateRow<IEnumerable<int>>(Enumerable.Range(1, 5)),
        ];

        /// <summary>
        /// Gets empty enumerable collections of strings.
        /// </summary>
        public static IEnumerable<object[]> EmptyStrings =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(Enumerable.Empty<string>()),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(Array.Empty<string>()),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>([]),
        ];

        /// <summary>
        /// Gets populated enumerable collections of strings.
        /// </summary>
        public static IEnumerable<object[]> PopulatedStrings =>
        [
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(new[] { "one" }),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(new[] { "one", "two" }),
            TheoryDataBuilder.CreateRow<IEnumerable<string>>(["one", "two", "three"]),
        ];
    }
}
