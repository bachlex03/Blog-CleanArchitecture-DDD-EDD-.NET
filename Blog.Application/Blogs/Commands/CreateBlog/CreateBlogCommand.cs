using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Blog.Application.Blogs.Commands.CreateBlog
{
    public record CreateBlogCommand(string Title, string content) : IRequest;

}