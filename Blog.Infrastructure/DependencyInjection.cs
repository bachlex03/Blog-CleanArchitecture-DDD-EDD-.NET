namespace Blog.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

using Blog.Application.Auth;
using Blog.Application.Common.Interfaces.Auth;
using Blog.Application.services.RabbitMq;
using Blog.Infrastructure.Auth;
using Blog.Infrastructure.RabbitMqUtilTest;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddSingleton<IRabbitMqUtil, RabbitMqUtil>();

        return services;
    }
}


