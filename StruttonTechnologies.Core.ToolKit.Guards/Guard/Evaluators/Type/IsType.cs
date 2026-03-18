namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided value is of the specified type.
        /// </summary>
        /// <typeparam name="TExpected">
        /// The type to check against.
        /// </typeparam>
        /// <param name="value">
        /// The value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is of type <typeparamref name="TExpected"/>.
        /// </returns>
        public static GuardCondition<object> IsType<TExpected>(object? value)
        {
            return new GuardCondition<object>(value, value is TExpected);
        }

        /// <summary>
        /// Evaluates whether the selected value from the provided object is of the specified type.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
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
        /// A guard continuation that can apply a behavior when the selected value is of type <typeparamref name="TExpected"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsType<TObject, TExpected>(TObject? value, Func<TObject, object?> selector)
            where TObject : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, false);
            }

            return new GuardCondition<TObject>(value, selector(value) is TExpected);
        }
    }
}
