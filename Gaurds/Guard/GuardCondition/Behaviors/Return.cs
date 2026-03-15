namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns the specified value if the guard condition matched, otherwise invokes the factory to produce a result.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of result to return.
        /// </typeparam>
        /// <param name="matchedReturn">
        /// The value to return when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// A factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The matched value or the result from the factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public TResult Return<TResult>(TResult matchedReturn, Func<T, TResult> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            return _isMatch ? matchedReturn : notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns a value produced by the matched factory if the guard condition matched, otherwise invokes the not-matched factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of result to return.
        /// </typeparam>
        /// <param name="matchedFactory">
        /// A factory function that produces the result when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// A factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The result from either the matched or not-matched factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="matchedFactory"/> or <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public TResult Return<TResult>(Func<TResult> matchedFactory, Func<T, TResult> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(matchedFactory);
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            return _isMatch ? matchedFactory() : notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns the specified value if the guard condition matched, otherwise invokes the asynchronous factory to produce a result.
        /// </summary>
        /// <typeparam name="TResult">
        /// The result type.
        /// </typeparam>
        /// <param name="matchedReturn">
        /// The value to return when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// The asynchronous function to execute when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The provided value when the guard condition matched; otherwise the result of the provided factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult> Return<TResult>(TResult matchedReturn, Func<T, Task<TResult>> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return matchedReturn;
            }

            return await notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns a value produced by the matched asynchronous factory if the guard condition matched, otherwise invokes the not-matched asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of result to return.
        /// </typeparam>
        /// <param name="matchedFactory">
        /// An asynchronous factory function that produces the result when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// An asynchronous factory function that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The result from either the matched or not-matched asynchronous factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="matchedFactory"/> or <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult> Return<TResult>(Func<Task<TResult>> matchedFactory, Func<T, Task<TResult>> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(matchedFactory);
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return await matchedFactory();
            }

            return await notMatchedFactory(_value!);
        }
    }
}
