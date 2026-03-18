namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided value is NOT of the specified type.
        /// </summary>
        /// <typeparam name="TExpected">
        /// The type to check against.
        /// </typeparam>
        /// <param name="value">
        /// The value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is not of type <typeparamref name="TExpected"/>.
        /// </returns>
        public static GuardCondition<object> IsNotType<TExpected>(object? value)
        {
            return new GuardCondition<object>(value, value is not TExpected);
        }

        /// <summary>
        /// Evaluates whether the selected value from the provided object is NOT of the specified type.
        /// The guard matches when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TObject">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <typeparam name="TExpected">
        /// The type to check against.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the value to check.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the object is <see langword="null"/> or the selected
        /// value is not of type <typeparamref name="TExpected"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsNotType<TObject, TExpected>(TObject? value, Func<TObject, object?> selector)
            where TObject : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, true);
            }

            return new GuardCondition<TObject>(value, selector(value) is not TExpected);
        }
    }
}
