namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided Boolean value is <see langword="false"/>.
        /// </summary>
        /// <param name="value">
        /// The Boolean value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is <see langword="false"/>.
        /// </returns>
        public static GuardCondition<bool> IsFalse(bool value)
        {
            return new GuardCondition<bool>(value, value is false);
        }

        /// <summary>
        /// Evaluates whether the selected Boolean value from the provided object is <see langword="false"/>.
        /// The guard also matches when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the Boolean value.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the object is <see langword="null"/> or the selected
        /// Boolean value is <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<T> IsFalse<T>(T? value, Func<T, bool> selector)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, true);
            }

            return new GuardCondition<T>(value, selector(value) is false);
        }
    }
}
