namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns an empty list if the guard condition matched; otherwise executes the provided asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The element type of the returned list.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// The asynchronous function to execute when the guard condition did not match.
        /// </param>
        /// <returns>
        /// An empty list when the guard condition matched; otherwise the result of the provided factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<List<TResult>> ReturnEmptyList<TResult>(Func<T, Task<List<TResult>>> notMatchedFactory)
        {
            ArgumentNullException.ThrowIfNull(notMatchedFactory);

            if (_isMatch)
            {
                return [];
            }

            return await notMatchedFactory(_value!);
        }
    }
}
