using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.TestModels
{
    /// <summary>
    /// Represents a test object that contains an enumerable collection of items.
    /// </summary>
    /// <typeparam name="T">
    /// The type of items in the collection.
    /// </typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class EnumerableTestObject<T>
    {
        /// <summary>
        /// Gets or sets the items collection.
        /// </summary>
        public IEnumerable<T>? Items { get; set; }
    }
}
