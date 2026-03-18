namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Returns an empty array if the guard condition matched; otherwise executes the provided asynchronous factory.
        /// </summary>
        /// <typeparam name="TResult">
        /// The element type of the returned array.
        /// </typeparam>
        /// <param name="notMatchedFactory">
        /// The asynchronous function to execute when the guard condition did not match.
        /// </param>
        /// <returns>
        /// An empty array when the guard condition matched; otherwise the result of the provided factory.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="notMatchedFactory"/> is <see langword="null"/>.
        /// </exception>
        public async Task<TResult[]> ReturnEmptyArray<TResult>(Func<T, Task<TResult[]>> notMatchedFactory)
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
