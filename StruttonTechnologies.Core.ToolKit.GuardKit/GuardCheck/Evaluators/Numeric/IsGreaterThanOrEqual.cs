using System.Numerics;

namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided numeric value is greater than or equal to the comparison value.
        /// </summary>
        /// <typeparam name="T">
        /// The numeric type being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The numeric value to evaluate.
        /// </param>
        /// <param name="comparison">
        /// The value to compare against.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value is greater than or equal to the comparison.
        /// </returns>
        public static GuardCondition<T> IsGreaterThanOrEqual<T>(T value, T comparison)
            where T : INumber<T>
        {
            return new GuardCondition<T>(value, value >= comparison);
        }

        /// <summary>
        /// Evaluates whether the selected numeric value from the provided object is greater than or equal to the comparison value.
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
        /// <param name="comparison">
        /// The value to compare against.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the selected value is greater than or equal to the comparison.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsGreaterThanOrEqual<TObject, TValue>(TObject? value, Func<TObject, TValue> selector, TValue comparison)
            where TObject : class
            where TValue : INumber<TValue>
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, false);
            }

            return new GuardCondition<TObject>(value, selector(value) >= comparison);
        }
    }
}
