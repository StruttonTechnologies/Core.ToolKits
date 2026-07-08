namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns the default value for <typeparamref name="TResult"/> if the guard condition matched, otherwise invokes the factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of result to return.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// A factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The default value or the result from the factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public TResult? ReturnDefault<TResult>(Func<T, TResult> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            return _isMatch ? default : notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns the default value for <typeparamref name="TResult"/> if the guard condition matched, otherwise invokes the asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of result to return.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// An asynchronous factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The default value or the result from the asynchronous factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult?> ReturnDefault<TResult>(Func<T, Task<TResult>> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return default;
            }

            return await notMatchedFactory(_value!);
        }
    }
}
