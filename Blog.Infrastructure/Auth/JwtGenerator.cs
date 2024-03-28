using Blog.Application.Common.Interfaces.Auth;

namespace Blog.Infrastructure.Auth;

public class JwtGenerator : IJwtGenerator
{
    string IJwtGenerator.JwtGenerator(Guid userId, string firstName, string lastName)
    {
        return "random token";
    }
}