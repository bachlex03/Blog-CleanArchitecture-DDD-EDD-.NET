using Blog.Api.Contracts.Product;
using Blog.Application.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Example.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var createCommand = new CreateProductCommand(Guid.NewGuid(), request.name, new Money(request.currency, request.amount), Sku.Create(request.sku));

            var result = await _mediator.Send(createCommand);

            return Ok(result.Value);
        }
    }
}