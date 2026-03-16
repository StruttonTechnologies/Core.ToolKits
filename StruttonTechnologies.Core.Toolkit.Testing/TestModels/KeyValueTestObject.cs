using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.TestModels
{
    /// <summary>
    /// Represents a test object that contains a key and a value.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type of the key.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the value.
    /// </typeparam>
    /// 
    [ExcludeFromCodeCoverage]
    public sealed class KeyValueTestObject<TKey, TValue>
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public TKey? Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TValue? Value { get; set; }
    }
}
