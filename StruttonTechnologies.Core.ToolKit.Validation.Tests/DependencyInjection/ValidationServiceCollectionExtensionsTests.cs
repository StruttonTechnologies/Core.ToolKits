using System.Reflection;

namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.DependencyInjection
{
    /// <summary>
    /// Contains test scenarios for <see cref="ValidationServiceCollectionExtensions"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ValidationServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddValidators_WhenServicesIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationServiceCollectionExtensions.AddValidators(null!, typeof(ValidationServiceCollectionExtensionsTests).Assembly));
        }

        [Fact]
        public void AddValidators_WhenAssemblyContainsConcreteValidators_RegistersValidatorInterfaces()
        {
            TestServiceCollection services = new();

            IServiceCollection returned = services.AddValidators(typeof(ValidationServiceCollectionExtensionsTests).Assembly);

            Assert.Same(services, returned);
            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(IValidator<string>) &&
                descriptor.ImplementationType == typeof(TestStringValidator) &&
                descriptor.Lifetime == ServiceLifetime.Scoped);
            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(IValidator<int>) &&
                descriptor.ImplementationType == typeof(TestIntValidator) &&
                descriptor.Lifetime == ServiceLifetime.Scoped);
        }

        [Fact]
        public void AddValidators_WhenAssemblyParameterIsOmitted_UsesExecutingAssembly()
        {
            TestServiceCollection services = new();

            services.AddValidators();

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(IValidator<string>) &&
                descriptor.ImplementationType == typeof(EmailFormatValidator));
        }

        [Fact]
        public void AddValidators_WhenTypeDoesNotImplementValidator_DoesNotRegisterType()
        {
            TestServiceCollection services = new();

            services.AddValidators(typeof(ValidationServiceCollectionExtensionsTests).Assembly);

            Assert.DoesNotContain(services, descriptor => descriptor.ImplementationType == typeof(NonValidatorType));
        }

        [Fact]
        public void AddValidators_WhenTypeIsAbstract_DoesNotRegisterType()
        {
            TestServiceCollection services = new();

            services.AddValidators(typeof(ValidationServiceCollectionExtensionsTests).Assembly);

            Assert.DoesNotContain(services, descriptor => descriptor.ImplementationType == typeof(AbstractTestValidator));
        }

        [Fact]
        public void AddValidators_WhenTypeImplementsMultipleValidatorInterfaces_RegistersEachInterface()
        {
            TestServiceCollection services = new();

            services.AddValidators(typeof(ValidationServiceCollectionExtensionsTests).Assembly);

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(IValidator<Guid>) &&
                descriptor.ImplementationType == typeof(MultiValidator));
            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(IValidator<long>) &&
                descriptor.ImplementationType == typeof(MultiValidator));
        }

        private sealed class TestServiceCollection : List<ServiceDescriptor>, IServiceCollection;

        private sealed class TestStringValidator : IValidator<string>
        {
            public ValidationResult Validate(string input) => ValidationResult.Success(input);
        }

        private sealed class TestIntValidator : IValidator<int>
        {
            public ValidationResult Validate(int input) => ValidationResult.Success(input.ToString());
        }

        private abstract class AbstractTestValidator : IValidator<string>
        {
            public abstract ValidationResult Validate(string input);
        }

        private sealed class MultiValidator : IValidator<Guid>, IValidator<long>
        {
            ValidationResult IValidator<Guid>.Validate(Guid input) => ValidationResult.Success(input.ToString());

            ValidationResult IValidator<long>.Validate(long input) => ValidationResult.Success(input.ToString());
        }

        private sealed class NonValidatorType;
    }
}
