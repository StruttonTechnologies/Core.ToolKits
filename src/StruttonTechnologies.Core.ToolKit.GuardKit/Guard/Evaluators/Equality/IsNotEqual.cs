namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided value is not equal to the comparison value.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The value to evaluate.
        /// </param>
        /// <param name="comparison">
        /// The value to compare against.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the values are not equal.
        /// </returns>
        public static GuardCondition<T> IsNotEqual<T>(T? value, T? comparison)
        {
            return new GuardCondition<T>(value, !EqualityComparer<T>.Default.Equals(value, comparison));
        }

        /// <summary>
        /// Evaluates whether the selected value from the provided object is not equal to the comparison value.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TObject">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The type of value being selected and compared.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the value.
        /// </param>
        /// <param name="comparison">
        /// The value to compare against.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the selected value does not equal the comparison value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsNotEqual<TObject, TValue>(TObject? value, Func<TObject, TValue> selector, TValue? comparison)
            where TObject : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, false);
            }

            return new GuardCondition<TObject>(value, !EqualityComparer<TValue>.Default.Equals(selector(value), comparison));
        }
    }
}
