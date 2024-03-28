namespace Blog.Application.Common.Interfaces.Auth;


public interface IJwtGenerator
{
    string JwtGenerator(Guid userId, string firstName, string lastName);
}