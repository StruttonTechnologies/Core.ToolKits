namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    /// <summary>
    /// Provides behaviors for returning a guarded value or a default value.
    /// </summary>
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns the default value when the guard condition matched;
        /// otherwise returns the guarded value.
        /// </summary>
        /// <returns>
        /// The default value when matched; otherwise the guarded value.
        /// </returns>
        public T? ReturnValueOrNull()
        {
            return _isMatch ? default : _value;
        }
    }
}
