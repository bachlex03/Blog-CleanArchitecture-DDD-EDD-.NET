namespace Blog.Application.Auth;

public class AuthService : IAuthService
{
    public AuthResult Login(string Email, string Password)
    {
        return new AuthResult(Guid.NewGuid(), "Bach", "Le", Email, "sample_token");
    }

    public AuthResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthResult(Guid.NewGuid(), FirstName, LastName, Email, "sample_token");
    }
}