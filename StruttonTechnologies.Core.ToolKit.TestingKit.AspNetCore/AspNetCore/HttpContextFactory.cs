using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace StruttonTechnologies.Core.ToolKit.Testing.AspNetCore;

/// <summary>
/// Creates HTTP context objects for tests.
/// </summary>
public static class HttpContextFactory
{
    public static HttpContext Create(ClaimsPrincipal? user = null)
    {
        var context = new DefaultHttpContext();

        if (user is not null)
        {
            context.User = user;
        }

        return context;
    }

    public static ClaimsPrincipal CreateUserWithRole(string role)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(role);

        return new ClaimsPrincipal(
            new ClaimsIdentity(
                [new Claim(ClaimTypes.Role, role)],
                authenticationType: "Test"));
    }

    public static ClaimsPrincipal CreateUserWithClaim(string type, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        return new ClaimsPrincipal(
            new ClaimsIdentity(
                [new Claim(type, value)],
                authenticationType: "Test"));
    }
}
