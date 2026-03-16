using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Testing.TestModels
{
    /// <summary>
    /// Represents a test object that contains a single child object.
    /// </summary>
    /// <typeparam name="TChild">
    /// The type of the child object.
    /// </typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class ParentTestObject<TChild>
    {
        /// <summary>
        /// Gets or sets the child object.
        /// </summary>
        public TChild? Child { get; set; }
    }
}
