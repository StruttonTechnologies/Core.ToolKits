namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided value is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is not <see langword="null"/>.
        /// </returns>
        public static GuardCondition<T> IsNotNull<T>(T? value)
            where T : class
        {
            return new GuardCondition<T>(value, value is not null);
        }

        /// <summary>
        /// Evaluates whether the selected value from the provided object is not <see langword="null"/>.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
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
        /// A guard continuation that can apply a behavior when the selected property is not <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<T> IsNotNull<T, TProperty>(T? value, Func<T, TProperty?> selector)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, false);
            }

            return new GuardCondition<T>(value, selector(value) is not null);
        }
    }
}
