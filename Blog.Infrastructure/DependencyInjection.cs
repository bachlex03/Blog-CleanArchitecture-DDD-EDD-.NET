namespace Blog.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

using Blog.Application.Common.Interfaces.Auth;
using Blog.Application.services.RabbitMq;
using Blog.Infrastructure.Auth;
using Blog.Infrastructure.RabbitMq;
using RabbitMQ.Client;
using Blog.Domain;
using Blog.Infrastructure.data.Sqlite;
using Blog.Domain.Example.Customers;
using Blog.Infrastructure.data.postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerRepositoryPostgres, CustomerRepositoryPostgres>();

        // Register RabbitMqUtil
        services.AddSingleton<IRabbitMqUtil, RabbitMqUtil>().AddHostedService<RabbitMqService>();

        return services;
    }
}


