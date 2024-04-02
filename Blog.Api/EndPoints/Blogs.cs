using Blog.Application.Blogs.Commands.CreateBlog;
using Carter;
using MediatR;


namespace Blog.Api.Endpoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/blogs", async (CreateBlogCommand command, ISender sender) =>
            {
                await sender.Send(command);

                return Results.Ok();
            });
        }
    }
}