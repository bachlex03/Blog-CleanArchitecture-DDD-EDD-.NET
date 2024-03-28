namespace Blog.Application;

using Blog.Application.Auth;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthService, AuthService>();

        return service;
    }
}