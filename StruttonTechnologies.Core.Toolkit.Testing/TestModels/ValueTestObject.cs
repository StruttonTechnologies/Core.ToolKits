using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.TestModels
{
    /// <summary>
    /// Represents a simple test object that contains a single value.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value.
    /// </typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class ValueTestObject<T>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public T? Value { get; set; }
    }
}
