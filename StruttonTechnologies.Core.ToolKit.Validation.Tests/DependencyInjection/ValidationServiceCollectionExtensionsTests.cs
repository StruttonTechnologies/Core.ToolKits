namespace StruttonTechnologies.Core.ToolKit.Validation.Tests.DependencyInjection
{
    /// <summary>
    /// Contains test scenarios for <see cref="ValidationServiceCollectionExtensions"/>.
    /// </summary>
    public sealed class ValidationServiceCollectionExtensionsTests
    {
        /// <summary>
        /// Verifies that <c>AddValidation</c> throws when services is null.
        /// </summary>
        [Fact]
        public void AddValidation_WhenServicesIsNull_ThrowsArgumentNullException()
        {
            IServiceCollection? services = null;

            Assert.Throws<ArgumentNullException>(() => services!.AddValidation());
        }

        /// <summary>
        /// Verifies that <c>AddValidation</c> returns the same service collection instance.
        /// </summary>
        [Fact]
        public void AddValidation_WhenCalled_ReturnsSameServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            IServiceCollection returned = services.AddValidation();

            Assert.Same(services, returned);
        }

        /// <summary>
        /// Verifies that <c>AddValidation</c> registers explicit validator services.
        /// </summary>
        [Fact]
        public void AddValidation_WhenCalled_RegistersExpectedValidators()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddValidation();

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(NotDefaultValidator<>) &&
                descriptor.ImplementationType == typeof(NotDefaultValidator<>) &&
                descriptor.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(IdValidator<>) &&
                descriptor.ImplementationType == typeof(IdValidator<>) &&
                descriptor.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(EmailFormatValidator) &&
                descriptor.ImplementationType == typeof(EmailFormatValidator) &&
                descriptor.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(PhoneNumberFormatValidator) &&
                descriptor.ImplementationType == typeof(PhoneNumberFormatValidator) &&
                descriptor.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(UsZipCodeFormatValidator) &&
                descriptor.ImplementationType == typeof(UsZipCodeFormatValidator) &&
                descriptor.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, descriptor =>
                descriptor.ServiceType == typeof(CompositeValidator<>) &&
                descriptor.ImplementationType == typeof(CompositeValidator<>) &&
                descriptor.Lifetime == ServiceLifetime.Transient);
        }

        /// <summary>
        /// Verifies that <c>AddValidation</c> does not register validators that require runtime configuration.
        /// </summary>
        [Fact]
        public void AddValidation_WhenCalled_DoesNotRegisterPolicyOrPatternValidators()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddValidation();

            Assert.DoesNotContain(services, descriptor =>
                descriptor.ServiceType == typeof(RegexValidator));

            Assert.DoesNotContain(services, descriptor =>
                descriptor.ServiceType == typeof(WhitelistEmailValidator));

            Assert.DoesNotContain(services, descriptor =>
                descriptor.ServiceType == typeof(BlacklistPhoneValidator));
        }
    }
}
