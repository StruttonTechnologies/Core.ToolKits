namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided value does not equal the default value for its type.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value does not equal <c>default(T)</c>.
        /// </returns>
        public static GuardCondition<T> IsNotDefault<T>(T? value)
        {
            return new GuardCondition<T>(value, !EqualityComparer<T>.Default.Equals(value, default));
        }

        /// <summary>
        /// Evaluates whether the selected value from the provided object does not equal the default value for its type.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TObject">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The type of value being selected.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the value.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the selected value does not equal its default.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsNotDefault<TObject, TValue>(TObject? value, Func<TObject, TValue> selector)
            where TObject : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, false);
            }

            return new GuardCondition<TObject>(value, !EqualityComparer<TValue>.Default.Equals(selector(value), default));
        }
    }
}
