
using MediatR;
using ErrorOr;
using Productt = Blog.Domain.Product;

namespace Blog.Application.Product
{
    public record CreateProductCommand(Guid id, string name, Money price, Sku sku) : IRequest<ErrorOr<Productt>>;

}