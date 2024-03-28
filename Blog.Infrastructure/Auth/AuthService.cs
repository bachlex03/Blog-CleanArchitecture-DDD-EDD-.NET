namespace Blog.Infrastructure.Auth;

using Blog.Application.Auth;
using Blog.Application.Common.Interfaces.Auth;

public class AuthService(IJwtGenerator _jwtGenerator) : IAuthService
{
    public AuthResult Register(string FirstName, string LastName, string Email, string Password)
    {
        // 1. Check if the user already exists

        // 2. Create a new user
        var userId = Guid.NewGuid();

        // 3. Create JWT token
        var token = _jwtGenerator.JwtGenerator(userId, "Bach", "Le");

        return new AuthResult(userId, FirstName, LastName, Email, token);
    }

    public AuthResult Login(string Email, string Password)
    {
        return new AuthResult(Guid.NewGuid(), "Bach", "Le", Email, "sample_token");
    }


}