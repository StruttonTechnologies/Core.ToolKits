using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Data
{
    /// <summary>
    /// Provides common string-based theory data sets.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class StringTheoryData
    {
        /// <summary>
        /// Gets null, empty, and whitespace string values.
        /// </summary>
        public static IEnumerable<object[]> NullOrWhiteSpace =>
        [
            TheoryDataBuilder.CreateRow<string?>(null),
            TheoryDataBuilder.CreateRow(string.Empty),
            TheoryDataBuilder.CreateRow(" "),
            TheoryDataBuilder.CreateRow("  "),
            TheoryDataBuilder.CreateRow("\t"),
            TheoryDataBuilder.CreateRow("\r\n"),
        ];

        /// <summary>
        /// Gets non-empty, non-whitespace string values.
        /// </summary>
        public static IEnumerable<object[]> Populated =>
        [
            TheoryDataBuilder.CreateRow("a"),
            TheoryDataBuilder.CreateRow("test"),
            TheoryDataBuilder.CreateRow("123"),
            TheoryDataBuilder.CreateRow("hello world"),
        ];

        /// <summary>
        /// Gets empty string values.
        /// </summary>
        public static IEnumerable<object[]> Empty =>
        [
            TheoryDataBuilder.CreateRow(string.Empty),
        ];

        /// <summary>
        /// Gets whitespace-only string values.
        /// </summary>
        public static IEnumerable<object[]> WhiteSpace =>
        [
            TheoryDataBuilder.CreateRow(" "),
            TheoryDataBuilder.CreateRow("  "),
            TheoryDataBuilder.CreateRow("\t"),
            TheoryDataBuilder.CreateRow("\r\n"),
        ];
    }
}
