namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided string is empty.
        /// </summary>
        /// <param name="value">
        /// The string value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is empty.
        /// </returns>
        /// <remarks>
        /// A <see langword="null"/> string does not match this condition.
        /// </remarks>
        public static GuardCondition<string> IsEmpty(string? value)
        {
            return new GuardCondition<string>(value, value is not null && value.Length == 0);
        }

        /// <summary>
        /// Evaluates whether the selected string value from the provided object is empty.
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
        /// A guard continuation that can apply a behavior when the selected string value is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>
        /// A <see langword="null"/> selected string does not match this condition.
        /// </remarks>
        public static GuardCondition<T> IsEmpty<T>(T? value, Func<T, string?> selector)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, false);
            }

            string? selectedValue = selector(value);
            return new GuardCondition<T>(value, selectedValue is not null && selectedValue.Length == 0);
        }
    }
}
