namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided value is equal to its default value.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is equal to its default value.
        /// </returns>
        public static GuardCondition<T> IsDefault<T>(T value)
            where T : struct
        {
            return new GuardCondition<T>(value, EqualityComparer<T>.Default.Equals(value, default));
        }

        /// <summary>
        /// Evaluates whether the selected value from the provided object is equal to its default value.
        /// The guard also matches when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <typeparam name="TProperty">
        /// The type of property being selected.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the property value.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the object is <see langword="null"/> or the selected
        /// property value is equal to its default value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<T> IsDefault<T, TProperty>(T? value, Func<T, TProperty> selector)
            where T : class
            where TProperty : struct
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, true);
            }

            TProperty propertyValue = selector(value);

            return new GuardCondition<T>(value, EqualityComparer<TProperty>.Default.Equals(propertyValue, default));
        }
    }
}
