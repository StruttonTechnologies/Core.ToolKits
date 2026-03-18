namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided string contains meaningful characters (is not <see langword="null"/>, empty, or white-space).
        /// </summary>
        /// <param name="value">
        /// The string value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value contains meaningful characters.
        /// </returns>
        public static GuardCondition<string> HasValue(string? value)
        {
            return new GuardCondition<string>(value, !string.IsNullOrWhiteSpace(value));
        }

        /// <summary>
        /// Evaluates whether the selected string value from the provided object contains meaningful characters.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
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
        /// A guard continuation that can apply a behavior when the selected string value contains meaningful characters.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<T> HasValue<T>(T? value, Func<T, string?> selector)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, false);
            }

            return new GuardCondition<T>(value, !string.IsNullOrWhiteSpace(selector(value)));
        }
    }
}
