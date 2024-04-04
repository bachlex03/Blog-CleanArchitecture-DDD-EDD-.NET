
namespace Blog.Domain
{
    public interface IProductRepository
    {
        public Task Add(Product product);
    }
}