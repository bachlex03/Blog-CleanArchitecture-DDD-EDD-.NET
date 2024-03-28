namespace Blog.Application.Auth;

public interface IAuthService
{
    public AuthResult Login(string Email, string Password);

    public AuthResult Register(string FirstName, string LastName, string Email, string Password);
}