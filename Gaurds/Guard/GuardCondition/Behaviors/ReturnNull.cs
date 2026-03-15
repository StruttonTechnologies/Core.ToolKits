namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns <see langword="null"/> if the guard condition matched, otherwise invokes the factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The reference type of result to return.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// A factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// <see langword="null"/> or the result from the factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public TResult? ReturnNull<TResult>(Func<T, TResult> notMatchedFactory)
            where TResult : class
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            return _isMatch ? null : notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns <see langword="null"/> if the guard condition matched, otherwise invokes the asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The reference type of result to return.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// An asynchronous factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// <see langword="null"/> or the result from the asynchronous factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult?> ReturnNull<TResult>(Func<T, Task<TResult>> notMatchedFactory)
            where TResult : class
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return null;
            }

            return await notMatchedFactory(_value!);
        }
    }
}
