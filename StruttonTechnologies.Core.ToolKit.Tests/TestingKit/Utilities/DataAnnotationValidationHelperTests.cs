using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Testing.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Utilities
{
    [ExcludeFromCodeCoverage]
    public class DataAnnotationValidationHelperTests
    {
        [Fact]
        public void ValidateObject_ShouldThrowArgumentNullException_WhenInstanceIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                DataAnnotationValidationHelper.ValidateObject(null!));

            Assert.Equal("instance", exception.ParamName);
        }

        [Fact]
        public void ValidateObject_ShouldReturnEmpty_WhenObjectIsValid()
        {
            var instance = new ValidTestObject { Name = "Test", Age = 25 };

            var results = DataAnnotationValidationHelper.ValidateObject(instance);

            Assert.Empty(results);
        }

        [Fact]
        public void ValidateObject_ShouldReturnErrors_WhenPropertyInvalid()
        {
            var instance = new ValidTestObject { Name = string.Empty, Age = 25 };

            var results = DataAnnotationValidationHelper.ValidateObject(instance);

            Assert.NotEmpty(results);
        }

        [Fact]
        public void ValidateObject_ShouldReturnMultipleErrors_WhenMultiplePropertiesInvalid()
        {
            var instance = new ValidTestObject { Name = string.Empty, Age = -1 };

            var results = DataAnnotationValidationHelper.ValidateObject(instance);

            Assert.True(results.Count >= 2);
        }

        [Fact]
        public void ValidateObject_ShouldValidateNestedObjects()
        {
            var instance = new ParentObject
            {
                Name = "Parent",
                Child = new ChildObject { Email = "invalid" }
            };

            var results = DataAnnotationValidationHelper.ValidateObject(instance);

            Assert.NotEmpty(results);
        }

        [Fact]
        public void ValidateObject_ShouldHandleNullNestedObjects()
        {
            var instance = new ParentObject
            {
                Name = "Parent",
                Child = null
            };

            var results = DataAnnotationValidationHelper.ValidateObject(instance);

            Assert.Empty(results);
        }

        [Fact]
        public void ValidateObject_ShouldHandleCircularReferences()
        {
            var instance = new CircularObject { Name = "Test" };
            instance.Reference = instance;

            var results = DataAnnotationValidationHelper.ValidateObject(instance);

            Assert.Empty(results);
        }

        private class ValidTestObject
        {
            [Required]
            public string Name { get; set; } = string.Empty;

            [Range(0, 120)]
            public int Age { get; set; }
        }

        private class ParentObject
        {
            [Required]
            public string Name { get; set; } = string.Empty;

            public ChildObject? Child { get; set; }
        }

        private class ChildObject
        {
            [EmailAddress]
            public string Email { get; set; } = string.Empty;
        }

        private class CircularObject
        {
            [Required]
            public string Name { get; set; } = string.Empty;

            public CircularObject? Reference { get; set; }
        }
    }
}
