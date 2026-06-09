namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    /// <summary>
    /// Represents a guarded value and provides continuation behaviors
    /// for matched and non-matched outcomes.
    /// </summary>
    /// <typeparam name="T">The type of guarded value.</typeparam>
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns the specified value when the guard condition matched;
        /// otherwise invokes the provided factory.
        /// </summary>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <param name="matchedReturn">
        /// The value to return when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// A factory that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The matched return value or the result from the not-matched factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public TResult Return<TResult>(
            TResult matchedReturn,
            Func<T, TResult> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            return _isMatch
                ? matchedReturn
                : notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns a value produced by the matched factory when the guard condition matched;
        /// otherwise invokes the not-matched factory.
        /// </summary>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <param name="matchedFactory">
        /// A factory that produces the result when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// A factory that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// The result from either the matched or not-matched factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="matchedFactory"/> or
        /// <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public TResult Return<TResult>(
            Func<TResult> matchedFactory,
            Func<T, TResult> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(matchedFactory);
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            return _isMatch
                ? matchedFactory()
                : notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns the specified value when the guard condition matched;
        /// otherwise invokes the provided asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <param name="matchedReturn">
        /// The value to return when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// An asynchronous factory that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// A task containing the matched return value or the result from the not-matched factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult> ReturnAsync<TResult>(
            TResult matchedReturn,
            Func<T, Task<TResult>> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return matchedReturn;
            }

            return await notMatchedFactory(_value!);
        }

        /// <summary>
        /// Returns a value produced by the matched asynchronous factory when the guard condition matched;
        /// otherwise invokes the not-matched asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <param name="matchedFactory">
        /// An asynchronous factory that produces the result when the guard condition matched.
        /// </param>
        /// <param name="notMatchedFactory">
        /// An asynchronous factory that produces the result when the guard condition did not match.
        /// </param>
        /// <returns>
        /// A task containing the result from either the matched or not-matched asynchronous factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="matchedFactory"/> or
        /// <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult> ReturnAsync<TResult>(
            Func<Task<TResult>> matchedFactory,
            Func<T, Task<TResult>> notMatchedFactory)
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
