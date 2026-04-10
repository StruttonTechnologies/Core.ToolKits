using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace StruttonTechnologies.Core.ToolKit.Testing.Utilities
{
    /// <summary>
    /// Validates objects using data annotations, including nested complex objects.
    /// </summary>
    public static class DataAnnotationValidationHelper
    {
        public static IReadOnlyList<ValidationResult> ValidateObject(object instance)
        {
            ArgumentNullException.ThrowIfNull(instance);

            List<ValidationResult> results = [];
            ValidateObjectGraph(instance, results, new HashSet<object>(ReferenceEqualityComparer.Instance));
            return results;
        }

        private static void ValidateObjectGraph(
            object instance,
            ICollection<ValidationResult> results,
            ISet<object> visited)
        {
            if (!visited.Add(instance))
            {
                return;
            }

            Validator.TryValidateObject(
                instance,
                new ValidationContext(instance),
                results,
                validateAllProperties: true);

            foreach (var property in instance.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType)
                {
                    continue;
                }

                object? value = property.GetValue(instance);
                if (value is null)
                {
                    continue;
                }

                ValidateObjectGraph(value, results, visited);
            }
        }

        private sealed class ReferenceEqualityComparer : IEqualityComparer<object>
        {
            public static ReferenceEqualityComparer Instance { get; } = new();

            public new bool Equals(object? x, object? y) => ReferenceEquals(x, y);

            public int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
        }
    }
}
