using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Blog.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        //         // private readonly IProductRepository _productRepository;


        //         // public CreateProductCommandHandler(IProductRepository productRepository)
        //         // {
        //         //     _productRepository = productRepository;
        //         // }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            /*
            Business logic for creating
            */



            // _productRepository.Add(product);

            await Task.CompletedTask;
        }
    }
}