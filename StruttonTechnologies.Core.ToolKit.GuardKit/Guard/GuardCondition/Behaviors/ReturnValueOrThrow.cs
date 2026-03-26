namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    /// <summary>
    /// Provides behavior for throwing an exception when the condition is matched;
    /// otherwise returns the guarded value.
    /// </summary>
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Throws the exception produced by the specified factory when the condition is matched;
        /// otherwise returns the guarded value.
        /// </summary>
        /// <typeparam name="TException">
        /// The type of exception to throw.
        /// </typeparam>
        /// <param name="exceptionFactory">
        /// The factory used to create the exception.
        /// </param>
        /// <returns>
        /// The guarded value when the condition is not matched.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="exceptionFactory"/> is <see langword="null"/>.
        /// </exception>
        public T ReturnOrThrow<TException>(Func<TException> exceptionFactory)
            where TException : Exception
        {
            ArgumentNullException.ThrowIfNull(exceptionFactory);

            if (_isMatch)
            {
                throw exceptionFactory();
            }

            return _value!;
        }
    }
}
