using System.Diagnostics.CodeAnalysis;

namespace StruttonTechnologies.Core.ToolKit.Tests.Guard.GuardCondition.Behaviors.ReturnValueOrThrowBehaviors
{
    [ExcludeFromCodeCoverage]
    public class ArgumentValidationTests
    {
        [Fact]
        public void ReturnOrThrow_ShouldThrowArgumentNullException_WhenExceptionFactoryIsNull()
        {
            var condition = StruttonTechnologies.Core.ToolKit.GuardKit.Guard.IsNull<string>(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                condition.ReturnOrThrow<InvalidOperationException>(null!));

            Assert.Equal("exceptionFactory", exception.ParamName);
        }
    }
}
