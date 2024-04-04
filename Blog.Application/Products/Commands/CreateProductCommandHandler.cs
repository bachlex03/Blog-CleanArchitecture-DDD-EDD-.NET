
using MediatR;
using ErrorOr;
using Blog.Domain;
using Productt = Blog.Domain.Product;

namespace Blog.Application.Product.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Productt>>
    {
        private readonly CreateProductValidator _validator;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(CreateProductValidator validator, IProductRepository productRepository)
        {
            _validator = validator;
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<Productt>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validateResult = _validator.Validate(command);

            if (!validateResult.IsValid)
            {
                return Error.Validation(description: "Validate product failure");
            }

            var product = new Productt(command.id, command.name, command.price, command.sku);

            await _productRepository.Add(product);

            return product;
        }
    }
}