using System.Numerics;

namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided numeric value is negative (less than zero).
        /// </summary>
        /// <typeparam name="T">
        /// The numeric type being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The numeric value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is negative.
        /// </returns>
        public static GuardCondition<T> IsNegative<T>(T value)
            where T : INumber<T>
        {
            return new GuardCondition<T>(value, value < T.Zero);
        }

        /// <summary>
        /// Evaluates whether the selected numeric value from the provided object is negative (less than zero).
        /// The guard does not match when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TObject">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The numeric type being selected.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the numeric value.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the selected value is negative.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsNegative<TObject, TValue>(TObject? value, Func<TObject, TValue> selector)
            where TObject : class
            where TValue : INumber<TValue>
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, false);
            }

            return new GuardCondition<TObject>(value, selector(value) < TValue.Zero);
        }
    }
}
