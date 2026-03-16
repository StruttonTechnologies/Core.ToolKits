using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Data
{
    /// <summary>
    /// Provides commonly used boolean-based theory data sets.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class BooleanTheoryData
    {
        /// <summary>
        /// Gets true and false values.
        /// </summary>
        public static IEnumerable<object[]> TrueAndFalse =>
        [
            TheoryDataBuilder.CreateRow(true),
            TheoryDataBuilder.CreateRow(false)
        ];

        /// <summary>
        /// Gets only true values.
        /// </summary>
        public static IEnumerable<object[]> True =>
        [
            TheoryDataBuilder.CreateRow(true)
        ];

        /// <summary>
        /// Gets only false values.
        /// </summary>
        public static IEnumerable<object[]> False =>
        [
            TheoryDataBuilder.CreateRow(false)
        ];
    }
}
