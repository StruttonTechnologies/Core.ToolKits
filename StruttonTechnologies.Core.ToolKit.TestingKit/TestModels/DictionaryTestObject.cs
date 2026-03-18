using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.TestModels
{
    /// <summary>
    /// Represents a test object that contains a dictionary of key/value pairs.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type of the dictionary key.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the dictionary value.
    /// </typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class DictionaryTestObject<TKey, TValue>
        where TKey : notnull
    {
        /// <summary>
        /// Gets or sets the dictionary items.
        /// </summary>
        public IDictionary<TKey, TValue>? Items { get; set; }
    }
}
