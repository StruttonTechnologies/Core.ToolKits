namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns an empty enumerable if the guard condition matched; otherwise executes the provided asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The element type of the returned enumerable.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// The asynchronous function to execute when the guard condition did not match.
        /// </param>
        /// <returns>
        /// An empty enumerable when the guard condition matched; otherwise the result of the provided factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<IEnumerable<TResult>> ReturnEmptyEnumerable<TResult>(Func<T, Task<IEnumerable<TResult>>> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return Array.Empty<TResult>();
            }

            return await notMatchedFactory(_value!);
        }
    }
}
