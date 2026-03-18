namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public readonly partial struct GuardCondition<T>
    {
        /// <summary>
        /// Executes the specified action with the guarded value if the guard condition matched.
        /// </summary>
        /// <param name="action">
        /// The action to execute when the guard condition matched.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="action"/> is <see langword="null"/>.
        /// </exception>
        public void Do(Action<T> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (_isMatch)
            {
                action(_value!);
            }
        }

        /// <summary>
        /// Executes the specified action if the guard condition matched.
        /// </summary>
        /// <param name="action">
        /// The action to execute when the guard condition matched.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="action"/> is <see langword="null"/>.
        /// </exception>
        public void Do(Action action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (_isMatch)
            {
                action();
            }
        }

        /// <summary>
        /// Executes the specified asynchronous action with the guarded value if the guard condition matched.
        /// </summary>
        /// <param name="action">
        /// The asynchronous action to execute when the guard condition matched.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, or a completed task if the condition did not match.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="action"/> is <see langword="null"/>.
        /// </exception>
        public Task DoAsync(Func<T, Task> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            return _isMatch ? action(_value!) : Task.CompletedTask;
        }

        /// <summary>
        /// Executes the specified asynchronous action if the guard condition matched.
        /// </summary>
        /// <param name="action">
        /// The asynchronous action to execute when the guard condition matched.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, or a completed task if the condition did not match.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="action"/> is <see langword="null"/>.
        /// </exception>
        public Task DoAsync(Func<Task> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            return _isMatch ? action() : Task.CompletedTask;
        }
    }
}
