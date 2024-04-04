
using FluentValidation.AspNetCore;
using Blog.Application.Blogs.Commands.CreateBlog;
using Blog.Domain;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient<CreateBlogCommandHandler>();

        services.AddTransient<CreateBlogCommandValidator>();

        return services;
    }
}