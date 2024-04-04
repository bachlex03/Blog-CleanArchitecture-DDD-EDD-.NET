namespace Blog.Application.Common.Interfaces.Auth;


public interface IJwtGenerator
{
    string JwtGenerator(string firstName, string lastName, string email);
}