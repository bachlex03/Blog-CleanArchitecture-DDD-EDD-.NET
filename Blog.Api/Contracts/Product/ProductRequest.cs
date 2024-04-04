
namespace Blog.Api.Contracts.Product
{
    public record CreateProductRequest(string name, string currency, decimal amount, string sku);
}