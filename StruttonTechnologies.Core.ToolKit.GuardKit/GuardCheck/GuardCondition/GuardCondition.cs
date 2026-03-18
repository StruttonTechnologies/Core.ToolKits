/*
    GuardCondition namespace notes:
    All GuardCondition files in this package intentionally use the
    StruttonTechnologies.Core.ToolKit.GuardKit namespace regardless of folder layout.

    Folder structure is for organization only and does not define the namespace.
*/

namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    /// <summary>
    /// Represents the continuation state returned from a guard evaluation.
    /// </summary>
    /// <typeparam name="T">
    /// The type of value being evaluated.
    /// </typeparam>
    /// <remarks>
    /// Instances of this type are produced by <see cref="Guard"/> entry methods
    /// and used as part of the fluent guard pipeline.
    /// </remarks>
    public readonly partial struct GuardCondition<T>
    {
        private readonly T? _value;
        private readonly bool _isMatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardCondition{T}"/> struct.
        /// </summary>
        /// <param name="value">The value being evaluated.</param>
        /// <param name="isMatch">A value indicating whether the guard condition matched.</param>
        internal GuardCondition(T? value, bool isMatch)
        {
            _value = value;
            _isMatch = isMatch;
        }
    }
}
