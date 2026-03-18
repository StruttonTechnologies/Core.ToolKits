using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.Data
{
    /// <summary>
    /// Provides helper methods for building theory data collections.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TheoryDataBuilder
    {
        /// <summary>
        /// Creates a single-parameter theory data row.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="value">
        /// The value to include in the row.
        /// </param>
        /// <returns>
        /// An object array containing the specified value.
        /// </returns>
        public static object[] CreateRow<T>(T value)
        {
            return new object[] { value! };
        }

        /// <summary>
        /// Creates a two-parameter theory data row.
        /// </summary>
        /// <typeparam name="T1">
        /// The type of the first value.
        /// </typeparam>
        /// <typeparam name="T2">
        /// The type of the second value.
        /// </typeparam>
        /// <param name="value1">
        /// The first value.
        /// </param>
        /// <param name="value2">
        /// The second value.
        /// </param>
        /// <returns>
        /// An object array containing the specified values.
        /// </returns>
        public static object[] CreateRow<T1, T2>(T1 value1, T2 value2)
        {
            return new object[] { value1!, value2! };
        }

        /// <summary>
        /// Creates a three-parameter theory data row.
        /// </summary>
        /// <typeparam name="T1">
        /// The type of the first value.
        /// </typeparam>
        /// <typeparam name="T2">
        /// The type of the second value.
        /// </typeparam>
        /// <typeparam name="T3">
        /// The type of the third value.
        /// </typeparam>
        /// <param name="value1">
        /// The first value.
        /// </param>
        /// <param name="value2">
        /// The second value.
        /// </param>
        /// <param name="value3">
        /// The third value.
        /// </param>
        /// <returns>
        /// An object array containing the specified values.
        /// </returns>
        public static object[] CreateRow<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            return new object[] { value1!, value2!, value3! };
        }
    }
}
