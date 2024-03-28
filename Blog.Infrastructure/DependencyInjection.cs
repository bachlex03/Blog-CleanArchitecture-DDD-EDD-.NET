namespace Blog.Infrastructure;

using Blog.Application.Auth;
using Blog.Application.Common.Interfaces.Auth;
using Blog.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}


