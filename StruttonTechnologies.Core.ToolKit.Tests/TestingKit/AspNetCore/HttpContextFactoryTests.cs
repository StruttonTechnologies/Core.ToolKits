using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TestHttpContextFactory = StruttonTechnologies.Core.ToolKit.Testing.AspNetCore.HttpContextFactory;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.AspNetCore
{
    [ExcludeFromCodeCoverage]
    public class HttpContextFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnHttpContext_WhenUserIsNull()
        {
            var context = TestHttpContextFactory.Create();

            Assert.NotNull(context);
            Assert.NotNull(context.User);
        }

        [Fact]
        public void Create_ShouldSetUser_WhenUserProvided()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity([new Claim("test", "value")]));

            var context = TestHttpContextFactory.Create(user);

            Assert.Same(user, context.User);
        }

        [Fact]
        public void Create_ShouldReturnDefaultHttpContext()
        {
            var context = TestHttpContextFactory.Create();

            Assert.IsType<DefaultHttpContext>(context);
        }

        [Fact]
        public void CreateUserWithRole_ShouldThrowArgumentException_WhenRoleIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                TestHttpContextFactory.CreateUserWithRole(null!));
        }

        [Fact]
        public void CreateUserWithRole_ShouldThrowArgumentException_WhenRoleIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                TestHttpContextFactory.CreateUserWithRole(string.Empty));

            Assert.Equal("role", exception.ParamName);
        }

        [Fact]
        public void CreateUserWithRole_ShouldThrowArgumentException_WhenRoleIsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                TestHttpContextFactory.CreateUserWithRole("   "));

            Assert.Equal("role", exception.ParamName);
        }

        [Fact]
        public void CreateUserWithRole_ShouldReturnUserWithRole()
        {
            var user = TestHttpContextFactory.CreateUserWithRole("Admin");

            Assert.True(user.IsInRole("Admin"));
        }

        [Fact]
        public void CreateUserWithRole_ShouldCreateAuthenticatedUser()
        {
            var user = TestHttpContextFactory.CreateUserWithRole("Admin");

            Assert.NotNull(user.Identity);
            Assert.True(user.Identity.IsAuthenticated);
        }

        [Fact]
        public void CreateUserWithRole_ShouldHaveRoleClaim()
        {
            var user = TestHttpContextFactory.CreateUserWithRole("Manager");

            var roleClaim = user.FindFirst(ClaimTypes.Role);
            Assert.NotNull(roleClaim);
            Assert.Equal("Manager", roleClaim.Value);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldThrowArgumentException_WhenTypeIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                TestHttpContextFactory.CreateUserWithClaim(null!, "value"));
        }

        [Fact]
        public void CreateUserWithClaim_ShouldThrowArgumentException_WhenTypeIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                TestHttpContextFactory.CreateUserWithClaim(string.Empty, "value"));

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldThrowArgumentException_WhenTypeIsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                TestHttpContextFactory.CreateUserWithClaim("   ", "value"));

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldThrowArgumentException_WhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                TestHttpContextFactory.CreateUserWithClaim("type", null!));
        }

        [Fact]
        public void CreateUserWithClaim_ShouldThrowArgumentException_WhenValueIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                TestHttpContextFactory.CreateUserWithClaim("type", string.Empty));

            Assert.Equal("value", exception.ParamName);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldThrowArgumentException_WhenValueIsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                TestHttpContextFactory.CreateUserWithClaim("type", "   "));

            Assert.Equal("value", exception.ParamName);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldReturnUserWithClaim()
        {
            var user = TestHttpContextFactory.CreateUserWithClaim("email", "test@example.com");

            var claim = user.FindFirst("email");
            Assert.NotNull(claim);
            Assert.Equal("test@example.com", claim.Value);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldCreateAuthenticatedUser()
        {
            var user = TestHttpContextFactory.CreateUserWithClaim("sub", "123");

            Assert.NotNull(user.Identity);
            Assert.True(user.Identity.IsAuthenticated);
        }

        [Fact]
        public void CreateUserWithClaim_ShouldUseTestAuthenticationType()
        {
            var user = TestHttpContextFactory.CreateUserWithClaim("name", "John");

            Assert.NotNull(user.Identity);
            Assert.Equal("Test", user.Identity.AuthenticationType);
        }
    }
}
