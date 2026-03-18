namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided string is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">
        /// The string value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is <see langword="null"/> or empty.
        /// </returns>
        public static GuardCondition<string> IsNullOrEmpty(string? value)
        {
            return new GuardCondition<string>(value, string.IsNullOrEmpty(value));
        }

        /// <summary>
        /// Evaluates whether the selected string value from the provided object is <see langword="null"/> or empty.
        /// The guard also matches when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the string value.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the object is <see langword="null"/> or the selected
        /// string value is <see langword="null"/> or empty.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<T> IsNullOrEmpty<T>(T? value, Func<T, string?> selector)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, true);
            }

            return new GuardCondition<T>(value, string.IsNullOrEmpty(selector(value)));
        }
    }
}
